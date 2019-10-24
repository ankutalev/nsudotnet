using System;
using System.Collections.Generic;
using Attributes;
using BooknoteLogic.Notes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class AddRecordCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly Dictionary<string, IBooknoteRecord> _records =  new Dictionary<string, IBooknoteRecord>();
        public AddRecordCommand(Booknote booknote, List<IBooknoteRecord> recordTypes)
        {
            _booknote = booknote;
            recordTypes.ForEach(record=>_records.Add(record.GetRecordName(), record));
        }

        public string NameToString()
        {
            return "AddRecord";
        }

        public void Execute()
        {
            Console.WriteLine("Available records type :");
            foreach (var recordKey in _records.Keys)
            {
                Console.WriteLine(recordKey);
            }
            Console.WriteLine("Enter record type to add it to notebook");
            try
            {
                var record = _records[Console.ReadLine()];
                record.FillFields();
                _booknote.Add(record);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Unknown booknote type!");
            }
        }
    }
}