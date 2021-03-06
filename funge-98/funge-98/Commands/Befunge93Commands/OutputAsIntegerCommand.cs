using System.IO;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class OutputAsIntegerCommand : Command
    {
        private readonly StreamWriter _writer;

        public OutputAsIntegerCommand(StreamWriter writer)
        {
            _writer = writer;
        }

        public override char Name { get; } = '.';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(1);
            _writer.Write(values[0]);
            return null;
        }
    }
}