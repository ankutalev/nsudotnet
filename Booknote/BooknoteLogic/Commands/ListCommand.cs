using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class ListCommand : IBaseCommand
    {
        private readonly Booknote _booknote;

        public ListCommand(Booknote booknote)
        {
            _booknote = booknote;
        }

        public string NameToString()
        {
            return "List";
        }

        public void Execute()
        {
            var records = _booknote.GetAllRecords();
            if (records.Count == 0)
            {
                Console.WriteLine("BookNote empty!");
                return;
            }

            for (var index = 0; index < records.Count; index++)
            {
                var record = records[index];
                Console.WriteLine("{0}: {1} ", index, record);
            }
        }
    }
}