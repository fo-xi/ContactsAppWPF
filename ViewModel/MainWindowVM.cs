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
        /// СontactsVM's birthday.
        /// </summary>
        private BirthdayVM _birthdayVM;

        /// <summary>
        /// Contact.
        /// </summary>
        private СontactsVM _contactVM;

        /// <summary>
        /// Old search string.
        /// </summary>
        private string _oldFindText = string.Empty;

        /// <summary>
        /// Contacts about which birthday on the appointed day.
        /// </summary>
        public BirthdayVM BirthdayVM
        {
            get
            {
                return _birthdayVM;
            }
            set
            {
                _birthdayVM = value;
                OnPropertyChanged(nameof(BirthdayVM));
            }
        }

        // TODO: именование (+)
        /// <summary>
        /// A contact list.
        /// </summary>
        public СontactsVM СontactsVM 
        {
            get
            {
                return _contactVM;
            }
            set
            {
                _contactVM = value;
                OnPropertyChanged(nameof(СontactsVM));
            }
        }

        /// <summary>
        /// Creation of information about all contacts.
        /// </summary>
        public MainWindowVM(IMessageBoxService messageBoxService,
            IAddEditContactWindowService contactWindowService)
        {
            _project = ProjectManager.ReadFromFile();
            СontactsVM = new СontactsVM(messageBoxService, 
                contactWindowService, Project.SortingContacts(_project.Contacts));

            var listBirthContacts = _project.GetDateBirth(DateTime.Now);
            BirthdayVM = new BirthdayVM(listBirthContacts);

            // TODO: если реализация команд в этой VM, то почему они хранятся в другой? (+)

            СontactsVM.PropertyChanged += OnTextChanged;
        }

        /// <summary>
        /// Saving contact information to a file.
        /// </summary>
        public void Save()
        {
            _project.Contacts = СontactsVM.Contacts;
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
            listСontactsVm.Finded = Project.SortingContacts
                (listСontactsVm.FindText, СontactsVM.Contacts);
        }
    }
}
