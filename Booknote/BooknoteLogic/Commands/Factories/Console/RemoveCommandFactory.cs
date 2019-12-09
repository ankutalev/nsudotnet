using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
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
            System.Console.WriteLine("Which record delete? Type index");
            var index = System.Console.ReadLine();
            return new RemoveCommand(_booknote, index);
        }

        public string GetCreatorName()
        {
            return "Remove";
        }
    }
}