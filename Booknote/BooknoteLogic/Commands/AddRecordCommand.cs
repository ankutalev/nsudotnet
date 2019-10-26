using System;
using System.Collections.Generic;
using Attributes;
using BooknoteLogic.Factories;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class AddRecordCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly Dictionary<string, IBooknoteRecordFactory> _records =  new Dictionary<string, IBooknoteRecordFactory>();
        public AddRecordCommand(Booknote booknote, List<IBooknoteRecordFactory> recordTypes)
        {
            _booknote = booknote;
            recordTypes.ForEach(record=>_records.Add(record.GeCreatorName(), record));
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
                var creator = _records[Console.ReadLine()];
                _booknote.Add(creator.CreateRecord());
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Unknown booknote type!");
            }
        }
    }
}