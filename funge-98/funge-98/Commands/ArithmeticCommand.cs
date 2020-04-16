using System;
using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public class ArithmeticCommand : Command
    {
        private readonly Func<int, int, int> _func;

        public ArithmeticCommand(Func<int, int, int> func, char name)
        {
            _func = func;
            Name = name;
        }
        
        public override char Name { get; }

        protected override string RealExecute(FungeContext fungeContext)
        {
            if (fungeContext.GetStackTopValues(2, out var values))
            {
                return "Stack empty!";
            }

            try
            {
                fungeContext.PushToStack(_func(values[1], values[0]));
            }
            catch (DivideByZeroException)
            {
                return "Divided by zero!";
            }

            return null;
        }
    }
}