using System.Windows;
using ViewModel.WindowsVM;
// TODO: убрать пустые юзинги (+)
// TODO: поправить пространство имен (+)
namespace ContactsAppUI.Windows
{
    // TODO: назвать форму правильно, поправить xml-комментарий (+)
    /// <summary>
    /// Contact window.
    /// </summary>
    public partial class Contact : Window
    {
        public Contact(ContactVM contact)
        {
            InitializeComponent();

            DataContext = contact;
        }
    }
}
