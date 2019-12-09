using System;
using System.Linq;
using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class ExitCommandFactory : IFactory<IBaseCommand>
    {
        private readonly SerializeCommandFactory _sc;

        public ExitCommandFactory(SerializeCommandFactory sc)
        {
            _sc = sc;
        }

        public IBaseCommand CreateProduct()
        {
            var answers = new[] {"y", "n"};

            var readInput = new Func<string, string>(message =>
            {
                string userAnswer;
                do
                {
                    System.Console.WriteLine(message + " y/n");
                    userAnswer = System.Console.ReadLine();
                } while (!answers.Contains(userAnswer));

                return userAnswer;
            });

            bool isExitNeed = readInput("Are you sure?") == "y";
            var isSaveNeeded = readInput("Save book?") == "y";
            return new ExitCommand(isExitNeed, isSaveNeeded ? _sc.CreateProduct() : null);
        }

        public string GetCreatorName()
        {
            return "Exit";
        }
    }
}