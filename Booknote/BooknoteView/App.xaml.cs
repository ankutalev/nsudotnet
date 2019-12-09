using System.Collections.Generic;
using System.Windows;
using BooknoteView.CommandsCreation;

namespace BooknoteView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void StartApp(object sender, StartupEventArgs e)
        {
            var container = new Container.Container(new List<string> {"BooknoteLogic", "BooknoteView"});
            var prod = container.Resolve<UiCommandProducer>();
            var rl = container.Resolve<RecordsList>();
            new MainWindow(rl,prod).Show();
        }
    }
    
   
}