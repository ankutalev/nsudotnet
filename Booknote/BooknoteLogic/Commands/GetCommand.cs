using System;

namespace BooknoteLogic.Commands
{
    public class GetCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly string _index;

        public GetCommand(Booknote booknote, string index)
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