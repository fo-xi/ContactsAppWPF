using ViewModel;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ContactsAppUI.Service
{
    // TODO: xml
    public class WindowService : IWindowService
    {
        // TODO: xml
        private AddEditContact _addEditWindow;

        // TODO: xml
        public void OpenAddEditContactWindow(AddEditContactVM contact)
        {
            _addEditWindow = new AddEditContact(contact);
            _addEditWindow.ShowDialog();
        }

        // TODO: xml
        public void CloseAddEditContactWindow()
        {
            _addEditWindow.Close();
        }
    }
}
