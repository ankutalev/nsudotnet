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

        public StudentRecord(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public override string ToString()
        {
            return "Student name :" + Name + " It's' phone: " + Phone;
        }

        public bool Match(string searchPattern)
        {
            return Name.Contains(searchPattern) || Phone.Contains(searchPattern);
        }
    }
}