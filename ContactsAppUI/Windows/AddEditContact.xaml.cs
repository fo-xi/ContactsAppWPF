using System.Windows;
using ContactsApp;
using ViewModel;
using ViewModel.WindowsVM;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for AddEditContact.xaml
    /// </summary>
    public partial class AddEditContact : Window
    {
        public AddEditContact(AddEditContactVM contact)
        {
            InitializeComponent();

            DataContext = contact;
        }
    }
}
