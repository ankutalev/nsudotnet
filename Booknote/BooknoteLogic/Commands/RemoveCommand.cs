using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class RemoveCommand : BaseCommand
    {
        public RemoveCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Remove"; }
        public override void Execute()
        {
            Console.WriteLine("Which record delete? Type index");
            var index = Console.ReadLine();
            if (int.TryParse(index, out var i))
                Bn.Remove(i);
            else
                Console.WriteLine("It's not a integer!");
        }
    }
}