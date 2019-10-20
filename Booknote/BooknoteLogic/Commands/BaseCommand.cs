namespace BooknoteLogic.Commands
{
    public abstract class BaseCommand
    {
        protected readonly Booknote Bn;
        public abstract void Execute();
        
        protected BaseCommand(Booknote booknote)
        {
            Bn = booknote;
        }
    }
}