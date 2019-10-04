using System;
using System.Collections.Generic;
using Attributes;

namespace BooknoteLogic
{
    [ContainerElement]
    public class CommandProducer
    {
        private readonly Dictionary<Type,BaseCommand> _commands = new Dictionary<Type, BaseCommand>();

        public CommandProducer (List<BaseCommand> commands)
        {
            commands.ForEach(x=>_commands.Add(x.GetType(), x));
        }

        public IEnumerable<Type> GetAvailableCommands()
        {
            return _commands.Keys;
        }

        public BaseCommand GetCommand(string type)
        {
            return _commands[Type.GetType(type) ?? throw new ArgumentException("No such command!")];
        }
    }
}