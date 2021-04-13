using System.Windows;
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

            ShowAboutWindowMenuItem.Command = new Command(OpenAbout);
            Exit.Command = new Command(ExitMainWindow);
            AddContactMenuItem.Command = _mainWindow.СontactsVM.AddCommand;
            EditContactMenuItem.Command = _mainWindow.СontactsVM.EditCommand;
            RemoveContactMenuItem.Command = _mainWindow.СontactsVM.RemoveCommand;

            Closing += ClosingMainWindow;
        }
        
        private void OpenAbout(object sender)
        {
            AboutWindow aboutWindowWindow = new AboutWindow();
            aboutWindowWindow.ShowDialog();
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
