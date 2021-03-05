﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Class containing information about the phone number.
    /// </summary>
    public class PhoneNumber : IDataErrorInfo
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
            get
            {
                return _number;
            }
            set
            {
                _number = value;
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

        /// <summary>
        /// Data validation.
        /// </summary>
        /// <param name="PropertyName">Property name.</param>
        /// <returns></returns>
        public string this[string PropertyName]
        {
            get
            {
                string error = String.Empty;
                switch (PropertyName)
                {
                    case "Number":
                    {
                        error = Validator.AssertPhoneNumber(Number);
                        break;
                    }
                }
                return error;
            }
        }

        /// <summary>
        /// Returns error.
        /// </summary>
        public string Error { get; }
    }
}
