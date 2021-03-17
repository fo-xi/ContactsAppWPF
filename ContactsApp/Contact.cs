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
    public class Contact : NotifyDataError, ICloneable
    {
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
        private DateTime _birthday;

        /// <summary>
        /// Contact's email.
        /// </summary>
        private string _email;

        /// <summary>
        /// Contact's ID Vkontakte.
        /// </summary>
        private string _vkID;

        /// <summary>
        /// Property indicates whether there are any validation errors.
        /// </summary>
        public override bool HasErrors
        {
            get
            {
                return _errorsByPropertyName.Any() || Number.HasErrors;
            }
        }

        /// <summary>
        /// Returns and sets the contact's surname.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
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
            get { return _name; }
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

        // TODO: день рождения в разных местах называется по-разному. Сделать единообразно (+)
        /// <summary>
        /// Returns and sets the contact's birthday.
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                Validate(value, nameof(Birthday));
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Returns and sets the contact's email.
        /// </summary>
        public string Email
        {
            get { return _email; }
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
            get { return _vkID; }
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
        /// <param name="birthday">Contact's birthday.</param>
        /// <param name="email">Contact's email.</param>
        /// <param name="vkID">A double precision number.</param>

        public Contact(string surname, string name, PhoneNumber number,
            DateTime birthday, string email, string vkID)
        {
            Number = number;
            Number.PropertyChanged += PhoneNumberChanged;
            Name = name;
            Surname = surname;
            Birthday = birthday;
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
                Number = this.Number, Birthday = this.Birthday,
                Email = this.Email, VKID = this.VKID);
        }
    }
}