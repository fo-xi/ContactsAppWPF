using System;
using System.Collections.Generic;
using System.Text;
using ContactsApp;
using NUnit.Framework;

namespace UnitTesting
{
    class ContactTest
    {
        [Test(Description = "Positive test of the getter Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            var expected = "Bogdanov";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ")
            {
                Surname = expected
            };
            var actual = contact.Surname;
            Assert.AreEqual(expected, actual, "The Surname getter " +
                "returns an incorrect surname");
        }

        [Test(Description = "Positive test of the setter Surname")]
        public void TestSurnameSet_CorrectValue()
        {
            var expected = "Bogdanov";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            Assert.DoesNotThrow(() =>
            {
                contact.Surname = expected;
            }, "The Surname setter accepts the correct surname");
        }

        [TestCase("", "An exception may occur if the surname contains less than 1 symbol",
            TestName = "Assigning an incorrect surname that contains less than 1 symbol")]
        [TestCase("BogdanovBogdanovBogdanovBogdanovBogdanovBogdanovBogdanov",
            "An exception may occur if the surname contains more than 50 symbol",
            TestName = "Assigning an incorrect surname that contains more than 50 symbol")]
        public void TestSurname_InvalidSurname(string wrongSurname, string message)
        {
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            contact.Surname = wrongSurname;
            Assert.IsTrue(contact.HasErrors);
        }

        [Test(Description = "Positive test of the getter Name")]
        public void TestNameGet_CorrectValue()
        {
            var expected = "Ilya";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ")
            {
                Name = expected
            };
            var actual = contact.Name;
            Assert.AreEqual(expected, actual, "The Name getter " +
                "returns an incorrect name");
        }

        [Test(Description = "Positive test of the setter Name")]
        public void TestNameSet_CorrectValue()
        {
            var expected = "Ilya";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            Assert.DoesNotThrow(() =>
            {
                contact.Surname = expected;
            }, "The Name setter accepts the correct name");
        }

        [TestCase("", "An exception may occur if the name contains less than 1 symbol",
            TestName = "Assigning an incorrect name that contains less than 1 symbol")]
        [TestCase("IlyaIlyaIlyaIlyaIlyaIlyaIlyaIlyaIlyaIlyaIlyaIlyaIlyaIlya",
            "An exception may occur if the name contains more than 50 symbol",
            TestName = "Assigning an incorrect name that contains more than 50 symbol")]
        public void TestName_InvalidName(string wrongName, string message)
        {
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            contact.Name = wrongName;
            Assert.IsTrue(contact.HasErrors);
        }

        [Test(Description = "Positive test of the getter PhoneNumber")]
        public void TestPhoneNumberGet_CorrectValue()
        {
            var expected = new PhoneNumber("71459567000");
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ")
            {
                Number = expected
            };
            var actual = contact.Number;
            Assert.AreEqual(expected, actual, "The PhoneNumber getter " +
                "returns an incorrect phone number");
        }

        [Test(Description = "Positive test of the setter PhoneNumber")]
        public void TestPhoneNumberSet_CorrectValue()
        {
            var expected = new PhoneNumber("71459567000");
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            Assert.DoesNotThrow(() =>
            {
                contact.Number = expected;
            }, "The PhoneNumber setter accepts the correct phone number");
        }

        [Test(Description = "Positive test of the getter Birthday")]
        public void TestDateBirthGet_CorrectValue()
        {
            var expected = new DateTime(2000, 6, 4);
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ")
            {
                Birthday = expected
            };
            var actual = contact.Birthday;
            Assert.AreEqual(expected, actual, "The Birthday getter " +
                "returns an incorrect date of birth");
        }

        [Test(Description = "Positive test of the setter DateBirt")]
        public void TestDateBirtSet_CorrectValue()
        {
            var expected = new DateTime(2000, 6, 4);
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            Assert.DoesNotThrow(() =>
            {
                contact.Birthday = expected;
            }, "The DateBirt setter accepts the correct date of birth");
        }

        [TestCase(1600, 2, 17, "An exception may occur if the date of birth is less than 1900",
            TestName = "Assigning an incorrect surname that contains less than 1 symbol")]
        [TestCase(2030, 2, 17, "An exception can be made if the " +
                "date of birth is greater than the current year",
            TestName = "Assigning an incorrect date of birth more than the current year")]
        public void TestDateBirt_InvalidSurname(int year, int month, int day, string message)
        {
            var wrongDateBirt = new DateTime(year, month, day);
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            contact.Birthday = wrongDateBirt;
            Assert.IsTrue(contact.HasErrors);
        }

        [Test(Description = "Positive test of the getter Email")]
        public void TestEmailGet_CorrectValue()
        {
            var expected = "pupu@gmail.com";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ")
            {
                Email = expected
            };
            var actual = contact.Email;
            Assert.AreEqual(expected, actual, "The Email getter " +
                "returns an incorrect e-mail");
        }

        [Test(Description = "Positive test of the setter Email")]
        public void TestEmailSet_CorrectValue()
        {
            var expected = "pupu@gmail.com";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            Assert.DoesNotThrow(() =>
            {
                contact.Email = expected;
            }, "The Email setter accepts the correct e-mail");
        }

        [TestCase("", "An exception may occur if the e-mail contains less than 1 symbol",
            TestName = "Assigning an incorrect e-mail that contains less than 1 symbol")]
        [TestCase("pupu@gmail.compupu@gmail.compupu@gmail.compupu@gmail.compupu@gmail.com",
            "An exception may occur if the e-mail contains more than 50 symbol",
            TestName = "Assigning an incorrect e-mail that contains more than 50 symbol")]
        public void TestEmail_InvalidName(string wrongEmail, string message)
        {
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            contact.Email = wrongEmail;
            Assert.IsTrue(contact.HasErrors);
        }

        [Test(Description = "Positive test of the getter VKID")]
        public void TestVKIDGet_CorrectValue()
        {
            var expected = "648562";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ")
            {
                VKID = expected
            };
            var actual = contact.VKID;
            Assert.AreEqual(expected, actual, "The VKID getter " +
                "returns an incorrect vk id");
        }

        [Test(Description = "Positive test of the setter VKID")]
        public void TestVKIDSet_CorrectValue()
        {
            var expected = "648562";
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            Assert.DoesNotThrow(() =>
            {
                contact.VKID = expected;
            }, "The VKID setter accepts the correct vk id");
        }

        [TestCase("", "An exception may occur if the vk id contains less than 1 symbol",
           TestName = "Assigning an incorrect vk id that contains less than 1 symbol")]
        [TestCase("648562648562648562648562648562",
           "An exception may occur if the vk id contains more than 15 symbol",
           TestName = "Assigning an incorrect vk id that contains more than 15 symbol")]
        public void TestVKID_InvalidName(string wrongVKID, string message)
        {
            var contact = new Contact(" ", " ", new PhoneNumber("71234567000"),
                new DateTime(2000, 11, 21), " ", " ");
            contact.VKID = wrongVKID;
            Assert.IsTrue(contact.HasErrors);
        }

        [Test(Description = "Positive test of the constructor Contact")]
        public void TestContactConstructor_CorrectValue()
        {
            var surname = "Frolovo";
            var name = "Elena";
            var number = new PhoneNumber("71234567891");
            var dateBirth = new DateTime(2000, 5, 4);
            var email = "popo@gmail.com";
            var vkId = "754967";
            Assert.DoesNotThrow(() =>
            {
                var contact = new Contact(surname, name, number, dateBirth,
                    email, vkId);
            }, "The Contact constructor create a contact object");
        }
    }
}
