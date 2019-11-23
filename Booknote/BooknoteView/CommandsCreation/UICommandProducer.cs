using System.Collections.Generic;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;
using BooknoteLogic.Producers;

namespace BooknoteView.CommandsCreation
{
    [ContainerElement]
    public class UiCommandProducer : ICommandProducer
    {
        private readonly Dictionary<string,IFactory<IBaseCommand>> _commands = new Dictionary<string, IFactory<IBaseCommand>>();

        public UiCommandProducer (List<IFactory<IBaseCommand>> commands)
        {
            foreach (var factory in commands)
            {
                var factoryName = factory.GetCreatorName();
                if (factoryName.StartsWith("UI"))
                    _commands.Add(factoryName,factory);
            }
        }
        public IEnumerable<string> GetAvailableCommands()
        {
            return _commands.Keys;
        }

        public IBaseCommand GetCommand(string type)
        {
            return _commands[type].CreateRecord();
        }
    }
}