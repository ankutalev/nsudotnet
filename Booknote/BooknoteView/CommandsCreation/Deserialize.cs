using System;
using System.Windows;
using System.Windows.Controls;

namespace BooknoteView.CommandsView
{
    public partial class Deserialize
    {
        public Deserialize()
        {
            
        }

        public void onClick(object sender, RoutedEventArgs args)
        {
            Console.WriteLine(args);
        }
    }
}