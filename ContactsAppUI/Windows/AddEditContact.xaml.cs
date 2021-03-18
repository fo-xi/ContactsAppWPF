using System.Windows;
using ContactsApp;
using ViewModel;
using ViewModel.WindowsVM;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for Contact.xaml
    /// </summary>
    public partial class AddEditContact : Window
    {
        public AddEditContact(ContactVM contact)
        {
            InitializeComponent();

            DataContext = contact;
        }
    }
}
