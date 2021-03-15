using ViewModel;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ContactsAppUI.Service
{
    public class WindowService : IWindowService
    {
        private AddEditContact _addEditWindow;

        public void OpenAddEditContactWindow(AddEditContactVM contact)
        {
            _addEditWindow = new AddEditContact(contact);
            _addEditWindow.ShowDialog();
        }

        public void CloseAddEditContactWindow()
        {
            _addEditWindow.Close();
        }
    }
}
