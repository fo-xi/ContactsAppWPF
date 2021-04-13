using System.Windows;
using ViewModel.WindowsVM;

namespace ContactsAppUI.Windows
{
    // TODO: назвать форму правильно (-)
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
