using System;
using System.Collections.Generic;
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
using ContactsApp;
using ViewModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainWindow = new MainWindowVM();

            mainWindow.ListСontacts.Add = new Commands(Add);
            mainWindow.ListСontacts.Remove = new Commands(Remove);
            mainWindow.ListСontacts.Edit = new Commands(Edit);

            DataContext = mainWindow;

            About.Command = new Commands(OpenAbout);
            Exit.Command = new Commands(ExitMainWindow);
            AddContact.Command = new Commands(Add);
            EditContact.Command = new Commands(Edit);
            RemoveContact.Command = new Commands(Remove);
        }
        private void Add(object sender)
        {
            AddEditContact addEditWindow = new AddEditContact();
            if (addEditWindow.ShowDialog() == true)
            {
                var mainWindow = (MainWindowVM) DataContext;
                var add = (AddEditContactVM) addEditWindow.DataContext;
                mainWindow.ListСontacts.Contacts.Add(add.Contact);
            }
        }

        private void Remove(object sender)
        {
            var mainWindow = (MainWindowVM)DataContext;
            mainWindow.ListСontacts.Contacts.Remove(mainWindow.ListСontacts.SelectedContact);
        }

        private void Edit(object sender)
        {
            var mainWindow = (MainWindowVM)DataContext;

            AddEditContact addEditWindow = new AddEditContact();

            var selectedContact = mainWindow.ListСontacts.SelectedContact;
            var edit = (AddEditContactVM)addEditWindow.DataContext;
            edit.Contact = (Contact)selectedContact.Clone();

            if (addEditWindow.ShowDialog() == true)
            {
                var index = mainWindow.ListСontacts.Contacts.IndexOf(selectedContact);
                mainWindow.ListСontacts.Contacts[index] = edit.Contact;
            }
        }

        private void OpenAbout(object sender)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void ExitMainWindow(object sender)
        {
            Close();
        }
    }
}
