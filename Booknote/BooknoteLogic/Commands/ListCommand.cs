using System;
using System.Collections.Generic;
using BooknoteLogic.Notes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands
{
    public class ListCommand : IBaseCommand
    {
       [NotNull] private readonly List<IBooknoteRecord> _records;

        public ListCommand([NotNull]List<IBooknoteRecord> records)
        {
            _records = records;
        }

        public void Execute()
        {
            if (_records.Count == 0)
            {
                Console.WriteLine("BookNote empty!");
                return;
            }

            for (var index = 0; index < _records.Count; index++)
            {
                var record = _records[index];
                Console.WriteLine("{0}: {1} ", index, record);
            }
        }
    }
}