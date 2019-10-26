using System;
using Attributes;
using BooknoteLogic.Notes;

namespace BooknoteLogic.Factories
{
    [ContainerElement]
    public class SimpleBooknoteRecordFactory : IBooknoteRecordFactory
    {
        public IBooknoteRecord CreateRecord()
        {
            Console.WriteLine("Type something!");
            var data = Console.ReadLine();
            return new SimpleBooknoteRecord(data);
        }

        public string GeCreatorName()
        {
            return "SimpleRecord";
        }
    }
}