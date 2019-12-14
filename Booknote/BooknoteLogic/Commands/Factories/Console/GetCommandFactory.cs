using System;
using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class GetCommandFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly Booknote _booknote;

        public GetCommandFactory([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Which record show? Type index");
            var index = System.Console.ReadLine();
            return new GetCommand(_booknote, index ?? throw new InvalidOperationException("Console read null"));
        }

        public string GetCreatorName()
        {
            return "Get";
        }
    }
}