using System;
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
    public class PhoneNumber : NotifyDataErrorInfoBase
    {
        /// <summary>
        /// Contains information about the phone number.
        /// </summary>
        private string _number;

        /// <summary>
        /// Returns and sets the phone number.
        /// </summary>
        public string Number
        {
            get { return _number; }
            set
            {
                ClearErrors(nameof(Number));

                if (!Validator.IsPhoneNumber(value, out var valueString))
                {
                    AddError(nameof(Number), valueString);
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
    }
}
