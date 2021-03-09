using System;
using ContactsApp;

namespace ViewModel
{
    /// <summary>
    /// View Model for window MainWindow.
    /// </summary>
    public class MainWindowVM
    {
        /// <summary>
        /// Stores a list of all contacts created in the app.
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Contacts about which birthday on the appointed day.
        /// </summary>
        public BirthdayVM Birthday { get; set; }

        /// <summary>
        /// A contact list.
        /// </summary>
        public ListСontactsVM ListСontacts { get; set; }

        /// <summary>
        /// Creation of information about all contacts.
        /// </summary>
        public MainWindowVM()
        {
            _project = ProjectManager.ReadFromFile();
            ListСontacts = new ListСontactsVM(_project.Contacts);

            var listBirthContacts = _project.GetDateBirth(DateTime.Now);
            Birthday = new BirthdayVM(listBirthContacts);

            ListСontacts.TextChanged += OnTextChanged;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, EventArgs e)
        {
            var listСontactsVm = (ListСontactsVM)sender;
            listСontactsVm.FindContacts = _project.SortingContacts(listСontactsVm.FindText);
        }
    }
}
