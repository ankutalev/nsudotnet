using System;
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
    }
}