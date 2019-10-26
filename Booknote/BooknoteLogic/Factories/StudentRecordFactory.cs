using System;
using Attributes;
using BooknoteLogic.Notes;

namespace BooknoteLogic.Factories
{
    [ContainerElement]
    public class StudentRecordFactory : IBooknoteRecordFactory
    {
        public IBooknoteRecord CreateRecord()
        {
            Console.WriteLine("Write name!");
            var name = Console.ReadLine();
            Console.WriteLine("Write phone!");
            var phone = Console.ReadLine();
            return new StudentRecord(name,phone);
        }

        public string GeCreatorName()
        {
            return "StudentRecord";
        }
    }
}