using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;

namespace ViewModel
{
    public class BirthdayVM
    {
        public string ListBirthdayContact { get; set; }

        public BirthdayVM(List<Contact> contacts)
        {
            ListBirthdayContact = GetString(contacts);
        }

        private string GetString(List<Contact> contacts)
        {
            string stringContacts = string.Empty;

            foreach (var i in contacts)
            {
                stringContacts += i.Surname + " ";
            }

            return stringContacts;
        }

    }
}
