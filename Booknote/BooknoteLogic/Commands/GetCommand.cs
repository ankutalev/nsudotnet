using System;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands
{
    public class GetCommand : IBaseCommand
    {
        [NotNull]private readonly Booknote _booknote;
        [NotNull]private readonly string _index;

        public GetCommand([NotNull]Booknote booknote, [NotNull]string index)
        {
            _booknote = booknote;
            _index = index;
        }

        public void Execute()
        {
            try
            {
                var i = int.Parse(_index);
                Console.WriteLine(_booknote.Get(i));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid index given!");
            }
        }
    }
}