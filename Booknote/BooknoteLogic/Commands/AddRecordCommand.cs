using System;
using BooknoteLogic.Notes;

namespace BooknoteLogic.Commands
{
    public class AddRecordCommand : IBaseCommand
    {
        private readonly Booknote _booknote;
        private readonly IBooknoteRecord _record;

        public AddRecordCommand(Booknote booknote, IBooknoteRecord record)
        {
            _booknote = booknote;
            _record = record;
        }

        public void Execute()
        {
            if (_record is null)
            {
                Console.WriteLine("Invalid Record type!");
                return;
            }
            _booknote.Add(_record);
        }
    }
}