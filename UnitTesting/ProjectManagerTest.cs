using System;
using System.Collections.Generic;
using System.Text;
using ContactsApp;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Collections.ObjectModel;

namespace UnitTesting
{
    class ProjectManagerTest
    {
        public static readonly string path =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Data.txt";

        public static readonly string referencePath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
            + "\\ReferencePath\\Data.txt";

        public static readonly string incorrectData =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
            + "\\ReferencePath\\IncorrectData.txt";

        public static readonly string nonЕxistentPath = "..\\nkbrnb\\fbk.txt";


        [Test(Description = "A test writing to a file")]
        public void TestWriteToFile_WithCreatedFile()
        {
            ProjectManager.Path = path;
            if (File.Exists(ProjectManager.Path))
            {
                File.Delete(ProjectManager.Path);
            }
            File.Create(ProjectManager.Path).Close();

            var newProject = new Project
            {
                Contacts = new ObservableCollection<Contact>()
                {
                    new Contact ("Bogdanov", "Ilya", new PhoneNumber("71234567891"),
                    new DateTime(2013, 6, 7), "tryfe@gmail.com", "795566"),
                    new Contact ("Romanova", "Elena", new PhoneNumber("71233557791"),
                    new DateTime(2011, 3, 8), "gbf@yandex.com", "807463"),
                }
            };
            var expectedString = JsonConvert.SerializeObject(newProject);
            ProjectManager.WriteToFile(newProject);
            var actualString = File.ReadAllText(ProjectManager.Path);
            Assert.AreEqual(expectedString, actualString,
                "An exception may occur if the file cannot be saved");
        }

        [Test(Description = "A positive test reading from a file")]
        public void TestReadFromFile_CorrectData()
        {
            ProjectManager.Path = path;
            if (File.Exists(ProjectManager.Path))
            {
                File.Delete(ProjectManager.Path);
            }
            File.Create(ProjectManager.Path).Close();
            var expectedString = File.ReadAllText(referencePath);
            var expectedProject = JsonConvert.DeserializeObject<Project>(expectedString);
            File.WriteAllText(ProjectManager.Path, expectedString);
            var actualProject = ProjectManager.ReadFromFile();
            Assert.AreEqual(expectedProject.Contacts[0].Surname,
                actualProject.Contacts[0].Surname, "Different file contents");
        }

        [Test(Description = "A negative test reading from a file")]
        public void TestReadFromFile_IncorrectData()
        {
            var expected = new Project();
            ProjectManager.Path = incorrectData;

            var actual = ProjectManager.ReadFromFile();
            Assert.AreEqual(expected.Contacts, actual.Contacts, "Different file contents");
        }

        [Test(Description = "A test reading to a nonexistent file path")]
        public void TestReadFromFile_NonexistentFilePath()
        {
            var expected = new Project();
            ProjectManager.Path = nonЕxistentPath;
            var actual = ProjectManager.ReadFromFile();
            Assert.AreEqual(expected.Contacts, actual.Contacts,
                "An exception may occur if the path does not exist");
        }
    }
}
