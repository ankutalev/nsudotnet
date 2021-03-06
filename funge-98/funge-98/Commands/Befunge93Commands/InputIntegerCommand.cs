using System.IO;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class InputIntegerCommand : Command
    {
        private readonly StreamReader _reader;

        public InputIntegerCommand(StreamReader reader)
        {
            _reader = reader;
        }

        public override char Name { get; } = '&';

        protected override string RealExecute(FungeContext fungeContext)
        {
            if (!int.TryParse(_reader.ReadLine(), out var value))
            {
                return "Can't parse Integer from user input!";
            }
            fungeContext.PushToTopStack(value);
            return null;
        }
    }
}