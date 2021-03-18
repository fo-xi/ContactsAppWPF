﻿using System.Windows;
using ContactsApp;
using ContactsAppUI.Service;
using ViewModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM _mainWindow = new MainWindowVM(new MessageBoxService(), new AddEditContactWindowService());

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _mainWindow;

            About.Command = new Command(OpenAbout);
            Exit.Command = new Command(ExitMainWindow);
            AddContact.Command = _mainWindow.ListСontacts.AddCommand;
            EditContact.Command = _mainWindow.ListСontacts.EditCommand;
            RemoveContact.Command = _mainWindow.ListСontacts.RemoveCommand;

            Closing += ClosingMainWindow;
        }
        
        private void OpenAbout(object sender)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void ExitMainWindow(object sender)
        {
            _mainWindow.Save();
            Close();
        }

        private void ClosingMainWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Save();
        }
    }
}
