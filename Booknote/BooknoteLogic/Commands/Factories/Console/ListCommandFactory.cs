using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class ListCommandFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly Booknote _booknote;

        public ListCommandFactory([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            return new ListCommand(_booknote.GetAllRecords());
        }

        public string GetCreatorName()
        {
            return "List";
        }
    }
}