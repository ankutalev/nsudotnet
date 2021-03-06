using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class ClearCommandFactory : IFactory<IBaseCommand>
    {
       [NotNull] private readonly Booknote _booknote;

        public ClearCommandFactory([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }
        public IBaseCommand CreateProduct()
        {
            return new ClearCommand(_booknote);
        }

        public string GetCreatorName()
        {
            return "Clear";
        }
    }
}