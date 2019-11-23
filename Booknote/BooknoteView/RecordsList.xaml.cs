using System;
using System.Windows.Controls;
using BooknoteLogic;

namespace BooknoteView
{
    public partial class RecordsList : UserControl
    {
        private readonly Booknote _booknote;

        public RecordsList(Booknote booknote)
        {
            _booknote = booknote;
            InitializeComponent();
            UpdateRecords();
        }

        public void UpdateRecords()
        {
            Console.WriteLine("PANEL UPDATED");
            var list = _booknote.GetAllRecords();
            Records.Children.Clear();
            foreach (var record in list)
            {
                var rb = new RadioButton {GroupName = "Records", Content = record.ToString()};
                Records.Children.Add(rb);
            }
            InvalidateVisual();
        }
    }
}