using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class AddStudentRecordCommand : BaseCommand
    {
        public AddStudentRecordCommand(Booknote booknote) : base(booknote)
        {
        }

        public override string ToString()
        {
            return "AddStudentRecord";
        }

        public override void Execute()
        {
            Console.WriteLine("Write name!");
            var name = Console.ReadLine();
            Console.WriteLine("Write phone!");
            var phone = Console.ReadLine();
            var record = new StudentRecord(name,phone);
            Bn.Add(record);
        }
    }
}