using ViewModel.WindowsVM;

namespace ViewModel.Service
{
    // TODO: xml
    // TODO: если это интерфейс специальнос для окна контакта,
    // ..тогда это надо отразить в названии класса, а из методов убрать
    public interface IWindowService
    {
        /// <summary>
        /// Opens a window for adding and editing a contact.
        /// </summary>
        void OpenAddEditContactWindow(AddEditContactVM contact);

        // TODO: зачем метод на закрытие? Окно же показывается как модальное
        /// <summary>
        /// Close a window for adding and editing a contact.
        /// </summary>
        void CloseAddEditContactWindow();
    }
}
