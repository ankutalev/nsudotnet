using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class RemoveCommand : IBaseCommand
    {
        private readonly Booknote _booknote;

        public RemoveCommand(Booknote booknote)
        {
            _booknote = booknote;
        }

        public string NameToString()
        {
            return "Remove";
        }

        public void Execute()
        {
            Console.WriteLine("Which record delete? Type index");
            var index = Console.ReadLine();
            if (int.TryParse(index, out var i))
                _booknote.Remove(i);
            else
                Console.WriteLine("It's not a integer!");
        }
    }
}