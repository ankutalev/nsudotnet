using System;
using System.Linq;
using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class ExitCommandFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly SerializeCommandFactory _sc;

        public ExitCommandFactory([NotNull]SerializeCommandFactory sc)
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

            var isExitNeed = readInput("Are you sure?") == "y";
            var isSaveNeeded = readInput("Save book?") == "y";
            return new ExitCommand(isExitNeed, isSaveNeeded ? _sc.CreateProduct() : null);
        }

        public string GetCreatorName()
        {
            return "Exit";
        }
    }
}