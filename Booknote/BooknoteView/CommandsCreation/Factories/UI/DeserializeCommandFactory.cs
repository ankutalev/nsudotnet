using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;
using Microsoft.Win32;

namespace BooknoteView.CommandsCreation.Factories.UI
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
            var openFileDialog = new OpenFileDialog();
            return openFileDialog.ShowDialog() == true ? new DeserializeCommand(_booknote,openFileDialog.FileName) : null;
        }

        public string GetCreatorName()
        {
            { return "UIDeserialize"; }
        }
    }
}