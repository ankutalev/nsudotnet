using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class AddRecordCommand : BaseCommand
    {
        public AddRecordCommand(Booknote booknote) : base(booknote)
        {
        }

        public override string ToString()
        {
            return "AddSimpleRecord";
        }

        public override void Execute()
        {
            Console.WriteLine("Write something!");
            var smth = Console.ReadLine();
            var record = new SimpleBooknoteRecord(smth);
            Bn.Add(record);
        }
    }
}