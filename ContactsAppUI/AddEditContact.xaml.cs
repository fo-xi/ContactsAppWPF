using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ContactsApp;
using ViewModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for AddEditContact.xaml
    /// </summary>
    public partial class AddEditContact : Window
    {
        public AddEditContact()
        {
            InitializeComponent();

            var addEditContact = new AddEditContactVM(new Contact());

            addEditContact.OK = new Commands(OK);

            addEditContact.Cancel = new Commands(Cancel);

            DataContext = addEditContact;
        }

        private void OK(object sender)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel(object sender)
        {
            DialogResult = false;
            Close();
        }
    }
}
