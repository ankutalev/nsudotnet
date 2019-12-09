using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BooknoteView.CommandsCreation.Factories.UI
{
    public partial class RecordTypeChooser
    {
        private string _choosenName;

        public RecordTypeChooser(IEnumerable<string> names)
        {
            InitializeComponent();
            foreach (var name in names)
            {
                var button = new Button {Content = name, Margin = new Thickness(0,10,0,10)};
                button.Click += (a, b) =>
                {
                    _choosenName = (string) button.Content;
                    DialogResult = true;
                    Close();
                };
                Buttons.Children.Add(button);
            }
        }
        public string GetInput()
        {
            return _choosenName;
        }
    }
}