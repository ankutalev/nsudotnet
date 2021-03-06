using Attributes;
using JetBrains.Annotations;

namespace BooknoteLogic.Commands.Factories.Console
{
    [ContainerElement]
    public class RemoveCommandFactory : IFactory<IBaseCommand>
    {
        [NotNull]private readonly Booknote _booknote;

        public RemoveCommandFactory([NotNull]Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateProduct()
        {
            System.Console.WriteLine("Which record delete? Type index");
            var index = System.Console.ReadLine();
            return new DeleteCommand(_booknote, index);
        }

        public string GetCreatorName()
        {
            return "Remove";
        }
    }
}