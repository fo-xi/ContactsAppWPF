using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// A class containing all information about the contact.
    /// </summary>
    public class Contact : ICloneable, IDataErrorInfo
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
        private DateTime _dateBirth;

        /// <summary>
        /// Contact's email.
        /// </summary>
        private string _email;

        /// <summary>
        /// Contact's ID Vkontakte.
        /// </summary>
        private string _vkID;

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
                    case "Surname":
                    {
                        error = Validator.AssertStringLength(Surname, 1, 50);
                        break;
                    }
                    case "Name":
                    {
                        error = Validator.AssertStringLength(Name, 1, 50);
                        break;
                    }
                    case "DateBirth":
                    {
                        error = Validator.AssertDateBirth(DateBirth, 1900);
                        break;
                    }
                    case "Email":
                    {
                        error = Validator.AssertStringLength(Email, 1, 50);
                        break;
                    }
                    case "VKID":
                    {
                        error = Validator.AssertStringLength(VKID, 1, 15);
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
                _surname = Validator.MakeUpperCase(value);
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
                _name = Validator.MakeUpperCase(value);
            }
        }

        /// <summary>
        /// Contact's number.
        /// </summary>
        public PhoneNumber Number { get; set; }

        /// <summary>
        /// Returns and sets the contact's birthday.
        /// </summary>
        /// 
        public DateTime DateBirth
        {
            get
            {
                return _dateBirth;
            }
            set
            {
                _dateBirth = value;
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
                _email = value;
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
                _vkID = value;
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
            Name = name;
            Surname = surname;
            Number = number;
            DateBirth = dateBirth;
            Email = email;
            VKID = vkID;
        }

        /// <summary>
        /// Creates a contact.
        /// </summary>
        public Contact()
        {
            Name = String.Empty;
            Surname = String.Empty;
            Number = new PhoneNumber();
            DateBirth = DateTime.Now;
            Email = String.Empty;
            VKID = String.Empty;
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
    }
}
