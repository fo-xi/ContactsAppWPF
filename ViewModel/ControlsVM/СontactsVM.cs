using System.Collections.ObjectModel;
using ContactsApp;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ViewModel.ControlsVM
{
    // Это не просто список контактов, это представление для всего проекта
    /// <summary>
    /// View model for control СontactsVM.
    /// </summary>
    public class СontactsVM : NotifyPropertyChangedBase
    {
        /// <summary>
        /// The string by which we are looking for contacts. 
        /// </summary>
        private string _findText;

        // TODO: почему public? (+)
        // TODO: Это правильное название? (+)
        /// <summary>
        /// List of found contacts.
        /// </summary>
        private ObservableCollection<Contact> _findedContacts;

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
        private IContactWindowService _contactWindowService;

        // TODO: Finded (-) FindedContacts (+)
        /// <summary>
        /// Returns and sets a list of all found contacts.
        /// </summary>
        public ObservableCollection<Contact> FindedContacts
        {
            get
            {
                return _findedContacts;
            }
            set
            {
                _findedContacts = Project.SortingContacts(FindText, value);
                // TODO: метод реализован в базовом классе с атрибутом CallerMemberName - (+)
                // разберись что это за атрибут, для чего он нужен и исправь вызовы этого метода у себя.
                OnPropertyChanged();
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
                // TODO: метод реализован в базовом классе с атрибутом CallerMemberName - (+)
                // разберись что это за атрибут, для чего он нужен и исправь вызовы этого метода у себя.
                OnPropertyChanged();
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
                // TODO: метод реализован в базовом классе с атрибутом CallerMemberName - (+)
                // разберись что это за атрибут, для чего он нужен и исправь вызовы этого метода у себя.
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Returns and sets AddCommand contact command.
        /// </summary>
        public Command AddCommand { get; set; }

        /// <summary>
        /// Returns and sets RemoveCommand contact command.
        /// </summary>
        public Command RemoveCommand { get; set; }

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

            FindedContacts = Contacts;
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
           FindedContacts = Contacts;
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

            ContactVM window =
                new ContactVM((Contact)selectedContact.Clone(),
                    _contactWindowService);
            _contactWindowService.Open(window);

            if (_contactWindowService.DialogResult)
            {
                var index = Contacts.IndexOf(selectedContact);
               Contacts[index] = window.Contact;
            }

            FindedContacts = Contacts;
        }

        /// <summary>
        /// Creates a contact list.
        /// </summary>
        /// <param name="contacts"></param>
        public СontactsVM(IMessageBoxService messageBoxService,
            IContactWindowService contactWindowService, 
            ObservableCollection<Contact> contacts = null)
        {
             FindText = string.Empty;
             Contacts = FindedContacts = contacts;

             _messageBoxService = messageBoxService;
             _contactWindowService = contactWindowService;

             AddCommand = new Command(Add);
             RemoveCommand = new Command(Remove);
             EditCommand = new Command(Edit);
        }
    }
}
