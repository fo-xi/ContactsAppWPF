using System.Windows;
using ViewModel;
using ViewModel.Service;

namespace ContactsAppUI.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public void Show(string text)
        {
            MessageBox.Show(text);
        }
    }
}
