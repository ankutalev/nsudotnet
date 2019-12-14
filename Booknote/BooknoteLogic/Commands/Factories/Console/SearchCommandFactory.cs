using System;
using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class SearchCommandFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly Booknote _booknote;

        public SearchCommandFactory([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Enter search pattern:");
            var pattern = System.Console.ReadLine();
            return new SearchCommand(_booknote,pattern ?? throw new InvalidOperationException("Console input null"));
        }

        public string GetCreatorName()
        {
            return "Search";
        }
    }
}