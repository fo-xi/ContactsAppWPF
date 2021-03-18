using ViewModel.WindowsVM;

namespace ViewModel.Service
{
    // TODO: xml (+)
    // TODO: если это интерфейс специальнос для окна контакта, (+)
    // ..тогда это надо отразить в названии класса, а из методов убрать
    /// <summary>
    /// Сlass responsible for showing window.
    /// </summary>
    public interface IAddEditContactWindowService
    {
        /// <summary>
        /// Opens a window for adding and editing a contact.
        /// </summary>
        void Open(AddEditContactVM contact);

        // TODO: зачем метод на закрытие? Окно же показывается как модальное
        /// <summary>
        /// Close a window for adding and editing a contact.
        /// </summary>
        void Close();
    }
}
