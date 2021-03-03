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
            _project.Contacts = new ObservableCollection<Contact>
            {
                new Contact("Sasha", "Dyagay",
                    new PhoneNumber("79234657789"),
                    DateTime.Now,
                    "jnglsnl@kmh.com", "895974"),
                new Contact("Dasha", "Koko",
                    new PhoneNumber("79456735567"),
                    DateTime.Now,
                    "nmhlrt@jmnl.com", "83963"),
                new Contact("Masha", "Goktr",
                    new PhoneNumber("79237568844"),
                    new DateTime(2005, 3, 10),
                    "imjtm@jmnl.com", "486745")
            };
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
            var control = (ListСontactsVM)sender;
            control.Contacts = _project.SortingContacts(control.FindText);
        }
    }
}
