using System.Collections.Generic;
using funge_98.Commands;

namespace funge_98.ExecutionContexts
{
    public abstract class FungeContext
    {
        private readonly HashSet<char> _supportedCommands;
        
        protected FungeContext(HashSet<char> supportedCommands1)
        {
            _supportedCommands = supportedCommands1;
        }
        
        bool IsSupported(ICommand command)
        {
            return _supportedCommands.Contains(command.GetName());
        }
    }
}