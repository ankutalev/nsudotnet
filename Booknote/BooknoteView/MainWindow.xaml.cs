﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BooknoteLogic;

namespace BooknoteView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyInitializeComponent();   
        }

        private void MyInitializeComponent()
        {
            var cont = new Container.Container();
            var producer =  cont.Resolve<CommandProducer>();
            var commands = producer.GetAvailableCommands();
            Commands.Columns = 1;
            var enumerable = commands as string[] ?? commands.ToArray();
            Commands.Rows = enumerable.Count();
            foreach (var command in enumerable)
            {
                var commandButton = new Button {Content = command};
                Commands.Children.Add(commandButton);
            }
        }
    }
}