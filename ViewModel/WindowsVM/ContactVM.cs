using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;
using ViewModel.Service;

namespace ViewModel.WindowsVM
{
    /// <summary>
    /// View Model for window Contact.
    /// </summary>
    public class ContactVM : NotifyPropertyChangedBase
    {
        /// <summary>
        /// AddCommand or EditCommand Contact.
        /// </summary>
        private Contact _contact;

        // TODO: поле нигде не используется
        /// <summary>
        /// Responsible for calling the AddEditContactWindow.
        /// </summary>
        private IContactWindowService _contactWindowService;

        // TODO: не очевидное название. Is Enabled что?
        /// <summary>
        /// Returns access to the button.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return !Contact.HasErrors;
            }
        }

        /// <summary>
        /// Returns and sets AddCommand or EditCommand Contact.
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                _contact.PropertyChanged += ContactChanged;
                _contact.Number.PropertyChanged += ContactChanged;
            }
        }

        /// <summary>
        /// Returns and sets Ok command.
        /// </summary>
        public Command OKCommand { get; set; }

        /// <summary>
        /// Returns and sets CancelCommand command.
        /// </summary>
        public Command CancelCommand { get; set; }

        /// <summary>
        /// Create a contact to add or edit.
        /// </summary>
        /// <param name="contact">AddCommand or EditCommand Contact.</param>
        public ContactVM(Contact contact, IContactWindowService contactWindowService)
        {
            Contact = contact;
            _contactWindowService = contactWindowService;

            OKCommand = contactWindowService.OKCommand;
            CancelCommand = contactWindowService.CancelCommand;
        }

        // TODO: этот метод уже есть в базовом классе, использовать готовый метод
        /// <summary>
        /// Responsible for updating the access to the button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsEnabled));
        }
    }
}
