using System;
using Attributes;

namespace BooknoteLogic.Notes.Factories
{
    [ContainerElement]
    public class WantedRecordFactory : IFactory<IBooknoteRecord>
    {
        public IBooknoteRecord CreateProduct()
        {
            Console.WriteLine("Write name!");
            var name = Console.ReadLine();
            Console.WriteLine("Write Lastname!");
            var lastName = Console.ReadLine();
            Console.WriteLine("Special signs??");
            var specialSigns = Console.ReadLine();
            if (name == null || lastName == null || specialSigns == null)
                throw new InvalidOperationException("Console returns null!");
            return new WantedRecord(name, lastName, specialSigns);
        }

        public string GetCreatorName()
        {
            return "WantedRecord";
        }
    }
}