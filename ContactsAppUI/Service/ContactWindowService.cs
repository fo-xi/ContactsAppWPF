﻿using ContactsAppUI.Windows;
using ViewModel;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ContactsAppUI.Service
{
    /// <summary>
    /// Сlass responsible for showing window.
    /// </summary>
    public class ContactWindowService : IContactWindowService
    {
        /// <summary>
        /// Window for adding and editing a contact.
        /// </summary>
        private Contact _contactWindow;

        /// <summary>
        /// DialogResult.
        /// </summary>
        public bool DialogResult { get; set; }

        /// <summary>
        /// Ok command.
        /// </summary>
        public Command OKCommand { get; set; }

        /// <summary>
        /// Cancel command.
        /// </summary>
        public Command CancelCommand { get; set; }

        /// <summary>
        /// Ok command.
        /// </summary>
        /// <param name="sender"></param>
        private void OK(object sender)
        {
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Cancel command.
        /// </summary>
        /// <param name="sender"></param>
        private void Cancel(object sender)
        {
            DialogResult = false;
            Close();
        }

        /// <summary>
        /// Opens a window.
        /// </summary>
        /// <param name="contact">Contact.</param>
        public void Open(ContactVM contact)
        {
            _contactWindow = new Contact(contact);
            _contactWindow.ShowDialog();
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        public void Close()
        {
            _contactWindow.Close();
        }

        /// <summary>
        /// Creation of command.
        /// </summary>
        public ContactWindowService()
        {
            OKCommand = new Command(OK);
            CancelCommand = new Command(Cancel);
        }
    }
}
