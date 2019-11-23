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
            if (openFileDialog.ShowDialog() ==true)
                return new DeserializeCommand(_booknote,openFileDialog.FileName);
            return new NopeCommand();
        }

        public string GetCreatorName()
        {
            { return "UIDeserialize"; }
        }
    }
}