﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using ContactsApp;

namespace ViewModel.ControlsVM
{
    /// <summary>
    /// View model for control BirthdayVM.
    /// </summary>
    public class BirthdayVM : NotifyPropertyChangedBase
    {
        /// <summary>
        /// BirthdayVM list.
        /// </summary>
        private string _listBirthdayContact;

        /// <summary>
        /// Contacts about which birthday on the appointed day.
        /// </summary>
        public string ListBirthdayContact
        {
            get
            {
                return _listBirthdayContact;
            }
            set
            {
                _listBirthdayContact = value;
                OnPropertyChanged();
            }

        }

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
            string stringContacts = string.Empty;

            stringContacts += string.Join(", ", contacts.Select(o=>o.Surname));

            return stringContacts;
        }

    }
}
