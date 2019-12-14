using System;
using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Notes
{
    [ContainerElement]
    public class SimpleBooknoteRecord : IBooknoteRecord
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        //for json.net
        [NotNull]public string Data;

        public SimpleBooknoteRecord([NotNull]string data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data;
        }

        public bool Match(string searchPattern)
        {
            return Data.Contains(searchPattern ?? throw new ArgumentNullException(nameof(searchPattern)));
        }
    }
}