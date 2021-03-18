using ViewModel;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ContactsAppUI.Service
{
    // TODO: xml (+)
    /// <summary>
    /// Сlass responsible for showing window.
    /// </summary>
    public class WindowService : IWindowService
    {
        // TODO: xml (+)
        /// <summary>
        /// Window for adding and editing a contact.
        /// </summary>
        private AddEditContact _addEditWindow;

        // TODO: xml (+)
        /// <summary>
        /// Opens a window.
        /// </summary>
        /// <param name="contact">Contact.</param>
        public void OpenAddEditContactWindow(AddEditContactVM contact)
        {
            _addEditWindow = new AddEditContact(contact);
            _addEditWindow.ShowDialog();
        }

        // TODO: xml (+)
        /// <summary>
        /// Closes the window.
        /// </summary>
        public void CloseAddEditContactWindow()
        {
            _addEditWindow.Close();
        }
    }
}
