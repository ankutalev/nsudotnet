using System.Collections.Generic;
using BooknoteLogic.Commands;
using JetBrains.Annotations;

namespace BooknoteLogic.Producers
{
    public interface ICommandProducer
    {
        [NotNull]IBaseCommand GetCommand(string name);
        [NotNull] IEnumerable<string> GetAvailableCommands();
    }
}