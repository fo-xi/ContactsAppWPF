using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;
using ViewModel.Service;

namespace ViewModel.WindowsVM
{
    // TODO: именование класса - зачем куча глаголов в начале? (+)
    /// <summary>
    /// View Model for window Contact.
    /// </summary>
    public class ContactVM : NotifyPropertyChanged
    {
        // TODO: именование (+)
        /// <summary>
        /// AddCommand or EditCommand Contact.
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Responsible for calling the AddEditContactWindow.
        /// </summary>
        private IAddEditContactWindowService _contactWindowService;

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

        // TODO: именование (+)
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

        // TODO: свойство с командой должно в название добавлять слово Command (+)
        /// <summary>
        /// Returns and sets Ok command.
        /// </summary>
        public Command OKCommand { get; set; }

        // TODO: свойство с командой должно в название добавлять слово Command (+)
        /// <summary>
        /// Returns and sets CancelCommand command.
        /// </summary>
        public Command CancelCommand { get; set; }

        /// <summary>
        /// Create a contact to add or edit.
        /// </summary>
        /// <param name="contact">AddCommand or EditCommand Contact.</param>
        public ContactVM(Contact contact, IAddEditContactWindowService contactWindowService)
        {
            Contact = contact;
            _contactWindowService = contactWindowService;

            OKCommand = contactWindowService.OKCommand;
            CancelCommand = contactWindowService.CancelCommand;
        }

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
