using System.Collections.Generic;
using System.Diagnostics;
using Attributes;
using BooknoteLogic.Notes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class AddRecordConsoleFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly Booknote _booknote;

        [NotNull]private readonly Dictionary<string, IFactory<IBooknoteRecord>> _records;


        public AddRecordConsoleFactory([NotNull]Booknote booknote, [NotNull]List<IFactory<IBooknoteRecord>> recordTypes)
        {
            _booknote = booknote;
            _records = new Dictionary<string, IFactory<IBooknoteRecord>>(recordTypes.Count);
            recordTypes.ForEach(record =>
            {
                Debug.Assert(record != null, nameof(record) + " != null");
                _records.Add(record.GetCreatorName(), record);
            });
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Available records type :");
            Debug.Assert(_records.Keys != null, "_records.Keys != null");
            foreach (var recordKey in _records.Keys)
            {
                System.Console.WriteLine(recordKey);
            }

            System.Console.WriteLine("Enter record type to add it to notebook");
            IBooknoteRecord record = null;
            try
            {
                var line = System.Console.ReadLine();
                if (line==null)
                    return new NopeCommand();
                var creator = _records[line];
                record = creator?.CreateProduct();
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