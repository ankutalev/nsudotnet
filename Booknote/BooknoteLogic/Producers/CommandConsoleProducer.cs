using System;
using System.Collections.Generic;
using System.Diagnostics;
using Attributes;
using BooknoteLogic.Commands;
using JetBrains.Annotations;

namespace BooknoteLogic.Producers
{
    [ContainerElement]
    public class CommandConsoleProducer : ICommandProducer
    {
       [NotNull] private readonly Dictionary<string,IFactory<IBaseCommand>> _commands = new Dictionary<string, IFactory<IBaseCommand>>();

        public CommandConsoleProducer ([NotNull]List<IFactory<IBaseCommand>> commands)
        {
            commands.ForEach(x=>
            {
                Debug.Assert(x != null, nameof(x) + " != null");
                _commands.Add(x.GetCreatorName(), x);
            });
        }

       public IEnumerable<string> GetAvailableCommands()
        {
            return _commands.Keys ?? throw new ArgumentNullException();
        }

        public IBaseCommand GetCommand(string type)
        {
            return (type==null ? new NopeCommand() : _commands[type]?.CreateProduct()) ?? throw new ArgumentNullException();
        }
    }
}