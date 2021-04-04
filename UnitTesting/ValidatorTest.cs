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

        [Test(Description = "Assigning an incorrect string of more than 50 symbols")]
        public void TestStringLength_ManyCharacters()
        {
            string wrongString = "tghfgfskghirgnbierngobirenboenrbnrolrnbnrenboernbornbr";
            Assert.IsFalse(Validator.IsStringLength(wrongString, 1, 50, out string message));
        }

        [Test(Description = "Assigning an incorrect string less than 1 symbols")]
        public void TestStringLength_NotEnoughCharacters()
        {
            string wrongString = "";
            Assert.IsFalse(Validator.IsStringLength(wrongString, 1, 50, out string message));
        }

        [Test(Description = "Assigning an incorrect phone number that doesn't start with the number 7")]
        public void TestPhoneNumber_InvalidPhoneNumber()
        {
            string wrongPhoneNumber = "89234046677";
            Assert.IsFalse(Validator.IsPhoneNumber(wrongPhoneNumber, out string message));
        }

        [Test(Description = "Assigning an incorrect phone number that contains less than 11 digits")]
        public void TestPhoneNumber_ShortNumber()
        {
            string wrongPhoneNumber = "792340466";
            Assert.IsFalse(Validator.IsPhoneNumber(wrongPhoneNumber, out string message));
        }

        [Test(Description = "Assigning an incorrect date of birth less than 1900")]
        public void Birthday_Less1900()
        {
            var wrongDateBirth = new DateTime(1600, 11, 21);
            Assert.IsFalse(Validator.IsBirthday(wrongDateBirth, 1900, out string message));
        }

        [Test(Description = "Assigning an incorrect date of birth more than the current year")]
        public void Birthday_MoreCurrentYear()
        {
            var wrongDateBirth = new DateTime(2030, 11, 21);
            Assert.IsFalse(Validator.IsBirthday(wrongDateBirth, 1900, out string message));
        }
    }
}
