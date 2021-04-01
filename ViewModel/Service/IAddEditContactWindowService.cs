using ViewModel.WindowsVM;

namespace ViewModel.Service
{
    // TODO: НЕ НАДО ДОБАВЛЯТЬ СЛОВА "ADD", "EDIT" В НАЗВАНИЕ. ЭТО И ТАК ОЧЕВИДНО.
    // ЭТИ СЛОВА ДОБАВЛЯЮТСЯ В НЕСКОЛЬКИХ РЕДКИХ СЛУЧАЯХ
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
