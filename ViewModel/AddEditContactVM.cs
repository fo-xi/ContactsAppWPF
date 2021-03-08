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
    public class AddEditContactVM
    {
        public Contact AddEditContact { get; set; }

        public Commands OK { get; set; }

        public Commands Cancel { get; set; }

        public AddEditContactVM(Contact addEditContact)
        {
            AddEditContact = addEditContact;
        }
    }
}
