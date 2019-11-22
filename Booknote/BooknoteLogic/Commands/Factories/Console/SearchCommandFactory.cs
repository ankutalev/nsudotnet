using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class SearchCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        public SearchCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateRecord()
        {
            System.Console.WriteLine("Enter search pattern:");
            var pattern = System.Console.ReadLine();
            return new SearchCommand(_booknote,pattern);
        }

        public string GetCreatorName()
        {
            return "Search";
        }
    }
}