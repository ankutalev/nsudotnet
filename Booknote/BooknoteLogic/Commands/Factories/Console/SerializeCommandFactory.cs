using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
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
            System.Console.WriteLine("Enter filename to serialize!");
            var fileName = System.Console.ReadLine();
            return new SerializeCommand(_booknote,fileName);
        }

        public string GetCreatorName()
        {
            return "Serialize";
        }
    }
}