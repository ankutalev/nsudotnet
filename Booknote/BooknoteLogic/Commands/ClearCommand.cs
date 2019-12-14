using JetBrains.Annotations;

namespace BooknoteLogic.Commands
{
    public class ClearCommand : IBaseCommand
    {
       [NotNull] private readonly Booknote _booknote;

        public ClearCommand([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }

        public void Execute()
        {
            _booknote.Clear();
        }
    }
}