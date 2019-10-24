using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class GetCommand : IBaseCommand
    {
        private readonly Booknote _booknote;

        public GetCommand(Booknote booknote)
        {
            _booknote = booknote;
        }

        public string NameToString()
        {
            return "Get";
        }

        public void Execute()
        {
            Console.WriteLine("Which record show? Type index");
            var index = Console.ReadLine();
            try
            {
                var i = int.Parse(index);
                Console.WriteLine(_booknote.Get(i));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid index given!");
            }
        }
    }
}