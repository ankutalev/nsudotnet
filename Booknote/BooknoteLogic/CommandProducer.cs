using System;
using System.Collections.Generic;
using Attributes;

namespace BooknoteLogic
{
    [ContainerElement]
    public class CommandProducer
    {
        private readonly Dictionary<string,BaseCommand> _commands = new Dictionary<string, BaseCommand>();

        public CommandProducer (List<BaseCommand> commands)
        {
            commands.ForEach(x=>_commands.Add(x.ToString(), x));
        }

        public IEnumerable<string> GetAvailableCommands()
        {
            return _commands.Keys;
        }

        public BaseCommand GetCommand(string type)
        {
            return _commands[type ?? throw new ArgumentException("No such command!")];
        }
    }
}