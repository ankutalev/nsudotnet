namespace BooknoteLogic

{
    public abstract class BooknoteRecord
    {
        public  abstract bool Match(string searchPattern);
    }

    public class SimpleBooknoteRecord : BooknoteRecord
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        //for json.net
        public string Data;
        public SimpleBooknoteRecord(string data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data;
        }

        public override bool Match(string searchPattern)
        {
            return Data.Contains(searchPattern);
        }
    }
    public class StudentRecord : BooknoteRecord
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

        public override bool Match(string searchPattern)
        {
            return Name.Contains(searchPattern) || Phone.Contains(searchPattern);
        }
    }
    
}