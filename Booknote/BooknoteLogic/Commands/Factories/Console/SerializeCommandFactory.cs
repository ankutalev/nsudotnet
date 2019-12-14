using System;
using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class SerializeCommandFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly Booknote _booknote;

        public SerializeCommandFactory([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Enter filename to serialize!");
            var fileName = System.Console.ReadLine();
            return new SerializeCommand(_booknote,fileName ?? throw new InvalidOperationException("Console input null"));
        }

        public string GetCreatorName()
        {
            return "Serialize";
        }
    }
}