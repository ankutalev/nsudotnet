using System;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands
{
    public class DeleteCommand : IBaseCommand
    {
       [NotNull] private readonly Booknote _booknote;
        private readonly string _index;

        public DeleteCommand([NotNull]Booknote booknote, string index)
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