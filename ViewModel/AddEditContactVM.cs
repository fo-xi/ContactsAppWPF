﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;

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
