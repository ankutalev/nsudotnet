using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;
using Microsoft.Win32;

namespace BooknoteView.CommandsCreation.Factories.UI
{
    [ContainerElement]
    public class SerializeCommandFactory : IFactory<IBaseCommand>
    {
        private readonly Booknote _booknote;

        public SerializeCommandFactory(Booknote booknote)
        {
            _booknote = booknote;
        }

        public IBaseCommand CreateRecord()
        {
            var openFileDialog = new SaveFileDialog();
            if (openFileDialog.ShowDialog() == true)
                return new SerializeCommand(_booknote, openFileDialog.FileName);
            return new NopeCommand();
        }

        public string GetCreatorName()
        {
            return "UISerialize";
        }
    }
}