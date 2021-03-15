using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;
using ViewModel.Service;

namespace ViewModel.WindowsVM
{
    /// <summary>
    /// View Model for window AddEditContact.
    /// </summary>
    public class AddEditContactVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Add or Edit Contact.
        /// </summary>
        private Contact _addEditContact;

        /// <summary>
        /// Responsible for calling the AddEditContactWindow.
        /// </summary>
        private IWindowService _windowService;

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

        /// <summary>
        /// Returns and sets Add or Edit Contact.
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

        /// <summary>
        /// Returns and sets Ok command.
        /// </summary>
        public Commands OK { get; set; }

        /// <summary>
        /// Returns and sets Cancel command.
        /// </summary>
        public Commands Cancel { get; set; }

        /// <summary>
        /// Create a contact to add or edit.
        /// </summary>
        /// <param name="addEditContact">Add or Edit Contact.</param>
        public AddEditContactVM(Contact addEditContact, IWindowService windowService)
        {
            AddEditContact = addEditContact;
            _windowService = windowService;

            OK = new Commands(OKCommand);
            Cancel = new Commands(CancelCommand);
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

        /// <summary>
        /// Event that will react to changes in the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event triggering.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Ok command.
        /// </summary>
        /// <param name="sender"></param>
        private void OKCommand(object sender)
        {
            DialogResult = true;
            _windowService.CloseAddEditContactWindow();
        }

        /// <summary>
        /// Cancel command.
        /// </summary>
        /// <param name="sender"></param>
        private void CancelCommand(object sender)
        {
            DialogResult = false;
            _windowService.CloseAddEditContactWindow();
        }
    }
}
