using System;
using Attributes;

namespace BooknoteLogic.Notes.Factories
{
    [ContainerElement]
    public class SimpleBooknoteRecordFactory : IFactory<IBooknoteRecord>
    {
        public IBooknoteRecord CreateRecord()
        {
            Console.WriteLine("Type something!");
            var data = Console.ReadLine();
            return new SimpleBooknoteRecord(data);
        }

        public string GetCreatorName()
        {
            return "SimpleRecord";
        }
    }
}