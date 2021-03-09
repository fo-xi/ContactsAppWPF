using System.Windows;
using ContactsApp;
using ViewModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM _mainWindow = new MainWindowVM();

        public MainWindow()
        {
            InitializeComponent();

            _mainWindow.ListСontacts.Add = new Commands(Add);
            _mainWindow.ListСontacts.Remove = new Commands(Remove);
            _mainWindow.ListСontacts.Edit = new Commands(Edit);

            DataContext = _mainWindow;

            About.Command = new Commands(OpenAbout);
            Exit.Command = new Commands(ExitMainWindow);
            AddContact.Command = new Commands(Add);
            EditContact.Command = new Commands(Edit);
            RemoveContact.Command = new Commands(Remove);

            Closing += ClosingMainWindow;
        }
        private void Add(object sender)
        {
            AddEditContact addEditWindow = new AddEditContact();
            if (addEditWindow.ShowDialog() == true)
            {
                var mainWindow = (MainWindowVM)DataContext;
                var add = (AddEditContactVM)addEditWindow.DataContext;
                mainWindow.ListСontacts.Contacts.Add(add.AddEditContact);
            }
        }

        private void Remove(object sender)
        {
            var mainWindow = (MainWindowVM)DataContext;
            var selectedContact = mainWindow.ListСontacts.SelectedContact;

            if (selectedContact == null)
            {
                MessageBox.Show($"Select Contact!");
                return;
            }

            mainWindow.ListСontacts.Contacts.Remove(selectedContact);
        }

        private void Edit(object sender)
        {
            var mainWindow = (MainWindowVM)DataContext;
            var selectedContact = mainWindow.ListСontacts.SelectedContact;

            if (selectedContact == null)
            {
                MessageBox.Show($"Select Contact!");
                return;
            }

            var addEditWindow = new AddEditContact();

            var edit = (AddEditContactVM)addEditWindow.DataContext;
            edit.AddEditContact = (Contact)selectedContact.Clone();

            if (addEditWindow.ShowDialog() == true)
            {
                var index = mainWindow.ListСontacts.Contacts.IndexOf(selectedContact);
                mainWindow.ListСontacts.Contacts[index] = edit.AddEditContact;
            }
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
