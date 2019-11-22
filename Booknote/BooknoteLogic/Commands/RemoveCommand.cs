using System;

namespace BooknoteLogic.Commands
{
    public class RemoveCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly string _index;

        public RemoveCommand(Booknote booknote, string index)
        {
            _booknote = booknote;
            _index = index;
        }

        public void Execute()
        {
            if (int.TryParse(_index, out var i))
                _booknote.Remove(i);
            else
                Console.WriteLine( _index + "Is not a integer!");
        }
    }
}