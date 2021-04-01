using System.Windows;
using ContactsApp;
using ViewModel;
using ViewModel.WindowsVM;
// TODO: убрать пустые юзинги
// TODO: поправить пространство имен
namespace ContactsAppUI
{
    // TODO: назвать форму правильно, поправить xml-комментарий
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
