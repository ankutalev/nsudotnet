using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class DeserializeCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;
        public DeserializeCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateRecord()
        {
            System.Console.WriteLine("Enter path to save file");
            var path = System.Console.ReadLine();
            return new DeserializeCommand(_booknote, path);
        }

        public string GetCreatorName()
        {
            { return "Deserialize"; }
        }
    }
}