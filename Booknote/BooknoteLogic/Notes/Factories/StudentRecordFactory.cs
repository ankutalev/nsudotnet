using System;
using Attributes;

namespace BooknoteLogic.Notes.Factories
{
    [ContainerElement]
    public class StudentRecordFactory : IFactory<IBooknoteRecord>
    {
        public IBooknoteRecord CreateProduct()
        {
            Console.WriteLine("Write name!");
            var name = Console.ReadLine();
            Console.WriteLine("Write phone!");
            var phone = Console.ReadLine();
            return new StudentRecord(name,phone);
        }

        public string GetCreatorName()
        {
            return "StudentRecord";
        }
    }
}