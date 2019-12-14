using System;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands
{
    public class SerializeCommand : IBaseCommand
    {
       [NotNull] private readonly Booknote _booknote;
       [NotNull] private readonly string _filename;

        public SerializeCommand([NotNull]Booknote booknote,[NotNull]string filename)
        {
            _booknote = booknote;
            _filename = filename;
        }
        public void Execute()
        {
            try
            {
                _booknote.Serialize(_filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Serialize error! See stacktrace " + e);
                throw;
            }
        }
    }
}