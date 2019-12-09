﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BooknoteLogic;
using BooknoteLogic.Exceptions;
using BooknoteView.CommandsCreation;

namespace BooknoteView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(RecordsList rl, UiCommandProducer producer)
        {
            InitializeComponent();
            MyInitializeComponent(rl, producer);
        }

        private void MyInitializeComponent(RecordsList recordsList, UiCommandProducer producer)
        {
            var commands = producer.GetAvailableCommands();
            Commands.Columns = 1;
            var enumerable = commands as string[] ?? commands.ToArray();
            Commands.Rows = enumerable.Length;
            foreach (var command in enumerable)
            {
                //todo i think it's bad inteface design
                var factory = producer.GetFactory(command);
                var commandButton = new Button {Content = command};
                commandButton.Click += (obj, args) =>
                {
                    try
                    {
                        factory.CreateProduct().Execute();
                    }
                    catch (BooknoteLogicException ex)
                    {
                        MessageBox.Show(ex.Message,
                            "Error during command execution",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    recordsList.UpdateRecords();
                };
                Commands.Children.Add(commandButton);
            }
            MainDockPanel.Children.Add(recordsList);
        }
    }
}