﻿using System.Windows;
using ContactsAppUI.Service;
using ContactsAppUI.Windows;
using ViewModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Main Window.
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM _mainWindow = new MainWindowVM(new MessageBoxService(), new ContactWindowService());

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _mainWindow;

            ShowAboutWindow.Command = new Command(OpenAbout);
            Exit.Command = new Command(ExitMainWindow);
            AddContactCommand.Command = _mainWindow.СontactsVM.AddCommand;
            EditContactCommand.Command = _mainWindow.СontactsVM.EditCommand;
            RemoveContactCommand.Command = _mainWindow.СontactsVM.RemoveCommand;

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
