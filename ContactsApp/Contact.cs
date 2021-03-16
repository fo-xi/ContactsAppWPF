using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ContactsApp
{
    /// <summary>
    /// A class containing all information about the contact.
    /// </summary>
    public class Contact : ICloneable, INotifyPropertyChanged, INotifyDataErrorInfo
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

        /// <summary>
        /// Contact's surname.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Contact's surname.
        /// </summary>
        private string _name;

        /// <summary>
        /// Contact's birthday.
        /// </summary>
        private DateTime _dateBirth;

        /// <summary>
        /// Contact's email.
        /// </summary>
        private string _email;

        /// <summary>
        /// Contact's ID Vkontakte.
        /// </summary>
        private string _vkID;

        // TODO: в базовый класс?
        /// <summary>
        /// Contains a dictionary of errors.
        /// </summary>
        private readonly Dictionary<string, List<string>> _errorsByPropertyName
            = new Dictionary<string, List<string>>();

        /// <summary>
        /// Returns and sets the contact's surname.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                Validate(value, nameof(Surname));
                _surname = Validator.MakeUpperCase(value);
                OnPropertyChanged(nameof(Surname));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Returns and sets the contact's name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validate(value, nameof(Name));
                _name = Validator.MakeUpperCase(value);
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Returns and sets the contact's number.
        /// </summary>
        public PhoneNumber Number { get; set; }

        // TODO: день рождения в разных местах называется по-разному. Сделать единообразно
        /// <summary>
        /// Returns and sets the contact's birthday.
        /// </summary>
        public DateTime DateBirth
        {
            get
            {
                return _dateBirth;
            }
            set
            {
                Validate(value, nameof(DateBirth));
                _dateBirth = value;
                OnPropertyChanged(nameof(DateBirth));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Returns and sets the contact's email.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Validate(value, nameof(Email));
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Returns and sets the contact's ID Vkontakte.
        /// </summary>
        public string VKID
        {
            get
            {
                return _vkID;
            }
            set
            {
                Validate(value, nameof(VKID));
                _vkID = value;
                OnPropertyChanged(nameof(VKID));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Creates a contact.
        /// </summary>
        /// <param name="surname">Contact's surname.</param>
        /// <param name="name">Contact's name..</param>
        /// <param name="number">Contact's number.</param>
        /// <param name="dateBirth">Contact's birthday.</param>
        /// <param name="email">Contact's email.</param>
        /// <param name="vkID">A double precision number.</param>

        public Contact(string surname, string name, PhoneNumber number,
                       DateTime dateBirth, string email, string vkID)
        {
            Number = number;
            Number.PropertyChanged += PhoneNumberChanged;
            Name = name;
            Surname = surname;
            DateBirth = dateBirth;
            Email = email;
            VKID = vkID;
        }

        /// <summary>
        /// Updates button access.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneNumberChanged(object sender, PropertyChangedEventArgs e)
        {
            OnErrorsChanged(nameof(HasErrors));
        }

        /// <summary>
        /// Creates a contact.
        /// </summary>
        public Contact() : this(String.Empty, String.Empty,
            new PhoneNumber(), DateTime.Now, String.Empty, String.Empty)
        {

        }

        /// <summary>
        /// Makes a copy of the object <see cref="Contact"/>
        /// </summary>
        public object Clone()
        {
            return new Contact(Surname = this.Surname, Name = this.Name,
                Number = this.Number, DateBirth = this.DateBirth,
                Email = this.Email, VKID = this.VKID);
        }

        // TODO: в базовый класс?
        /// <summary>
        /// Event that will react to changes in the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: в базовый класс?
        /// <summary>
        /// Event triggering.
        /// </summary>
        /// <param name="propertyName">Property Name.</param>
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
                return _errorsByPropertyName.Any() || Number.HasErrors;
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
        /// <param name="propertyName"></param>
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

        // TODO: метод шаблонный, но почему-то всё равно занимается конвертированием в конкретный тип данных.
        // Либо конвертирование, либо шаблонный метод
        // TODO: вместо Assert с throw должны быть булевы методы. Иначе кидание исключений самому себе
        /// <summary>
        /// Validation of values.
        /// </summary>
        /// <typeparam name="T">String or DateTime</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property Name.</param>
        private void Validate<T>(T value, string propertyName)
        {
            ClearErrors(propertyName);

            try
            {
                if (value is string valueString)
                {
                    Validator.AssertStringLength(valueString, MinLength, MaxLength);
                }

                if (value is DateTime valueDateTime)
                {
                    Validator.AssertDateBirth(valueDateTime, MinYear);
                }
            }
            catch (ArgumentException e)
            {
                AddError(propertyName, e.Message);
            }
        }
    }
    
}
