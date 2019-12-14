using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Notes
{
    [ContainerElement]
    public class StudentRecord : IBooknoteRecord
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        //for json.net
      [NotNull]  public string Name;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        [NotNull]public string Phone;

        public StudentRecord([NotNull]string name, [NotNull]string phone)
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
            if (searchPattern == null)
                return true;
            return Name.Contains(searchPattern) || Phone.Contains(searchPattern);
        }
    }
}