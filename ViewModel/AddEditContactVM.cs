using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Annotations;

namespace ViewModel
{
    public class AddEditContactVM : INotifyPropertyChanged
    {
        private Contact _addEditContact;

        public bool IsEnabled
        {
            get
            {
                return !AddEditContact.HasErrors;
            }
        }

        public Contact AddEditContact
        {
            get
            {
                return _addEditContact;
            }
            set
            {
                _addEditContact = value;
                _addEditContact.PropertyChanged += ContactChanged;
                _addEditContact.Number.PropertyChanged += ContactChanged;
            }
        }

        public Commands OK { get; set; }

        public Commands Cancel { get; set; }

        public AddEditContactVM(Contact addEditContact)
        {
            AddEditContact = addEditContact;
        }

        private void ContactChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsEnabled));
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
