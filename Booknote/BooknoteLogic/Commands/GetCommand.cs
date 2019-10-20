using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class GetCommand : BaseCommand
    {
        public GetCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Get"; }
        public override void Execute()
        {
            Console.WriteLine("Which record show? Type index");
            var index = Console.ReadLine();
            try
            {
                var i = int.Parse(index);
                Console.WriteLine(Bn.Get(i));
            }
            catch (Exception )
            {
                Console.WriteLine("Invalid index given!");
            }
            
        }
    }
}