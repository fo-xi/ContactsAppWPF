using ViewModel.WindowsVM;

namespace ViewModel.Service
{
    public interface IWindowService
    {
        /// <summary>
        /// Opens a window for adding and editing a contact.
        /// </summary>
        void OpenAddEditContactWindow(AddEditContactVM contact);

        /// <summary>
        /// Close a window for adding and editing a contact.
        /// </summary>
        void CloseAddEditContactWindow();
    }
}
