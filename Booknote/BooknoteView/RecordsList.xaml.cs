using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Attributes;
using BooknoteLogic;

namespace BooknoteView
{
    [ContainerElement]
    public partial class RecordsList
    {
        private readonly Booknote _booknote;
        private List<RadioButton> _buttons;
        public RecordsList(Booknote booknote)
        {
            _booknote = booknote;
            InitializeComponent();
            UpdateRecords();
        }

        public void UpdateRecords()
        {
            var list = _booknote.GetAllRecords();
            Records.Children.Clear();
            _buttons = new List<RadioButton>(list.Count);
            foreach (var record in list)
            {
                var rb = new RadioButton {GroupName = "Records", Content = record.ToString()};
                rb.MouseDoubleClick += (obj, args) =>
                {
                    MessageBox.Show((string)rb.Content,
                        record.GetType().ToString(),
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                };
                _buttons.Add(rb);
                Records.Children.Add(rb);
            }
            InvalidateVisual();
        }

        public string GetChoosen()
        {
            for (var i = 0; i < _buttons.Count; i++)
            {
                if (_buttons[i].IsChecked==true)
                    return i.ToString();
            }
            return null;
        }
    }
}