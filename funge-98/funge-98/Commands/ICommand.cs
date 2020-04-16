using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public interface ICommand
    {
        bool Execute(FungeContext fungeContext);
        char GetName();
    }
}