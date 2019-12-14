using System;
using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class DeserializeCommandFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly Booknote _booknote;
        public DeserializeCommandFactory([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Enter path to save file");
            var path = System.Console.ReadLine();
            if (path==null)
                throw new InvalidOperationException("Console read null");
            return new DeserializeCommand(_booknote, path);
        }

        public string GetCreatorName()
        {
            { return "Deserialize"; }
        }
    }
}