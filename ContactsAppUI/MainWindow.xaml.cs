using System.Windows;
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
        MainWindowVM _mainWindow = new MainWindowVM(new MessageBoxService(), new WindowService());

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _mainWindow;

            About.Command = new Commands(OpenAbout);
            Exit.Command = new Commands(ExitMainWindow);
            AddContact.Command = _mainWindow.ListСontacts.Add;
            EditContact.Command = _mainWindow.ListСontacts.Edit;
            RemoveContact.Command = _mainWindow.ListСontacts.Remove;

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
