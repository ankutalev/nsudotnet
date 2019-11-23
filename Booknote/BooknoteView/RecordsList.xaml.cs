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
            for (var index = 0; index < list.Count; index++)
            {
//                Records
                var record = list[index];
                Console.WriteLine(record);

                Records.Children.Add(new Label() { Content = record.ToString()});
            }
            InvalidateVisual();
        }
    }
}