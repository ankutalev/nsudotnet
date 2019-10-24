using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class DeserializeCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        public DeserializeCommand(Booknote booknote)
        {
            _booknote = booknote;
        }

        public string NameToString() { return "Deserialize"; }
        public void Execute()
        {
            Console.WriteLine("Enter path to save file");
            var path = Console.ReadLine();
            _booknote.Deserialize(path);
        }
    }
}