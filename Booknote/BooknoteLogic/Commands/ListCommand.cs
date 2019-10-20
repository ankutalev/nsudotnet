using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class ListCommand : BaseCommand
    {
        public ListCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "List"; }

        public override void Execute()
        {
            var records = Bn.GetAllRecords();
            if (records.Count == 0)
            {
                Console.WriteLine("BookNote empty!");
                return;
            }

            for (var index = 0; index < records.Count; index++)
            {
                var record = records[index];
                Console.WriteLine("{0}: {1} ",index, record);
            }
        }
    }
}