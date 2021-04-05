using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ContactsApp;

namespace UnitTesting
{
    class ValidatorTest
    {
        [Test(Description = "A positive validator test that checks the length of a string")]
        public void TestStringLength_CorrectValue()
        {
            var expected = "Ilya";
            Assert.IsTrue(Validator.IsStringLength(expected, 1, 50, out string message));
        }

        [Test(Description = "A positive validator test that checks whether " +
            "the phone number starts with the number 7")]
        public void TestPhoneNumber_CorrectValue()
        {
            var expected = "71234567891";
            Assert.IsTrue(Validator.IsPhoneNumber(expected, out string message));
        }

        [Test(Description = "A positive validator that checks " +
            "whether the date of birth was in the range")]
        public void TestDateBirth_CorrectValue()
        {
            DateTime expected = new DateTime(2000, 11, 21);
            Assert.IsTrue(Validator.IsBirthday(expected, 1900, out string message));
        }

        [Test(Description = "A positive validator test that check " +
            "whether letters change from low case to high case")]
        public void TestMakeUpperCase_CorrectValue()
        {
            var expected = "Ilya";
            var actual = Validator.MakeUpperCase(expected.ToLower());
            Assert.AreEqual(expected, actual, "The method returns a lowercase string");
        }

        [TestCase("tghfgfskghirgnbierngobirenboenrbnrolrnbnrenboernbornbr", "An exception can occur if there is " +
                  "a line longer than 50 characters ",
	        TestName = "Assigning an incorrect string of more than 50 symbols")]
        [TestCase("", "An exception may occur on an empty string",
	        TestName = "Assigning an incorrect string less than 1 symbols")]
        public void TestStringLength_ManyCharacters(string wrongString, string message)
        {
	        Assert.IsFalse(Validator.IsStringLength(wrongString, 1, 50, out string value), message);
        }

        [TestCase("91234567891", "An exception may occur if the phone number " +
                                 "does not start with the number 7",
	        TestName = "Assigning an incorrect phone number " +
	                   "that doesn't start with the number 7")]
        [TestCase("912345678", "An exception may occur if " +
                               "the phone number contains less than 11 digits",
	        TestName = "Assigning an incorrect phone number" +
	                   " that contains less than 11 digits")]
        [Test(Description = "Assigning an incorrect phone number that doesn't start with the number 7")]
        public void TestPhoneNumber_InvalidPhoneNumber(string wrongPhoneNumber, string message)
        {
	        Assert.IsFalse(Validator.IsPhoneNumber(wrongPhoneNumber, out string value), message);
        }

        [TestCase(1600, 2, 17, "An exception may occur if the date of birth is less than 1900",
	        TestName = "Assigning an incorrect surname that contains less than 1 symbol")]
        [TestCase(2030, 2, 17, "An exception can be made if the " +
                               "date of birth is greater than the current year",
	        TestName = "Assigning an incorrect date of birth more than the current year")]
        [Test(Description = "Assigning an incorrect date of birth less than 1900")]
        public void Birthday_Less1900(int year, int month, int day, string message)
        {
	        var wrongDateBirth = new DateTime(year, month, day);
            Assert.IsFalse(Validator.IsBirthday(wrongDateBirth, 1900, out string value), message);
        }
    }
}
