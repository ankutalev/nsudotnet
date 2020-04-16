using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class KillThreadCommand : Command
    {
        public KillThreadCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.StopCurrentThread();
            return null;
        }
    }
}