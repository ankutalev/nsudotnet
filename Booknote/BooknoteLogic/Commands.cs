using System;
using System.Linq;
using System.Net.Mime;
using Attributes;

namespace BooknoteLogic
{
    public abstract class BaseCommand
    {
        protected readonly Booknote Bn;
        public abstract void Execute();

        protected BaseCommand(Booknote booknote)
        {
            Bn = booknote;
        }
    }

    [ContainerElement]
    public class WriteCommand : BaseCommand
    {
        public WriteCommand(Booknote booknote) : base(booknote)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Write command executes!");
        }
    }

    [ContainerElement]
    public class SerializeCommand : BaseCommand
    {
        public SerializeCommand(Booknote booknote) : base(booknote)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Serialize command executes!");
        }
    }

    [ContainerElement]
    public class ListCommand : BaseCommand
    {
        public ListCommand(Booknote booknote) : base(booknote)
        {
        }

        public override void Execute()
        {
            var records = Bn.GetAllRecords();
            if (records.Count == 0)
            {
                Console.WriteLine("BookNote empty!");
                return;
            }
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }
    }

    [ContainerElement]
    public class ExitCommand : BaseCommand
    {
        private BaseCommand sc_;

        public ExitCommand(Booknote booknote, SerializeCommand sc) : base(booknote)
        {
            sc_ = sc;
        }

        public override void Execute()
        {
            var answers = new[] {"y", "n"};

            var readInput = new Func<string, string>(message =>
            {
                string userAnswer;
                do
                {
                    Console.WriteLine(message + " y/n");
                    userAnswer = Console.ReadLine();
                } while (!answers.Contains(userAnswer));

                return userAnswer;
            });

            var isExitReallyNeeded = readInput("Are you sure?");
            if (isExitReallyNeeded == "n")
                return;

            var isSaveNeeded = readInput("Save book?");
            if (isSaveNeeded == "y")
                sc_.Execute();
            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }
    }

    [ContainerElement]
    public class DeserializeCommand : BaseCommand
    {
        public DeserializeCommand(Booknote booknote) : base(booknote)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("Deserialize command executes!");
        }
    }


    [ContainerElement]
    public class ReadCommand : BaseCommand
    {
        public ReadCommand(Booknote booknote) : base(booknote)
        {
        }

        public override void Execute()
        {
            Bn.Read();
        }
    }

    [ContainerElement]
    public class ExecCommand : BaseCommand
    {
        public ExecCommand(Booknote booknote) : base(booknote)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("exec command executes!");
        }
    }
}