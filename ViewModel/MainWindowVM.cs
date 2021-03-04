using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;

namespace ViewModel
{
    public class MainWindowVM
    {
        private Project _project = new Project();

        public BirthdayVM Birthday { get; set; }

        public ListСontactsVM ListСontacts { get; set; }

        public MainWindowVM()
        {
            _project = ProjectManager.ReadFromFile();
            ListСontacts = new ListСontactsVM(_project.Contacts);

            var listBirthContacts = _project.GetDateBirth(DateTime.Now);
            Birthday = new BirthdayVM(listBirthContacts);

            ListСontacts.TextChanged += OnTextChanged;
        }

        public void Save()
        {
            ProjectManager.WriteToFile(_project);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            var listСontactsVm = (ListСontactsVM)sender;
            listСontactsVm.FindContacts = _project.SortingContacts(listСontactsVm.FindText);
        }
    }
}
