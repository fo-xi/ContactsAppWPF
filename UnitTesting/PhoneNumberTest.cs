using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ContactsApp;

namespace UnitTesting
{
    class PhoneNumberTest
    {

        [Test(Description = "Positive test of the getter Number")]
        public void TestNumberGet_CorrectValue()
        {
            var expected = "71234567891";
            var phoneNumber = new PhoneNumber("71234567000")
            {
                Number = expected
            };
            var actual = phoneNumber.Number;
            Assert.AreEqual(expected, actual, "The Number getter " +
                "returns an incorrect phone number");
        }

        [Test(Description = "Positive test of the setter Number")]
        public void TestNumberSet_CorrectValue()
        {
            var expected = "71234567891";
            var phoneNumber = new PhoneNumber("71234567000");
            Assert.DoesNotThrow(() =>
            {
                phoneNumber.Number = expected;
            }, "The Number setter accepts the correct phone number");
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
            var phoneNumber = new PhoneNumber("71234567000");
            Assert.Throws<ArgumentException>(() =>
            {
                phoneNumber.Number = wrongPhoneNumber;
            }, message);
        }

        [Test(Description = "Positive test of the constructor PhoneNumber")]
        public void TestNumberConstructor_CorrectValue()
        {
            var number = "71234567891";
            Assert.DoesNotThrow(() =>
            {
                var phoneNumber = new PhoneNumber(number);
            }, "The Number constructor creates a valid phone number");
        }
    }
}
