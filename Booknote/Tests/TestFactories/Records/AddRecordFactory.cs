using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;
using BooknoteLogic.Notes;

namespace Tests.TestFactories.Records
{
    [ContainerElement]
    public class AddRecordFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        private readonly Dictionary<string, IFactory<IBooknoteRecord>> _records;


        public AddRecordFactory(Booknote booknote, List<IFactory<IBooknoteRecord>> recordTypes)
        {
            _booknote = booknote;
            _records = new Dictionary<string, IFactory<IBooknoteRecord>>(recordTypes.Count);
            foreach (var factory in recordTypes)
            {
                var name = factory.GetCreatorName();
                if (name.StartsWith("Test"))
                {
                    _records.Add(name,factory);
                }
            }
        }

        public IBaseCommand CreateProduct()
        {
            var r = new Random();
            var creator = _records.ElementAt(r.Next(0, _records.Count)).Value;
            var record = creator.CreateProduct();
            return new AddRecordCommand(_booknote, record);
        }

        public string GetCreatorName()
        {
            return "TestAddRecord";
        }
    }
}