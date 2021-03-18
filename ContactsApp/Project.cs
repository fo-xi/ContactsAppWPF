 using System;
using System.Collections.Generic;
 using System.Collections.ObjectModel;
 using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    // TODO: если агрегируемые классы реализуют INPC, то почему этот класс не реализует? (+)
    /// <summary>
    /// A class containing a list of all contacts 
    /// created in the app.
    /// </summary>
    public class Project : NotifyPropertyChanged
    {
        /// <summary>
        /// All contacts.
        /// </summary>
        private ObservableCollection<Contact> _contacts;

        /// <summary>
        /// Stores a list of all contacts created in the app.
        /// </summary>
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        /// <summary>
        /// Creates a list of all contacts.
        /// </summary>
        public Project()
        {
            Contacts = new ObservableCollection<Contact>();
        }

        /// <summary>
		/// Sorts contacts by the first letter of their last name.
		/// </summary>
        public ObservableCollection<Contact> SortingContacts()
        {
            Contacts = new ObservableCollection<Contact>
                (Contacts.OrderBy(contact => contact.Surname));
            return Contacts;
        }

        /// <summary>
		/// Alphabetically sort the list of contacts whose last name.
        /// or first name contains the specified substring.
		/// </summary>
        /// <param name="substring">First or last name substring.</param>
        public ObservableCollection<Contact> SortingContacts(string substring)
        {
            // TODO: LINQ (+)
            // TODO: AddRange (+)
            // TODO: дублирование с методом выше (+)
            // TODO: сначала выбирать по условию, а потом сортировать! Зачем сортировать данные, которые потом отсеются? (+)

            var sortedContacts = Contacts.Where(contact => contact.Surname.Contains(substring) 
            || contact.Name.Contains(substring)).OrderBy(contact => contact.Surname);
            return new ObservableCollection<Contact>(sortedContacts);
        }

        /// <summary>
        /// Returns a list of all contacts where the date of birth (day and month) 
        /// matches the date in the input argument.
        /// </summary>
        /// /// <param name="dateBirth">Date of birth.</param>
        public ObservableCollection<Contact> GetDateBirth(DateTime dateBirth)
        {
            var dateBirthContacts = new ObservableCollection<Contact>();

            foreach (var i in Contacts)
            {
                if ((i.Birthday.Day == dateBirth.Day) &&
                    (i.Birthday.Month == dateBirth.Month))
                {
                    dateBirthContacts.Add(i);
                }
            }
            return dateBirthContacts;
        }
    }
}
