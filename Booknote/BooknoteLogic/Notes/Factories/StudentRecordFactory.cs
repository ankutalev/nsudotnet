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
            if (name == null || phone == null)
            {
                throw new InvalidOperationException("Console input null!");
            }
            return new StudentRecord(name,phone);
        }

        public string GetCreatorName()
        {
            return "StudentRecord";
        }
    }
}