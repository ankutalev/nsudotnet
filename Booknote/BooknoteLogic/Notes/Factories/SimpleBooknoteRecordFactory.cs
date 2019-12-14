using System;
using Attributes;

namespace BooknoteLogic.Notes.Factories
{
    [ContainerElement]
    public class SimpleBooknoteRecordFactory : IFactory<IBooknoteRecord>
    {
        public IBooknoteRecord CreateProduct()
        {
            Console.WriteLine("Type something!");
            var data = Console.ReadLine();
            return new SimpleBooknoteRecord(data ?? throw new InvalidOperationException("Console input null!"));
        }

        public string GetCreatorName()
        {
            return "SimpleRecord";
        }
    }
}