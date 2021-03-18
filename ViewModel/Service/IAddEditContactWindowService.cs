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
        /// DialogResult.
        /// </summary>
        bool DialogResult { get; set; }

        /// <summary>
        /// Opens a window for adding and editing a contact.
        /// </summary>
        void Open(ContactVM contact);

        /// <summary>
        /// OK command.
        /// </summary>
        Command OKCommand { get; set; }

        /// <summary>
        /// Cancel command.
        /// </summary>
        Command CancelCommand { get; set; }
    }
}
