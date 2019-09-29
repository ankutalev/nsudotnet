using System;
using Attributes;

namespace BooknoteLogic {
    public abstract class BaseCommand
    {
        protected Booknote bn;
        public abstract void Execute();
        protected BaseCommand(Booknote booknote)
        {
            bn = booknote;
        }
    }

    [ContainerElement]
    public class WriteCommand : BaseCommand 
    {
        public WriteCommand(Booknote booknote) : base(booknote) {}

        public override void Execute() 
        {
            Console.WriteLine("Write command executes!");
        }
    }
    
    [ContainerElement]
    public class ReadCommand : BaseCommand 
    {
        public ReadCommand(Booknote booknote) : base(booknote) {}

        public override void Execute() 
        {
            bn.Read();
        }
    }
    
    [ContainerElement]
    public class ExecCommand : BaseCommand 
    {
        public ExecCommand(Booknote booknote) : base(booknote) {}

        public override void Execute() 
        {
            Console.WriteLine("exec command executes!");
        }
    }
}