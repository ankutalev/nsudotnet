using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;

namespace BooknoteView.CommandsCreation.Factories.UI
{
    [ContainerElement]
    public class DeleteCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;
        private readonly RecordsList _rl;

        public DeleteCommandFactory(Booknote booknote,RecordsList rl)
        {
            _booknote = booknote;
            _rl = rl;
        }
        public IBaseCommand CreateProduct()
        {
            var deleted = _rl.getChoosen();
            return deleted != null ? (IBaseCommand) new DeleteCommand(_booknote, deleted) : new NopeCommand();
        }

        public string GetCreatorName()
        {
            return "UIDeleteCurrent";
        }
    }
}