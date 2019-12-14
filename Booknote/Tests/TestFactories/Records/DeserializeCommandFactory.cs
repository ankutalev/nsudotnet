using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;

namespace Tests.TestFactories.Records
{
    [ContainerElement]
    public class DeserializeCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;
        public DeserializeCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            return new DeserializeCommand(_booknote, "test_serialize.json");
        }

        public string GetCreatorName()
        {
            { return "TestDeserialize"; }
        }
    }
}