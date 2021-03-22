using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ViewModel.ControlsVM
{
    // TODO: именование. Зачем слово List? Почему Contacts?.. (+)
    // Это не просто список контактов, это представление для всего проекта
    /// <summary>
    /// View model for control СontactsVM.
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

        /// <summary>
        /// Responsible for calling the MessageBox.
        /// </summary>
        private IMessageBoxService _messageBoxService;

        /// <summary>
        /// Responsible for calling the AddEditContactWindow.
        /// </summary>
        private IAddEditContactWindowService _contactWindowService;

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
                _contacts = Project.SortingContacts(FindText, value); 
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
        /// AddCommand contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Add(object sender)
        {
            ContactVM window =
                new ContactVM(new Contact(),
                    _contactWindowService);
            _contactWindowService.Open(window);

            if (_contactWindowService.DialogResult)
            {
                Contacts.Add(window.Contact);
            }

            Finded = Contacts;
        }

        /// <summary>
        /// Deleting a contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Remove(object sender)
        {
            var selectedContact = SelectedContact;

            if (selectedContact == null)
            {
                _messageBoxService.Show("Select Contact!");
                return;
            }

           Contacts.Remove(selectedContact);
           Finded = Contacts;
        }

        /// <summary>
        /// Deleting a contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Edit(object sender)
        {
            var selectedContact = SelectedContact;

            if (selectedContact == null)
            {
                _messageBoxService.Show("Select Contact!");
                return;
            }

            // TODO: длинная строка, больше 100 символов.. (+)
            //.. переформатировать, чтобы было не больше 100
            ContactVM window =
                new ContactVM((Contact)selectedContact.Clone(),
                    _contactWindowService);
            _contactWindowService.Open(window);

            // TODO: сравнение с true в условиях не делают (+)
            if (_contactWindowService.DialogResult)
            {
                var index = Contacts.IndexOf(selectedContact);
               Contacts[index] = window.Contact;
            }

            Finded = Contacts;
        }

        /// <summary>
        /// Creates a contact list.
        /// </summary>
        /// <param name="contacts"></param>
        public СontactsVM(IMessageBoxService messageBoxService,
            IAddEditContactWindowService contactWindowService, 
            ObservableCollection<Contact> contacts = null)
        {
             FindText = string.Empty;
             Contacts = Finded = contacts;

             _messageBoxService = messageBoxService;
             _contactWindowService = contactWindowService;

             AddCommand = new Command(Add);
             RemoveCommand = new Command(Remove);
             EditCommand = new Command(Edit);
        }
    }
}
