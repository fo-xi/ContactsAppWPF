using ViewModel.WindowsVM;

namespace ViewModel.Service
{
    /// <summary>
    /// Сlass responsible for showing window.
    /// </summary>
    public interface IContactWindowService
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
