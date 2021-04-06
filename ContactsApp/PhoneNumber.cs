﻿using System;

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
        /// Number line state.
        /// </summary>
        private StateOfView _numberState = StateOfView.Initial;

        /// <summary>
        /// Returns and sets the phone number.
        /// </summary>
        public string Number
        {
            get { return _number; }
            set
            {
	            if (_numberState == StateOfView.Updated)
	            {
		            ClearErrors(nameof(Number));

		            if (!Validator.IsPhoneNumber(value, out var valueString))
		            {
			            AddError(nameof(Number), valueString);
		            }
	            }

	            _numberState = StateOfView.Updated;
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
