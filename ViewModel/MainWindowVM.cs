﻿using System;
using ContactsApp;
using ViewModel.ControlsVM;
using ViewModel.Service;
using ViewModel.WindowsVM;

namespace ViewModel
{
    // BUG: При первом запуске редактирование контакта не работает, не обновляется
    // BUG: Контакты не сортируются по алфавиту после редактирования
    // TODO: Любая VM должна реализовывать интерфейс INotifyPropertyChanged
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
        /// Responsible for calling the MessageBox.
        /// </summary>
        private IMessageBoxService _messageBoxService;

        /// <summary>
        /// Responsible for calling the AddEditContactWindow.
        /// </summary>
        private IWindowService _windowService;

        /// <summary>
        /// Contacts about which birthday on the appointed day.
        /// </summary>
        public BirthdayVM Birthday { get; set; }

        // TODO: именование
        /// <summary>
        /// A contact list.
        /// </summary>
        public ListСontactsVM ListСontacts { get; set; }

        /// <summary>
        /// Creation of information about all contacts.
        /// </summary>
        public MainWindowVM(IMessageBoxService messageBoxService, IWindowService windowService)
        {
            _project = ProjectManager.ReadFromFile();
            ListСontacts = new ListСontactsVM(_project.Contacts);

            var listBirthContacts = _project.GetDateBirth(DateTime.Now);
            Birthday = new BirthdayVM(listBirthContacts);

            _messageBoxService = messageBoxService;

            // TODO: если реализация команд в этой VM, то почему они хранятся в другой?
            ListСontacts.AddCommand = new Commands(Add);
            ListСontacts.RemoveCommand = new Commands(Remove);
            ListСontacts.EditCommand = new Commands(Edit);

            _windowService = windowService;

            ListСontacts.TextChanged += OnTextChanged;
        }

        /// <summary>
        /// AddCommand contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Add(object sender)
        {
            AddEditContactVM addEditWindow = new AddEditContactVM(new Contact(), _windowService);
            _windowService.OpenAddEditContactWindow(addEditWindow);
            if (addEditWindow.DialogResult == true)
            {
                ListСontacts.Contacts.Add(addEditWindow.AddEditContact);
            }
        }

        /// <summary>
        /// Deleting a contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Remove(object sender)
        {
            var selectedContact = ListСontacts.SelectedContact;

            if (selectedContact == null)
            {
                _messageBoxService.Show("Select Contact!");
                return;
            }

            ListСontacts.Contacts.Remove(selectedContact);
        }

        /// <summary>
        /// Deleting a contact.
        /// </summary>
        /// <param name="sender">Sender.</param>
        private void Edit(object sender)
        {
            var selectedContact = ListСontacts.SelectedContact;

            if (selectedContact == null)
            {
                _messageBoxService.Show("Select Contact!");
                return;
            }
            // TODO: длинная строка, больше 100 символов..
            //.. переформатировать, чтобы было не больше 100
            AddEditContactVM addEditWindow = new AddEditContactVM((Contact)selectedContact.Clone(), _windowService);
            _windowService.OpenAddEditContactWindow(addEditWindow);

            // TODO: сравнение с true в условиях не делают
            if (addEditWindow.DialogResult == true)
            {
                var index = ListСontacts.Contacts.IndexOf(selectedContact);
                ListСontacts.Contacts[index] = addEditWindow.AddEditContact;
            }
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
