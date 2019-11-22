namespace BooknoteLogic.Commands
{
    public class ClearCommand : IBaseCommand
    {
        private readonly Booknote _booknote;

        public ClearCommand(Booknote booknote)
        {
            _booknote = booknote;
        }

        public void Execute()
        {
            _booknote.Clear();
        }
    }
}