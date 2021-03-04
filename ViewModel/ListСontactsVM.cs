using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;
using ViewModel.Annotations;

namespace ViewModel
{
    public class ListСontactsVM : INotifyPropertyChanged
    {
        private string _findText;

        public ObservableCollection<Contact> _contacts;

        private Contact _selectedContact;

        public ObservableCollection<Contact> Contacts { get; set; }

        public ObservableCollection<Contact> FindContacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(FindContacts));
            }
        }

        public string FindText
        {
            get
            {
                return _findText;
            }
            set
            {

                _findText = value;
                TextChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public Commands Add { get; set; }

        public Commands Remove { get; set; }

        public Commands Edit { get; set; }

        public ListСontactsVM(ObservableCollection<Contact> contacts = null)
        {
             Contacts = FindContacts = contacts;
        }

        public event EventHandler TextChanged;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
