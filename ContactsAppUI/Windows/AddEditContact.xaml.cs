using System.Windows;
using ContactsApp;
using ViewModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for AddEditContact.xaml
    /// </summary>
    public partial class AddEditContact : Window
    {
        public AddEditContact()
        {
            InitializeComponent();

            var addEditContact = new AddEditContactVM(new Contact());

            addEditContact.OK = new Commands(OK);

            addEditContact.Cancel = new Commands(Cancel);

            DataContext = addEditContact;
        }

        private void OK(object sender)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel(object sender)
        {
            DialogResult = false;
            Close();
        }
    }
}
