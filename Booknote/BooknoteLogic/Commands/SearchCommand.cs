using System;
using System.Collections.Generic;
using BooknoteLogic.Notes;

namespace BooknoteLogic.Commands
{
    public class SearchCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly string _pattern;
         public Dictionary<int, IBooknoteRecord> Matched { get; private set; }

        public SearchCommand(Booknote booknote, string pattern)
        {
            _booknote = booknote;
            _pattern = pattern;
        }
        

        public void Execute()
        {
            Matched = _booknote.Search(_pattern);
            Console.WriteLine("Found records: ");
            foreach (var (i, booknoteRecord) in Matched)
            {
                Console.WriteLine("{0} : {1}", i, booknoteRecord);
            }
        }
    }
}