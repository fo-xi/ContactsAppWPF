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
            Assert.DoesNotThrow(() =>
            {
                Validator.AssertStringLength(expected, 1, 50);
            }, "An exception should occur if the string is not in the specified rang");
        }

        [Test(Description = "A positive validator test that checks whether " +
            "the phone number starts with the number 7")]
        public void TestPhoneNumber_CorrectValue()
        {
            var expected = "71234567891";
            Assert.DoesNotThrow(() =>
            {
                Validator.AssertPhoneNumber(expected);
            }, "An exception should occur if the number does not start with 7");
        }

        [Test(Description = "A positive validator that checks " +
            "whether the date of birth was in the range")]
        public void TestDateBirth_CorrectValue()
        {
            DateTime expected = new DateTime(2000, 11, 21);
            Assert.DoesNotThrow(() =>
            {
                Validator.AssertDateBirth(expected, 1900);
            }, "An exception should occur if the " +
            "date of birth is not in the specified range");
        }

        [Test(Description = "A positive validator test that check " +
            "whether letters change from low case to high case")]
        public void TestMakeUpperCase_CorrectValue()
        {
            var expected = "Ilya";
            var actual = Validator.MakeUpperCase(expected.ToLower());
            Assert.AreEqual(expected, actual, "The method returns a lowercase string");
        }

        [TestCase("", "An exception should occur if string is less than 1 symbols",
            TestName = "Assigning an incorrect string less than 1 symbols")]
        [TestCase("tghfgfskghirgnbierngobirenboenrbnrolrnbnrenboernbornbr",
            "An exception may occur if the string contains more than 50 symbols",
            TestName = "Assigning an incorrect string of more than 50 symbols")]
        public void TestStringLength_IncorrectValue(string wrongString, string message)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Validator.AssertStringLength(wrongString, 1, 50);
            }, message);
        }
        [TestCase("91234567891", "An exception may occur if the phone number " +
                "does not start with the number 7",
            TestName = "Assigning an incorrect phone number " +
            "that doesn't start with the number 7")]
        [TestCase("912345678", "An exception may occur if " +
            "the phone number contains less than 11 digits",
            TestName = "Assigning an incorrect phone number" +
            " that contains less than 11 digits")]
        public void TestPhoneNumber_InvalidPhoneNumber(string wrongPhoneNumber, string message)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Validator.AssertPhoneNumber(wrongPhoneNumber);
            }, message);
        }

        [TestCase(1600, 11, 21, "An exception may occur if the date of birth is less than 1900",
            TestName = "Assigning an incorrect date of birth less than 1900")]
        [TestCase(2030, 11, 21, "An exception can be made if the " +
                "date of birth is greater than the current year",
            TestName = "Assigning an incorrect date of birth more than the current year")]
        public void TestStringLength_IncorrectValue(int year, int month, int day, string message)
        {
            var wrongDateBirth = new DateTime(year, month, day);
            Assert.Throws<ArgumentException>(() =>
            {
                Validator.AssertDateBirth(wrongDateBirth, 1900);
            }, message);
        }
    }
}
