using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class DeserializeCommand : BaseCommand
    {
        public DeserializeCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Deserialize"; }
        public override void Execute()
        {
            Console.WriteLine("Enter path to save file");
            var path = Console.ReadLine();
            Bn.Deserialize(path);
        }
    }
}