using System.Windows;
using ViewModel;
using ViewModel.Service;

namespace ContactsAppUI.Service
{ // TODO: xml (+)
    /// <summary>
    /// The class responsible for displaying the MessageBox.
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        // TODO: xml (+)
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
