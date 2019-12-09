using System.Collections.Generic;
using Attributes;
using BooknoteLogic.Notes;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class AddRecordConsoleFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        private readonly Dictionary<string, IFactory<IBooknoteRecord>> _records;


        public AddRecordConsoleFactory(Booknote booknote, List<IFactory<IBooknoteRecord>> recordTypes)
        {
            _booknote = booknote;
            _records = new Dictionary<string, IFactory<IBooknoteRecord>>(recordTypes.Count);
            recordTypes.ForEach(record => _records.Add(record.GetCreatorName(), record));
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Available records type :");
            foreach (var recordKey in _records.Keys)
            {
                System.Console.WriteLine(recordKey);
            }

            System.Console.WriteLine("Enter record type to add it to notebook");
            IBooknoteRecord record = null;
            try
            {
                var creator = _records[System.Console.ReadLine()];
                record = creator.CreateProduct();
            }
            catch (KeyNotFoundException)
            {
                System.Console.WriteLine("Unknown booknote type!");
            }

            return new AddRecordCommand(_booknote, record);
        }

        public string GetCreatorName()
        {
            return "AddRecord";
        }
    }
}