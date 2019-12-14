using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;

namespace Tests.TestFactories.Records
{
    [ContainerElement]
    public class SerializeCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        public SerializeCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            return new SerializeCommand(_booknote,"test_serialize.json");
        }

        public string GetCreatorName()
        {
            return "TestSerialize";
        }
    }
}