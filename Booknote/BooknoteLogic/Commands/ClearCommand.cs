using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
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

        public string NameToString()
        {
            return "Clear";
        }
    }
}