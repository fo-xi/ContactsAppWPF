using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;

namespace ViewModel.ControlsVM
{
    // TODO: именование. Зачем слово List? Почему Contacts?.. (+)
    // Это не просто список контактов, это представление для всего проекта
    /// <summary>
    /// View model for control Сontacts.
    /// </summary>
    public class СontactsVM : NotifyPropertyChanged
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

        // TODO: Finded (+)
        /// <summary>
        /// Returns and sets a list of all found contacts.
        /// </summary>
        public ObservableCollection<Contact> Finded
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Finded));
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
                OnPropertyChanged(nameof(FindText));
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

        // TODO: свойство с командой должно в название добавлять слово Command (+)
        /// <summary>
        /// Returns and sets AddCommand contact command.
        /// </summary>
        public Command AddCommand { get; set; }

        // TODO: свойство с командой должно в название добавлять слово Command (+)
        /// <summary>
        /// Returns and sets RemoveCommand contact command.
        /// </summary>
        public Command RemoveCommand { get; set; }

        // TODO: свойство с командой должно в название добавлять слово Command (+)
        /// <summary>
        /// Returns and sets EditCommand contact command.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Creates a contact list.
        /// </summary>
        /// <param name="contacts"></param>
        public СontactsVM(ObservableCollection<Contact> contacts = null)
        {
             Contacts = Finded = contacts;
             FindText = string.Empty;
        }
    }
}
