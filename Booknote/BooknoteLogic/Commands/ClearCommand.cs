using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class ClearCommand : BaseCommand
    {
        public ClearCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Clear"; }

        public override void Execute()
        {
            Bn.Clear();
        }
    }
}