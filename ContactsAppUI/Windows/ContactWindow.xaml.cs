using System.Windows;
using ViewModel.WindowsVM;

namespace ContactsAppUI.Windows
{
    // TODO: назвать форму правильно (+)
    /// <summary>
    /// Contact window.
    /// </summary>
    public partial class ContactWindow : Window
    {
        public ContactWindow(ContactVM contact)
        {
            InitializeComponent();

            DataContext = contact;
        }
    }
}
