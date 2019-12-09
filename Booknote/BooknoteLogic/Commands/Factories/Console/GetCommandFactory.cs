using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class GetCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        public GetCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Which record show? Type index");
            var index = System.Console.ReadLine();
            return new GetCommand(_booknote, index);
        }

        public string GetCreatorName()
        {
            return "Get";
        }
    }
}