using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Attributes;

namespace Container
{
    public class Container
    {
        private const string LogicModule = "BooknoteLogic";
        private readonly HashSet<Type> _foundedByResolving = new HashSet<Type>();
        private readonly Dictionary<Type, object> _alreadyCreated = new Dictionary<Type, object>();
        private List<Type> _markedTypes;

        public T Resolve<T>()
        {
            var type = typeof(T);
            if (_alreadyCreated.TryGetValue(type, out var obj))
                return (T) obj;
            obj = ConstructByType(type);
            return (T) obj;
        }

        private object ConstructByType(Type t)
        {
            if (_alreadyCreated.TryGetValue(t, out var o))
                return o;

            if (_markedTypes == null)
            {
                var logicAssembly = Assembly.Load(LogicModule);
                _markedTypes = (from type in logicAssembly.GetTypes()
                    where Attribute.IsDefined(type, typeof(ContainerElement))
                    select type).ToList();
            }

            var ctor = GetConstructor(t);
            var ctorParams = ctor.GetParameters();
            _foundedByResolving.Add(t);
            ResolvingDependencies(ctorParams.ToList());
            _foundedByResolving.Clear();

            // or select where Select.ctorParams=>param.ParameterType,contains(object key?);
            var parameters = from objects in _alreadyCreated
                join param in ctorParams on objects.Key equals param.ParameterType
                select objects.Value;
            var obj = ctor.Invoke(parameters.ToArray());
            _alreadyCreated[t] = obj;
            return obj;
        }

        private void ResolvingDependencies(List<ParameterInfo> dependencies)
        {
            dependencies.ForEach(dependency =>
            {
                if (_foundedByResolving.Contains(dependency.ParameterType))
                {
                    _foundedByResolving.Clear();
                    throw new ArgumentException("Found circular dependency");
                }

                if (dependency.ParameterType.IsGenericType &&
                    dependency.ParameterType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    ConstructGenericList(dependency.ParameterType);
                }
                else
                {
                    ConstructByType(dependency.ParameterType);
                }
            });
        }

        private void ConstructGenericList(Type genericType)
        {
            var instance = (IList) Activator.CreateInstance(genericType);
            var parentType = genericType.GenericTypeArguments[0];
            var childrenTypes = (from type in _markedTypes
                where type.GetInterfaces().Contains(parentType)
                select type).ToList();

            childrenTypes.ForEach(childType =>
            {
                if (_alreadyCreated.TryGetValue(childType, out var child))
                {
                    instance.Add(child);
                }
                else
                {
                    var obj = ConstructByType(childType);
                    instance.Add(obj);
                    _alreadyCreated[childType] = obj;
                }
            });
            _alreadyCreated[genericType] = instance;
        }

        private ConstructorInfo GetConstructor(Type type)
        {
            if (!_markedTypes.Contains(type))
                throw new ArgumentException($"Type {type} hasn't marked by {typeof(ContainerElement)} attribute");
            var ctors = type.GetConstructors();
            if (ctors.Length == 0)
                throw new ArgumentException($"Type {type} hasn't public constructors!");
            if (ctors.Length > 1)
                throw new ArgumentException($"Type {type} has more than pne public constructors!");
            return ctors[0];
        }
    }
}