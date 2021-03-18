using System;
using ContactsApp;
using ViewModel.ControlsVM;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ViewModel
{
    // BUG: При первом запуске редактирование контакта не работает, не обновляется (+)
    // BUG: Контакты не сортируются по алфавиту после редактирования (+)
    // TODO: Любая VM должна реализовывать интерфейс INotifyPropertyChanged (+)
    /// <summary>
    /// View Model for window MainWindow.
    /// </summary>
    public class MainWindowVM : NotifyPropertyChanged
    {
        /// <summary>
        /// Stores a list of all contacts created in the app.
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Сontacts's birthday.
        /// </summary>
        private BirthdayVM _birthday;

        /// <summary>
        /// Contact.
        /// </summary>
        private СontactsVM _contact;

        /// <summary>
        /// Responsible for calling the MessageBox.
        /// </summary>
        private IMessageBoxService _messageBoxService;

        /// <summary>
        /// Responsible for calling the AddEditContactWindow.
        /// </summary>
        private IAddEditContactWindowService _contactWindowService;

        private string _oldFindText = string.Empty;

        /// <summary>
        /// Contacts about which birthday on the appointed day.
        /// </summary>
        public BirthdayVM Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        // TODO: именование (+)
        /// <summary>
        /// A contact list.
        /// </summary>
        public СontactsVM Сontacts 
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                OnPropertyChanged(nameof(Сontacts));
            }
        }

        /// <summary>
        /// Creation of information about all contacts.
        /// </summary>
        public MainWindowVM(IMessageBoxService messageBoxService,
            IAddEditContactWindowService contactWindowService)
        {
            _project = ProjectManager.ReadFromFile();
            Сontacts = new СontactsVM(_project.SortingContacts());

            var listBirthContacts = _project.GetDateBirth(DateTime.Now);
            Birthday = new BirthdayVM(listBirthContacts);

            _messageBoxService = messageBoxService;

            // TODO: если реализация команд в этой VM, то почему они хранятся в другой?
            Сontacts.AddCommand = new Command(Add);
            Сontacts.RemoveCommand = new Command(Remove);
            Сontacts.EditCommand = new Command(Edit);

            _contactWindowService = contactWindowService;

            Сontacts.PropertyChanged += OnTextChanged;
        }

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
                Сontacts.Contacts.Add(window.Contact);
            }

            Сontacts.Contacts = _project.SortingContacts();
            Сontacts.Finded = Сontacts.Contacts;
        }

        /// <summary>
        /// Deleting a contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Remove(object sender)
        {
            var selectedContact = Сontacts.SelectedContact;

            if (selectedContact == null)
            {
                _messageBoxService.Show("Select Contact!");
                return;
            }

            Сontacts.Contacts.Remove(selectedContact);
        }

        /// <summary>
        /// Deleting a contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Edit(object sender)
        {
            var selectedContact = Сontacts.SelectedContact;

            if (selectedContact == null)
            {
                _messageBoxService.Show("Select Contact!");
                return;
            }

            // TODO: длинная строка, больше 100 символов.. (+)
            //.. переформатировать, чтобы было не больше 100
            ContactVM window =
                new ContactVM((Contact) selectedContact.Clone(),
                    _contactWindowService);
            _contactWindowService.Open(window);

            // TODO: сравнение с true в условиях не делают (+)
            if (_contactWindowService.DialogResult)
            {
                var index = Сontacts.Contacts.IndexOf(selectedContact);
                Сontacts.Contacts[index] = window.Contact;
            }

            Сontacts.Contacts = _project.SortingContacts();
            Сontacts.Finded = Сontacts.Contacts;
        }
        

        /// <summary>
        /// Saving contact information to a file.
        /// </summary>
        public void Save()
        {
            ProjectManager.WriteToFile(_project);
        }

        /// <summary>
        /// Finding contacts when changing the search bar.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, EventArgs e)
        {
            var listСontactsVm = (СontactsVM) sender;

            if (listСontactsVm.FindText == _oldFindText)
            {
                return;
            }

            _oldFindText = listСontactsVm.FindText;
            listСontactsVm.Finded = _project.SortingContacts();
            listСontactsVm.Finded = _project.SortingContacts(listСontactsVm.FindText);
        }
    }
}
