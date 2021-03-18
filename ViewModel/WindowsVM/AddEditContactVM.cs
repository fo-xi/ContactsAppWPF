using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;
using ViewModel.Service;

namespace ViewModel.WindowsVM
{
    // TODO: именование класса - зачем куча глаголов в начале?
    /// <summary>
    /// View Model for window AddEditContact.
    /// </summary>
    public class AddEditContactVM : NotifyPropertyChanged
    {
        // TODO: именование
        /// <summary>
        /// AddCommand or EditCommand Contact.
        /// </summary>
        private Contact _addEditContact;

        /// <summary>
        /// Responsible for calling the AddEditContactWindow.
        /// </summary>
        private IAddEditContactWindowService _addEditContactWindowService;

        // TODO: DialogResult должен быть в интерфейсе сервиса, а не VM
        /// <summary>
        /// DialogResult.
        /// </summary>
        public bool DialogResult { get; set; }

        /// <summary>
        /// Returns access to the button.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return !AddEditContact.HasErrors;
            }
        }

        // TODO: именование
        /// <summary>
        /// Returns and sets AddCommand or EditCommand Contact.
        /// </summary>
        public Contact AddEditContact
        {
            get
            {
                return _addEditContact;
            }
            set
            {
                _addEditContact = value;
                _addEditContact.PropertyChanged += ContactChanged;
                _addEditContact.Number.PropertyChanged += ContactChanged;
            }
        }

        // TODO: свойство с командой должно в название добавлять слово Command (+)
        /// <summary>
        /// Returns and sets Ok command.
        /// </summary>
        public Command OKCommand { get; set; }

        // TODO: свойство с командой должно в название добавлять слово Command (+)
        /// <summary>
        /// Returns and sets Cancel command.
        /// </summary>
        public Command CancelCommand { get; set; }

        /// <summary>
        /// Create a contact to add or edit.
        /// </summary>
        /// <param name="addEditContact">AddCommand or EditCommand Contact.</param>
        public AddEditContactVM(Contact addEditContact, IAddEditContactWindowService addEditContactWindowService)
        {
            AddEditContact = addEditContact;
            _addEditContactWindowService = addEditContactWindowService;

            OKCommand = new Command(OK);
            CancelCommand = new Command(Cancel);
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

        // TODO: команда может быть в реализации сервиса окна
        /// <summary>
        /// Ok command.
        /// </summary>
        /// <param name="sender"></param>
        private void OK(object sender)
        {
            DialogResult = true;
            _addEditContactWindowService.Close();
        }

        // TODO: команда может быть в реализации сервиса окна
        /// <summary>
        /// Cancel command.
        /// </summary>
        /// <param name="sender"></param>
        private void Cancel(object sender)
        {
            DialogResult = false;
            _addEditContactWindowService.Close();
        }
    }
}
