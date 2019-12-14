using System;
using System.Collections.Generic;
using BooknoteLogic.Notes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands
{
    public class SearchCommand : IBaseCommand
    {
        [NotNull]private readonly Booknote _booknote;
        [NotNull]private readonly string _pattern;
         public Dictionary<int, IBooknoteRecord> Matched { get; private set; }

        public SearchCommand([NotNull]Booknote booknote, [NotNull]string pattern)
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