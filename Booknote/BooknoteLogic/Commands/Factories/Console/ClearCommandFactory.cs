using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class ClearCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        public ClearCommandFactory(Booknote booknote)
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