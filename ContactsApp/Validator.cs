using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string AssertStringLength(string value,
            int initialLength, int finalLength)
        {
            string error = String.Empty; 
            if ((value.Length < initialLength) || (value.Length > finalLength))
            {
                error = "Value must be in the range from " +
                               initialLength + " to " + finalLength;
            }
            return error;
        }

        /// <summary>
        /// Converts the first letter of the first 
        /// or last name to uppercase.
        /// </summary>
        /// <param name="value">Value set by the user.</param>
        public static string MakeUpperCase(string value)
        {
            if (value == String.Empty)
            {
                return String.Empty;
            }
            return (value.Substring(0, 1).ToUpper() +
                    value.Substring(1, value.Length - 1).ToLower());
        }

        /// <summary>
        /// Checking the phone number for the first digit.
        /// </summary>
        /// <param name="value">Phone number.</param>
        public static string AssertPhoneNumber(string value)
        {
            string error = String.Empty;
            if ((value.Length != 11) || (value[0] != '7'))
            {
                error = value + " The number must contain exactly 11" +
                                            "digits and start with 7";
            }
            return error;
        }

        /// <summary>
        /// Date of birth check for interval.
        /// </summary>
        /// <param name="value">Date of birth.</param>
        /// <param name="initialLength">Interval start.</param>
        public static string AssertDateBirth(DateTime value,
            int initialLength)
        {
            string error = String.Empty;
            if ((value.Year < initialLength) || (value > DateTime.Now))
            {
                error = "Value must be in the range from" 
                                            + " to " + DateTime.Now;
            }
            return error;
        }
    }
}
