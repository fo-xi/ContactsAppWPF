using System.Windows;
using ViewModel;
using ViewModel.Service;

namespace ContactsAppUI.Service
{ // TODO: xml
    public class MessageBoxService : IMessageBoxService
    {
        // TODO: xml
        public void Show(string text)
        {
            MessageBox.Show(text);
        }
    }
}
