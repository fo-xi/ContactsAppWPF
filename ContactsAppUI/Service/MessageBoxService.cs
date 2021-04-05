using System.Windows;
using ViewModel.Service;

namespace ContactsAppUI.Service
{
    /// <summary>
    /// The class responsible for displaying the MessageBox.
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        /// <summary>
        /// Show MessageBox.
        /// </summary>
        /// <param name="text">Message.</param>
        public void Show(string text)
        {
            MessageBox.Show(text);
        }
    }
}
