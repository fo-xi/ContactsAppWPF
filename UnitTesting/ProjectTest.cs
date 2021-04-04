using System;
using System.Collections.Generic;
using System.Text;
using ContactsApp;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace UnitTesting
{
    class ProjectTest
    {
        [Test(Description = "Positive test of the getter Contacts")]
        public void TestContactsGet_CorrectValue()
        {
            var project = new Project();
            var expected = new ObservableCollection<Contact>()
            {
                new Contact ("Bogdanov", "Ilya", new PhoneNumber("71234567891"),
                new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                new Contact ("Romanova", "Elena", new PhoneNumber("71233557791"),
                new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
            };
            project.Contacts = expected;
            var actual = project.Contacts;
            Assert.AreEqual(expected, actual, "The Contacts getter " +
                "returns an incorrect list");
        }

        [Test(Description = "Positive test of the setter Contacts")]
        public void TestContactsSet_CorrectValue()
        {
            var project = new Project();
            var expected = new ObservableCollection<Contact>()
            {
                new Contact ("Bogdanov", "Ilya", new PhoneNumber("71234567891"),
                new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                new Contact ("Romanova", "Elena", new PhoneNumber("71233557791"),
                new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
            };
            Assert.DoesNotThrow(() =>
            {
                project.Contacts = expected;
            }, "The PhoneNumber setter accepts the correct phone number");
        }

        [Test(Description = "Test of the SortingContacts " +
            "when the input list is not empty")]
        public void TestSortingContacts_ListNotEmpty()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Bogdanov", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Romanova", "Elena", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Ponamarev", "Egor", new PhoneNumber("71254547791"),
                    new DateTime(2000, 11, 6), "nfld@gmail.com", "865945"),
                    new Contact ("Lopatkina", "Sasha", new PhoneNumber("71276543732"),
                    new DateTime(2008, 9, 18), "lss@yandex.com", "634724"),
                }
            };

            var expected = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Ponamarev", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Lopatkina", "Elena", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Bogdanov", "Egor", new PhoneNumber("71254547791"),
                    new DateTime(2000, 11, 6), "nfld@gmail.com", "865945"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71276543732"),
                    new DateTime(2008, 9, 18), "lss@yandex.com", "634724"),
                }
            };

            var actual = new Project
            {
                Contacts = Project.SortingContacts(project.Contacts)
            };

            Assert.AreEqual(expected.Contacts[1].Surname, 
                actual.Contacts[1].Surname, "Returns an unordered contacts");
        }

        [Test(Description = "Test of the SortingContacts " +
            "when the input list is empty")]
        public void TestSortingContacts_ListEmpty()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
            };
            var expected = new ObservableCollection<Contact>();
            var actual = Project.SortingContacts(project.Contacts);

            Assert.AreEqual(expected, actual, "The list is empty");
        }

        [Test(Description = "Test of the SortingContactsSubstring " +
            "when the input list is not empty")]
        public void TestSortingContactsSubstring_ListNotEmpty()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Ponamarev", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Bogdanov", "Egor", new PhoneNumber("71254547791"),
                    new DateTime(2000, 11, 6), "nfld@gmail.com", "865945"),
                    new Contact ("Krasnova", "Elena", new PhoneNumber("71276543732"),
                    new DateTime(2008, 9, 18), "lss@yandex.com", "634724"),
                }
            };
            var expected = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Krasnova", "Elena", new PhoneNumber("71276543732"),
                    new DateTime(2008, 9, 18), "lss@yandex.com", "634724"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                }
            };

            var actual = new Project
            {
                Contacts = Project.SortingContacts("va", project.Contacts)
            };

            Assert.AreEqual(expected.Contacts[1].Surname,
                actual.Contacts[1].Surname, "Returns an unordered contacts");
        }

        [Test(Description = "Test of the SortingContactsSubstring " +
            "when the input list is empty")]
        public void TestSortingContactsSubstring_ListEmpty()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
            };
            var expected = new List<Contact>();
            var actual = Project.SortingContacts("va", project.Contacts);

            Assert.AreEqual(expected, actual, "The list is empty");
        }

        [Test(Description = "Test of the SortingContacts with " +
            "the found substring in the name")]
        public void TestSortingContactsSubstring_Name()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Ponamarev", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Bogdanov", "Egor", new PhoneNumber("71254547791"),
                    new DateTime(2000, 11, 6), "nfld@gmail.com", "865945"),
                    new Contact ("Krasnova", "Dasha", new PhoneNumber("71276543732"),
                    new DateTime(2008, 9, 18), "lss@yandex.com", "634724"),
                }
            };
            var expected = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Krasnova", "Elena", new PhoneNumber("71276543732"),
                    new DateTime(2008, 9, 18), "lss@yandex.com", "634724"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                }
            };

            var actual = new Project
            {
                Contacts = Project.SortingContacts("ha", project.Contacts)
            };

            Assert.AreEqual(expected.Contacts[1].Surname,
                actual.Contacts[1].Surname, "Returns an unordered contacts");
        }

        [Test(Description = "Test of the SortingContactsSubstring" +
            "when the list does not contain a suitable contacty")]
        public void TestSortingContactsSubstring_NotContain()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Ponamarev", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Bogdanov", "Egor", new PhoneNumber("71254547791"),
                    new DateTime(2000, 11, 6), "nfld@gmail.com", "865945"),
                    new Contact ("Krasnova", "Dasha", new PhoneNumber("71276543732"),
                    new DateTime(2008, 3, 8), "lss@yandex.com", "634724"),
                }
            };
            var expected = new Project
            {
                Contacts = new ObservableCollection<Contact>()
            };
            var expectedString = JsonConvert.SerializeObject(expected.Contacts);

            var actual = new Project
            {
                Contacts = Project.SortingContacts("mm", project.Contacts)
            };
            var actualString = JsonConvert.SerializeObject(actual.Contacts);

            Assert.AreEqual(expectedString, actualString, "Returns an invalid value");
        }

        [Test(Description = "Test of the GetDateBirth" +
            "when the input list is not empty")]
        public void TestGetDateBirth_ListNotEmpty()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Ponamarev", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Bogdanov", "Egor", new PhoneNumber("71254547791"),
                    new DateTime(2000, 11, 6), "nfld@gmail.com", "865945"),
                    new Contact ("Krasnova", "Dasha", new PhoneNumber("71276543732"),
                    new DateTime(2008, 3, 8), "lss@yandex.com", "634724"),
                }
            };
            var expected = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Krasnova", "Dasha", new PhoneNumber("71276543732"),
                    new DateTime(2008, 3, 8), "lss@yandex.com", "634724"),

                }
            };

            var actual = new Project
            {
                Contacts = project.GetDateBirth(new DateTime(2011, 3, 8))
            };

            Assert.AreEqual(expected.Contacts[1].Surname,
                actual.Contacts[1].Surname, "Returns an unordered contacts");
        }

        [Test(Description = "Test of the GetDateBirth" +
            "when the input list is empty")]
        public void TestGetDateBirth_ListEmpty()
        {
            var project = new Project();
            var expected = new ObservableCollection<Contact>();
            var actual = project.GetDateBirth(new DateTime(2011, 3, 8));

            Assert.AreEqual(expected, actual, "The list is empty");
        }

        [Test(Description = "Test of the GetDateBirth" +
            "when the list does not contain a suitable contacty")]
        public void TestGetDateBirth_NotContain()
        {
            var project = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Ponamarev", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Romanova", "Sasha", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                    new Contact ("Bogdanov", "Egor", new PhoneNumber("71254547791"),
                    new DateTime(2000, 11, 6), "nfld@gmail.com", "865945"),
                    new Contact ("Krasnova", "Dasha", new PhoneNumber("71276543732"),
                    new DateTime(2008, 3, 8), "lss@yandex.com", "634724"),
                }
            };
            var expected = new Project
            {
                Contacts = new ObservableCollection<Contact>()
            };
            var expectedString = JsonConvert.SerializeObject(expected.Contacts);

            var actual = new Project
            {
                Contacts = project.GetDateBirth(new DateTime(2011, 12, 18))
            };
            var actualString = JsonConvert.SerializeObject(actual.Contacts);

            Assert.AreEqual(expectedString, actualString, "Returns an invalid value");
        }
    }
}
