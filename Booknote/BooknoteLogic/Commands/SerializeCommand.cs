using System;

namespace BooknoteLogic.Commands
{
    public class SerializeCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly string _filename;

        public SerializeCommand(Booknote booknote,string filename)
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