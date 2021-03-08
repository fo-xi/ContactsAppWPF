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
        private bool _isEnabled;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = !AddEditContact.HasErrors;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public Contact AddEditContact { get; set; }

        public Commands OK { get; set; }

        public Commands Cancel { get; set; }

        public AddEditContactVM(Contact addEditContact)
        {
            AddEditContact = addEditContact;
            AddEditContact.PropertyChanged += ContactChanged;
        }

        private void ContactChanged(object sender, PropertyChangedEventArgs e)
        {
            IsEnabled = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
