namespace ViewModel.Service
{
    /// <summary>
    /// The class responsible for displaying the MessageBox.
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Show MessageBox.
        /// </summary>
        /// <param name="text">Message.</param>
        void Show(string text);
    }
}
