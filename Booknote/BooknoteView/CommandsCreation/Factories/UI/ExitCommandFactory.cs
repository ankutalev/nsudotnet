using System;
using System.Linq;
using System.Windows;
using Attributes;
using BooknoteLogic;
using BooknoteLogic.Commands;


namespace BooknoteView.CommandsCreation.Factories.UI
{
    [ContainerElement]
    public class ExitCommandFactory : IFactory<IBaseCommand>
    {
        private readonly SerializeCommandFactory sc_;

        public ExitCommandFactory(SerializeCommandFactory sc)
        {
            sc_ = sc;
        }

        public IBaseCommand CreateProduct()
        {
            var exitMessage = MessageBox.Show("Are you sure?",
                "Confirm exit",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            bool isExitNeed = exitMessage == MessageBoxResult.Yes;
            bool isSaveNeed = false;
            if (isExitNeed)
            {
                isSaveNeed = MessageBox.Show("Wanna save?",
                                 "Save file",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Question) == MessageBoxResult.Yes;
            }

            return new ExitCommand(isExitNeed, isSaveNeed ? sc_.CreateProduct() : null);
        }

        public string GetCreatorName()
        {
            return "UIExit";
        }
    }
}