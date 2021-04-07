using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactsApp
{
    // TODO: к названию абстрактных классов должно добавляться слово Base (+)
    /// <summary>
    /// The class that is responsible for notifying the client about the change in the property value.
    /// </summary>
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that will react to changes in the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event triggering.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
