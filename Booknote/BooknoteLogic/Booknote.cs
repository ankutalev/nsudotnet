using System;
using System.Collections.Generic;
using Attributes;

namespace BooknoteLogic
{
    [ContainerElement]
    public class Booknote
    {
        public void Read()
        {
            Console.WriteLine("Read in booknote!");
        }

        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public List<BooknoteRecord> GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}