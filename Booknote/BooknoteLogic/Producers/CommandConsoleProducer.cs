using System.Collections.Generic;
using System.Linq;
using Attributes;
using BooknoteLogic.Commands;

namespace BooknoteLogic.Producers
{
    [ContainerElement]
    public class CommandConsoleProducer : ICommandProducer
    {
        private readonly Dictionary<string,IFactory<IBaseCommand>> _commands = new Dictionary<string, IFactory<IBaseCommand>>();

        public CommandConsoleProducer (List<IFactory<IBaseCommand>> commands)
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