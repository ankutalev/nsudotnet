namespace BooknoteLogic.Commands
{
    public abstract class BaseCommand
    {
        protected readonly Booknote Bn;
        public abstract void Execute();
        public abstract override string ToString();

        protected BaseCommand(Booknote booknote)
        {
            Bn = booknote;
        }
    }
}