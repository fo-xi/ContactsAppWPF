using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public abstract class NotifyDataError : NotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// Minimum string length.
        /// </summary>
        private const int MinLength = 1;

        /// <summary>
        /// Maximum string length 
        /// </summary>
        private const int MaxLength = 50;

        /// <summary>
        /// Minimum year allowed.
        /// </summary>
        private const int MinYear = 1900;

        // TODO: в базовый класс? (+)
        /// <summary>
        /// Contains a dictionary of errors.
        /// </summary>
        protected readonly Dictionary<string, List<string>> _errorsByPropertyName
            = new Dictionary<string, List<string>>();

        // TODO: в базовый класс? (+)
        /// <summary>
        /// Gets all error messages.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName) ?
                _errorsByPropertyName[propertyName] : null;
        }

        // TODO: в базовый класс? (+)
        /// <summary>
        ///  Property indicates whether there are any validation errors.
        /// </summary>
        public virtual bool HasErrors
        {
            get
            {
                return _errorsByPropertyName.Any();
            }
        }

        // TODO: в базовый класс? (+)
        /// <summary>
        /// Event must occur when the validation errors have changed
        /// for a property or for the entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        // TODO: в базовый класс? (+)
        /// <summary>
        /// Event triggering.
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        // TODO: в базовый класс? (+)
        /// <summary>
        /// Adds an error message to the error dictionary.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        /// <param name="error">Error message.</param>
        protected void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        // TODO: в базовый класс? (+)
        /// <summary>
        /// Removes all errors by key.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        protected void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        // TODO: метод шаблонный, но почему-то всё равно занимается конвертированием в конкретный тип данных. (+)
        // Либо конвертирование, либо шаблонный метод
        // TODO: вместо Assert с throw должны быть булевы методы. Иначе кидание исключений самому себе (+)
        /// <summary>
        /// Validation of string.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property Name.</param>
        public void Validate(string value, string propertyName)
        {
            ClearErrors(propertyName);
            if (!Validator.AssertStringLength(value, MinLength, 
                MaxLength, out var valueString))
            {
                AddError(propertyName, valueString);
            }
        }

        /// <summary>
        /// Validation of Birthday.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property Name.</param>
        public void Validate(DateTime value, string propertyName)
        {
            ClearErrors(propertyName);
            if (!Validator.AssertBirthday(value, MinYear, out var valueString))
            {
                AddError(propertyName, valueString);
            }
        }
    }
}
