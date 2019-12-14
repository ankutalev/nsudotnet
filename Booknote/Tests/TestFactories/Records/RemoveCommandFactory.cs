using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;

namespace Tests.TestFactories.Records
{
    [ContainerElement]
    public class RemoveCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        public RemoveCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            return new DeleteCommand(_booknote, "0");
        }

        public string GetCreatorName()
        {
            return "TestRemove";
        }
    }
}