using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class SerializeCommand : IBaseCommand
    {
        private readonly Booknote _booknote;

        public SerializeCommand(Booknote booknote)
        {
            _booknote = booknote;
        }

        public string NameToString()
        {
            return "Serialize";
        }

        public void Execute()
        {
            Console.WriteLine("Enter filename to serialize!");
            var fileName = Console.ReadLine();
            try
            {
                _booknote.Serialize(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Serialize error! See stacktrace " + e);
                throw;
            }
        }
    }
}