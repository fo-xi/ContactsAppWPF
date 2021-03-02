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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace ContactsAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainWindow = new MainWindowVM();

            mainWindow.ListСontacts.Add = new Commands(Add);

            DataContext = mainWindow;
        }
        private void Add(object sender)
        {
            AddEditContact addEditWindow = new AddEditContact();
            addEditWindow.Show();

            var m = (MainWindowVM) DataContext;
            var k = ()
            m.ListСontacts.Contacts.Add(addEditWindow.DataContext.);
        }

        private void Remove(object sender)
        {

        }

        private void Edit(object sender)
        {

        }
    }
}
