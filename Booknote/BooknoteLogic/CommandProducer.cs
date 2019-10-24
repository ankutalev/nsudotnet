using System.Collections.Generic;
using Attributes;
using BooknoteLogic.Commands;

namespace BooknoteLogic
{
    [ContainerElement]
    public class CommandProducer
    {
        private readonly Dictionary<string,IBaseCommand> _commands = new Dictionary<string, IBaseCommand>();

        public CommandProducer (List<IBaseCommand> commands)
        {
            commands.ForEach(x=>_commands.Add(x.NameToString(), x));
        }

        public IEnumerable<string> GetAvailableCommands()
        {
            return _commands.Keys;
        }

        public IBaseCommand GetCommand(string type)
        {
            return _commands[type];
        }
    }
}