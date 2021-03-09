using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;

namespace ViewModel
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
        public AddEditContactVM(Contact addEditContact)
        {
            AddEditContact = addEditContact;
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
    }
}
