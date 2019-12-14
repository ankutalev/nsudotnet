using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Notes
{
    [ContainerElement]
    public class WantedRecord : IBooknoteRecord
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        //for json.net
       [NotNull] public string Name;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
       [NotNull] public string LastName;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        [NotNull]public string SpecialSigns;

        public WantedRecord([NotNull]string name, [NotNull]string lastName, [NotNull]string specialSigns)
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
            if (searchPattern == null)
                return true;
            return Name.Contains(searchPattern) || LastName.Contains(searchPattern) || SpecialSigns.Contains(searchPattern);
        }
    }
}