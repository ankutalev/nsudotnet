using System;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class SerializeCommand : BaseCommand
    {
        public SerializeCommand(Booknote booknote) : base(booknote)
        {
        }

        public override string ToString()
        {
            return "Serialize";
        }

        public override void Execute()
        {
            Console.WriteLine("Enter filename to serialize!");
            var fileName = Console.ReadLine();
            try
            {
                Bn.Serialize(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Serialize error! See stacktrace " + e);
                throw;
            }
        }
    }
}