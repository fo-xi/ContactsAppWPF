using System;

namespace ContactsApp
{
    /// <summary>
    /// A class containing auxiliary functions.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks whether the number of characters 
        /// is in the specified range.
        /// </summary>
        /// <param name="value">Value set by the user.</param>
        /// <param name="initialLength">The beginning of the border.</param>
        /// <param name="finalLength">The end of the border.</param>
        public static bool AssertStringLength(string value,
            int initialLength, int finalLength, out string message)
        {
            message = String.Empty;

            if ((value.Length < initialLength) || (value.Length > finalLength))
            {
                message = "Value must be in the range from " +
                          initialLength + " to " + finalLength;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Converts the first letter of the first 
        /// or last name to uppercase.
        /// </summary>
        /// <param name="value">Value set by the user.</param>
        public static string MakeUpperCase(string value)
        {
            if (value == string.Empty)
            {
                return value;
            }
            return (value.Substring(0, 1).ToUpper() +
                    value.Substring(1, value.Length - 1).ToLower());
        }

        /// <summary>
        /// Checking the phone number for the first digit.
        /// </summary>
        /// <param name="value">Phone number.</param>
        public static bool AssertPhoneNumber(string value, out string message)
        {
            message = String.Empty;

            if ((value.Length != 11) || (value[0] != '7'))
            {
                message = value + 
                       " The number must contain exactly 11 " +
                      "digits and start with 7";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Date of birth check for interval.
        /// </summary>
        /// <param name="value">Date of birth.</param>
        /// <param name="initialLength">Interval start.</param>
        public static bool AssertBirthday(DateTime value,
            int initialLength, out string message)
        {
            message = String.Empty;

            if ((value.Year < initialLength) || (value > DateTime.Now))
            {
                message = "Value must be in the range from" 
                                            + " to " + DateTime.Now;
                return false;
            }
            return true;
        }
    }
}
