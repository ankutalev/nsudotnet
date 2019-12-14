using System.Collections.Generic;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;
using BooknoteLogic.Producers;

namespace Tests
{
    [ContainerElement]
    public class TestCommandProducer : ICommandProducer
    {
        private readonly Dictionary<string, IFactory<IBaseCommand>> _commands =
            new Dictionary<string, IFactory<IBaseCommand>>();

        public TestCommandProducer(List<IFactory<IBaseCommand>> commands)
        {
            foreach (var factory in commands)
            {
                var factoryName = factory.GetCreatorName();
                if (factoryName.StartsWith("Test"))
                    _commands.Add(factoryName, factory);
            }
        }

        public IEnumerable<string> GetAvailableCommands()
        {
            return _commands.Keys;
        }

        public IFactory<IBaseCommand> GetFactory(string type)
        {
            return _commands[type];
        }

        public IBaseCommand GetCommand(string type)
        {
            return _commands[type].CreateProduct();
        }
    }
}