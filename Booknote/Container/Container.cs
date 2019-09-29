using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Attributes;

namespace Container {
    public class Container {
        private const string LogicModule = "BooknoteLogic";
        private readonly List<Type> _rootElements = new List<Type>();
        private readonly Dictionary<Type,object> _alreadyCreated = new Dictionary<Type, object>();
        private List<Type> _markedTypes;
        public Container() 
        {
                   
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            Console.WriteLine(type);
            if (_alreadyCreated.TryGetValue(type, out var obj))
                return (T)obj;
            obj = ConstructByType(type);
            _alreadyCreated[type] = obj;
            return (T)obj;
        }

        private object ConstructByType(Type t)
        {
            if (_markedTypes == null)
            {
                var logicAssembly = Assembly.Load(LogicModule);
                _markedTypes = (from type in logicAssembly.GetTypes()
                    where Attribute.IsDefined(type, typeof(ContainerElement))
                    select type).ToList();
            }
            var ctor =  GetConstructor(t);
            var ctorParams = ctor.GetParameters();
            return ctorParams.Length == 0 ? ctor.Invoke(null) 
                : ConstructByResolvingDependencies(ctor.GetParameters());
        }

        private object ConstructByResolvingDependencies(ParameterInfo[] dependencies)
        {
            throw new NotImplementedException("Not today");
        }
        
        private ConstructorInfo GetConstructor(Type type)
        {
            if (!_markedTypes.Contains(type))
                throw new ArgumentException($"Type {type} hasn't marked by {typeof(ContainerElement)} attribute");
            var ctors = type.GetConstructors();
            if (ctors.Length == 0 )
                throw new ArgumentException($"Type {type} hasn't public constructors!");
            if (ctors.Length > 1)
                throw new ArgumentException($"Type {type} has more than pne public constructors!");
            return ctors[0];
        }
        
    }
}