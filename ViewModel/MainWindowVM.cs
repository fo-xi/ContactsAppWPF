using System;
using ContactsApp;
using ViewModel.ControlsVM;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ViewModel
{
    /// <summary>
    /// View Model for window MainWindow.
    /// </summary>
    public class MainWindowVM : NotifyPropertyChanged
    {
        // TODO: поле инициализируется в конструкторе, здесь создавать объект не нужно
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

            // TODO: именование
            var listBirthContacts = _project.GetDateBirth(DateTime.Now);
            BirthdayVM = new BirthdayVM(listBirthContacts);
            
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
