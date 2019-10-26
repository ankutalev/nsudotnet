using System;
using Attributes;

namespace BooknoteLogic.Notes
{
    [ContainerElement]
    public class SimpleBooknoteRecord : IBooknoteRecord
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

        public bool Match(string searchPattern)
        {
            return Data.Contains(searchPattern);
        }
    }
}