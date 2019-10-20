using System;
using Attributes;

namespace BooknoteLogic.Notes
{
    [ContainerElement]
    public class StudentRecord : IBooknoteRecord
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        //for json.net
        public string Name;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public string Phone;
        
        public override string ToString()
        {
            return "Student name :" + Name + " It's' phone: " + Phone;
        }

        public bool Match(string searchPattern)
        {
            return Name.Contains(searchPattern) || Phone.Contains(searchPattern);
        }

        public void FillFields()
        {
            Console.WriteLine("Write name!");
            Name = Console.ReadLine();
            Console.WriteLine("Write phone!");
            Phone = Console.ReadLine();
        }

        public string GetRecordName()
        {
            return "StudentRecord";
        }
    }
}