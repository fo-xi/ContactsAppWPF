using System.Collections.ObjectModel;
using ContactsApp;

namespace ViewModel.ControlsVM
{
    // TODO: любая VM должна реализовывать INPC
    /// <summary>
    /// View model for control Birthday.
    /// </summary>
    public class BirthdayVM
    {
        /// <summary>
        /// Contacts about which birthday on the appointed day.
        /// </summary>
        public string ListBirthdayContact { get; set; }

        /// <summary>
        /// Creating a string with information about contacts
        /// who have a birthday on the appointed day.
        /// </summary>
        /// <param name="contacts">List of contacts.</param>
        public BirthdayVM(ObservableCollection<Contact> contacts)
        {
            ListBirthdayContact = GetString(contacts);
        }

        /// <summary>
        /// Getting a common string with birthday people.
        /// </summary>
        /// <param name="contacts">List of contacts.</param>
        /// <returns></returns>
        private string GetString(ObservableCollection<Contact> contacts)
        {
            // TODO: здесь можно использовать метод string.Join()
            string stringContacts = string.Empty;

            foreach (var i in contacts)
            {
                stringContacts += i.Surname + " ";
            }

            return stringContacts;
        }

    }
}
