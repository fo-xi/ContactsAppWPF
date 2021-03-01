using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp;

namespace ViewModel
{
    public class ListСontactsVM : INotifyPropertyChanged

    {
        private Contact _selectedContact;

        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        public ListСontactsVM()
        {
            Contacts = new ObservableCollection<Contact>
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
