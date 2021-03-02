using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;

namespace ViewModel
{
    public class ListСontactsVM : INotifyPropertyChanged
    {
        private string _findText;

        public ObservableCollection<Contact> _contacts;

        private Contact _selectedContact;

        public ObservableCollection<Contact> Contacts 
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged("Contacts");
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
                OnPropertyChanged("SelectedContact");
            }
        }

        public ListСontactsVM(ObservableCollection<Contact> contacts)
        {
            Contacts = contacts;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler TextChanged;
    }
}
