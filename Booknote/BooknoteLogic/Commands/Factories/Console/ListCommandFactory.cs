using Attributes;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class ListCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        public ListCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateRecord()
        {
            return new ListCommand(_booknote.GetAllRecords());
        }

        public string GetCreatorName()
        {
            return "List";
        }
    }
}