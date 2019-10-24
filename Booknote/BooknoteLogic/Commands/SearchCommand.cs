using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class SearchCommand : IBaseCommand
    {
        private readonly Booknote _booknote;

        public SearchCommand(Booknote booknote)
        {
            _booknote = booknote;
        }

        public string NameToString()
        {
            return "Search";
        }

        public void Execute()
        {
            Console.WriteLine("Enter search pattern:");
            var pattern = Console.ReadLine();
            var matched = _booknote.Search(pattern);
            Console.WriteLine("Found records: ");
            foreach (var (i, booknoteRecord) in matched)
            {
                Console.WriteLine("{0} : {1}", i, booknoteRecord);
            }
        }
    }
}