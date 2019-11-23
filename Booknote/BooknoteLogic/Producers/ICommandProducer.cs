using System.Collections.Generic;
using BooknoteLogic.Commands;

namespace BooknoteLogic.Producers
{
    public interface ICommandProducer
    {
        IBaseCommand GetCommand(string name);
        IEnumerable<string> GetAvailableCommands();
    }
}