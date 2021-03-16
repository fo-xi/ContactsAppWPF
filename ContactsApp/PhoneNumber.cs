﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ContactsApp
{
    /// <summary>
    /// Class containing information about the phone number.
    /// </summary>
    public class PhoneNumber : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// Contains information about the phone number.
        /// </summary>
        private string _number;

        // TODO: в базовый класс?
        /// <summary>
        /// Contains a dictionary of errors.
        /// </summary>
        private readonly Dictionary<string, List<string>> _errorsByPropertyName
            = new Dictionary<string, List<string>>();

        /// <summary>
        /// Returns and sets the phone number.
        /// </summary>
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                ClearErrors(nameof(Number));

                try
                {
                    // TODO: если надо узнать, есть ошибка или нет,..
                    // то надо делать возврат bool, а не выкидывание исключения
                    Validator.AssertPhoneNumber(value);
                }
                catch (ArgumentException e)
                {
                    AddError(nameof(Number), e.Message);
                }

                _number = value;
                OnPropertyChanged(nameof(Number));
                OnErrorsChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Creates a phone number.
        /// </summary>
        /// <param name="number">Contact phone number.</param>
        public PhoneNumber(string number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Creates a phone number.
        /// </summary>
        public PhoneNumber()
        {
            Number = String.Empty;
        }

        // TODO: в базовый класс?
        /// <summary>
        /// Event that will react to changes in the property 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: в базовый класс?
        /// <summary>
        /// Event triggering.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // TODO: в базовый класс?
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

        // TODO: в базовый класс?
        /// <summary>
        ///  Property indicates whether there are any validation errors.
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return _errorsByPropertyName.Any();
            }
        }

        // TODO: в базовый класс?
        /// <summary>
        /// Event must occur when the validation errors have changed
        /// for a property or for the entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        // TODO: в базовый класс?
        /// <summary>
        /// Event triggering.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        // TODO: в базовый класс?
        /// <summary>
        /// Adds an error message to the error dictionary.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        /// <param name="error">Error message.</param>
        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        // TODO: в базовый класс?
        /// <summary>
        /// Removes all errors by key.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
