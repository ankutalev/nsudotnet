using System;
using System.Linq;
using Attributes;

namespace BooknoteLogic.Commands
{
    [ContainerElement]
    public class ExitCommand : IBaseCommand
    {
        private readonly IBaseCommand sc_;

        public ExitCommand(SerializeCommand sc)
        {
            sc_ = sc;
        }

        public string NameToString()
        {
            return "Exit";
        }

        public void Execute()
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
}