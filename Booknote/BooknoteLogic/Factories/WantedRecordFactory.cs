using System;
using Attributes;
using BooknoteLogic.Notes;

namespace BooknoteLogic.Factories
{
    [ContainerElement]
    public class WantedRecordFactory : IBooknoteRecordFactory
    {
        public IBooknoteRecord CreateRecord()
        {
            Console.WriteLine("Write name!");
            var name = Console.ReadLine();
            Console.WriteLine("Write Lastname!");
            var lastName = Console.ReadLine();
            Console.WriteLine("Special signs??");
            var specialSigns = Console.ReadLine();
            return new WantedRecord(name, lastName, specialSigns);
        }

        public string GeCreatorName()
        {
            return "WantedRecord";
        }
    }
}