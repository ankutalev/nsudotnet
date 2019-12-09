using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BooknoteView.CommandsCreation.Factories.UI.Notes
{
    public partial class CreationForm : Window
    {
        private readonly List<TextBox> _inputs;

        public CreationForm(IReadOnlyCollection<string> questions)
        {
            InitializeComponent();
            _inputs = new List<TextBox>(questions.Count);
            foreach (var question in questions)
            {
                var qLabel = new Label {Content = question};
                ContentLabels.Children.Add(qLabel);
                var textBox = new TextBox {MinWidth = 150, Margin = new Thickness(0, 10, 0, 10)};
                _inputs.Add(textBox);
                ContentLabels.Children.Add(textBox);
            }

            var wrapPanel = new WrapPanel
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 15, 0, 15)
            };
            var okButton = new Button
            {
                IsDefault = true, MinWidth = 60, Margin = new Thickness(0, 0, 10, 0), Content = "Ok"
            };
            okButton.Click += OkClick;
            wrapPanel.Children.Add(okButton);
            wrapPanel.Children.Add(new Button {IsCancel = true, MinWidth = 60, Content = "Cancel"});
            ContentLabels.Children.Add(wrapPanel);
        }

        public IEnumerable<string> GetInputs()
        {
            return _inputs.Select(x => x.Text);
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}