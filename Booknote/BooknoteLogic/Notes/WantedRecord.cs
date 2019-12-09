using Attributes;

namespace BooknoteLogic.Notes
{
    [ContainerElement]
    public class WantedRecord : IBooknoteRecord
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        //for json.net
        public string Name;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public string LastName;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public string SpecialSigns;

        public WantedRecord(string name, string lastName, string specialSigns)
        {
            Name = name;
            LastName = lastName;
            SpecialSigns = specialSigns;
        }

        public override string ToString()
        {
            return $"Wanted {Name}  {LastName}. Special signs : {SpecialSigns}"; 
        }

        public bool Match(string searchPattern)
        {
            return Name.Contains(searchPattern) || LastName.Contains(searchPattern) || SpecialSigns.Contains(searchPattern);
        }
    }
}