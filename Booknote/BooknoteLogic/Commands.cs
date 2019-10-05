using System;
using System.Linq;
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
    
    [ContainerElement]
    public class ClearCommand : BaseCommand
    {
        public ClearCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Clear"; }

        public override void Execute()
        {
            Bn.Clear();
        }
    }

    [ContainerElement]
    public class ExitCommand : BaseCommand
    {
        private BaseCommand sc_;

        public ExitCommand(Booknote booknote, SerializeCommand sc) : base(booknote) { sc_ = sc; }

        public override string ToString() { return "Exit"; }
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
        public DeserializeCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Deserialize"; }
        public override void Execute()
        {
            Console.WriteLine("Enter path to save file");
            var path = Console.ReadLine();
            Bn.Deserialize(path);
        }
    }
    
    [ContainerElement]
    public class RemoveCommand : BaseCommand
    {
        public RemoveCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Remove"; }
        public override void Execute()
        {
            Console.WriteLine("Which record delete? Type index");
            var index = Console.ReadLine();
            if (int.TryParse(index, out var i))
                Bn.Remove(i);
            else
                Console.WriteLine("It's not a integer!");
        }
    }
    
    [ContainerElement]
    public class GetCommand : BaseCommand
    {
        public GetCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Get"; }
        public override void Execute()
        {
            Console.WriteLine("Which record show? Type index");
            var index = Console.ReadLine();
            try
            {
                var i = int.Parse(index);
                Console.WriteLine(Bn.Get(i));
            }
            catch (Exception )
            {
                Console.WriteLine("Invalid index given!");
            }
            
        }
    }
    
    [ContainerElement]
    public class SearchCommand : BaseCommand
    {
        public SearchCommand(Booknote booknote) : base(booknote) { }

        public override string ToString() { return "Search"; }
        public override void Execute()
        {
            Console.WriteLine("Enter search pattern:");
            var pattern = Console.ReadLine();
            var matched = Bn.Search(pattern);
            Console.WriteLine("Found records: ");
            foreach (var (i, booknoteRecord) in matched)
            {
                Console.WriteLine("{0} : {1}", i,booknoteRecord);
            }

        }
    }
}