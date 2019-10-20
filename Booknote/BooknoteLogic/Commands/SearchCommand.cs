using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class SearchCommand : BaseCommand
    {
        public SearchCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Search"; }
        public override void Execute()
        {
            Console.WriteLine("Enter search pattern:");
            var pattern = Console.ReadLine();
            var matched = Bn.Search(pattern);
            Console.WriteLine("Found records: ");
            foreach (var (i, booknoteRecord) in matched)
            {
                Console.WriteLine("{0} : {1}", i,booknoteRecord);
            }

        }
    }
}