using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;

namespace ViewModel.ControlsVM
{
    // TODO: именование. Зачем слово List? Почему Contacts?..
    // Это не просто список контактов, это представление для всего проекта
    /// <summary>
    /// View model for control ListСontacts.
    /// </summary>
    public class ListСontactsVM : INotifyPropertyChanged
    {
        /// <summary>
        /// The string by which we are looking for contacts. 
        /// </summary>
        private string _findText;

        /// <summary>
        /// List of all contacts.
        /// </summary>
        public ObservableCollection<Contact> _contacts;

        /// <summary>
        /// Selected Contact.
        /// </summary>
        private Contact _selectedContact;

        /// <summary>
        /// Returns and sets a list of all contacts..
        /// </summary>
        public ObservableCollection<Contact> Contacts { get; set; }

        // TODO: Finded
        /// <summary>
        /// Returns and sets a list of all found contacts.
        /// </summary>
        public ObservableCollection<Contact> FindContacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(FindContacts));
            }
        }

        /// <summary>
        /// Returns and sets a string by which we are looking for contacts. 
        /// </summary>
        public string FindText
        {
            get
            {
                return _findText;
            }
            set
            {

                _findText = value;
                TextChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Returns and sets selected Contact.
        /// </summary>
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        // TODO: свойство с командой должно в название добавлять слово Command
        /// <summary>
        /// Returns and sets Add contact command.
        /// </summary>
        public Commands Add { get; set; }

        // TODO: свойство с командой должно в название добавлять слово Command
        /// <summary>
        /// Returns and sets Remove contact command.
        /// </summary>
        public Commands Remove { get; set; }

        // TODO: свойство с командой должно в название добавлять слово Command
        /// <summary>
        /// Returns and sets Edit contact command.
        /// </summary>
        public Commands Edit { get; set; }

        /// <summary>
        /// Creates a contact list.
        /// </summary>
        /// <param name="contacts"></param>
        public ListСontactsVM(ObservableCollection<Contact> contacts = null)
        {
             Contacts = FindContacts = contacts;
        }

        // TODO: можно было обойтись одним событием...
        // INotifyPropertyChanged не обязательно использовать только для биндингов
        /// <summary>
        /// An event that will react to changes in the contact search string.
        /// </summary>
        public event EventHandler TextChanged;

        // TODO: в базовый класс?
        /// <summary>
        /// Event that will react to changes in the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: в базовый класс?
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
