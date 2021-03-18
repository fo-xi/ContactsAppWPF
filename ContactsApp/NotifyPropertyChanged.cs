using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        // TODO: в базовый класс? (+)
        /// <summary>
        /// Event that will react to changes in the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: в базовый класс? (+)
        /// <summary>
        /// Event triggering.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
