using System;
using System.ComponentModel;

namespace ContactsApp
{
    /// <summary>
    /// A class containing all information about the contact.
    /// </summary>
    public class Contact : NotifyDataErrorInfoBase, ICloneable
    {
        /// <summary>
        /// Minimum string length.
        /// </summary>
        private const int MinLength = 1;

        /// <summary>
        /// Maximum string length. 
        /// </summary>
        private const int MaxLength = 50;

        /// <summary>
        /// Minimum year allowed.
        /// </summary>
        private const int MinYear = 1900;

        /// <summary>
        /// Maximum string IDVK.
        /// </summary>
        private const int MaxID = 15;

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
        /// Surname line state.
        /// </summary>
        private StateOfView _surnameState = StateOfView.Initial;

        /// <summary>
        /// Name line state.
        /// </summary>
        private StateOfView _nameState = StateOfView.Initial;

        /// <summary>
        /// Birthday line state.
        /// </summary>
        private StateOfView _birthdayState = StateOfView.Initial;

        /// <summary>
        /// Email line state.
        /// </summary>
        private StateOfView _emailState = StateOfView.Initial;

        /// <summary>
        /// VKID line state.
        /// </summary>
        private StateOfView _vkIDState = StateOfView.Initial;

        /// <summary>
        /// Property indicates whether there are any validation errors.
        /// </summary>
        public override bool HasErrors
        {
            get
            {
                return base.HasErrors || Number.HasErrors || !IsNotEmpty();
            }
        }

        /// <summary>
        /// Checks a property if it is empty or null.
        /// </summary>
        /// <returns></returns>
        private bool IsNotEmpty()
        {
	        return !string.IsNullOrEmpty(Surname) &&
	               !string.IsNullOrEmpty(Name) &&
	               !string.IsNullOrEmpty(Number.Number) &&
	               !string.IsNullOrEmpty(Email) &&
	               !string.IsNullOrEmpty(VKID);
        }

        /// <summary>
        /// Returns and sets the contact's surname.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
	            if (_surnameState == StateOfView.Updated)
	            {
		            Validate(value, MinLength, MaxLength, nameof(Surname));
	            }

                _surnameState = StateOfView.Updated;
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
	            if (_nameState == StateOfView.Updated)
	            {
		            Validate(value, MinLength, MaxLength, nameof(Name));
	            }

	            _nameState = StateOfView.Updated;
	            _name = Validator.MakeUpperCase(value);
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        /// <summary>
        /// Returns and sets the contact's number.
        /// </summary>
        public PhoneNumber Number { get; set; }

        /// <summary>
        /// Returns and sets the contact's birthday.
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
	            if (_birthdayState == StateOfView.Updated)
	            {
		            Validate(value, MinYear, nameof(Birthday));
	            }

	            _birthdayState = StateOfView.Updated;
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
	            if (_emailState == StateOfView.Updated)
	            {
		            Validate(value, MinLength, MaxLength, nameof(Email));
	            }

	            _emailState = StateOfView.Updated;
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
	            if (_vkIDState == StateOfView.Updated)
	            {
		            Validate(value, MinLength, MaxID, nameof(VKID));
	            }

	            _vkIDState = StateOfView.Updated;
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