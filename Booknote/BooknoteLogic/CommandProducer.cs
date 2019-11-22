using System.Collections.Generic;
using Attributes;
using BooknoteLogic.Commands;

namespace BooknoteLogic
{
    [ContainerElement]
    public class CommandProducer
    {
        private readonly Dictionary<string,IFactory<IBaseCommand>> _commands = new Dictionary<string, IFactory<IBaseCommand>>();

        public CommandProducer (List<IFactory<IBaseCommand>> commands)
        {
            commands.ForEach(x=>_commands.Add(x.GetCreatorName(), x));
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