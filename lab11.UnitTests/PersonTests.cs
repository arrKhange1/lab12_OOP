using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab11.UnitTests
{
    [TestClass]
    public class PersonTests
    {
        
        [TestMethod]
        public void ToString_Person_To_String()
        {
            // Arrange
            string expected = "Vova";
            Person person = new Person("Vova");
            // Act
            string result = person.ToString();
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void Equals_NullObject()
        {
            // Arrange
            bool expected = false;
            Person person = new Person("Ben");

            // Act
            bool result = person.Equals(null);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Equals_SameReference()
        {
            // Arrange
            bool expected = true;
            Person person = new Person("Ben");
            // Act
            bool result = person.Equals(person);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Equals_DifferentReffsSameData()
        {
            // Arrange
            bool expected = true;
            Person person1 = new Person("Ben");
            Person person2 = new Person("Ben");

            // Act
            bool result = person1.Equals(person2);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void GetHashCode_ReturnedInt()
        {
            // Arrange
            bool expected = true;
            Person person = new Person("Ben");


            // Act
            bool result = person.GetHashCode().GetType().Name == "Int32";
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void CompareTo_PersonDima_To_PersonAnton()
        {
            // Arrange
            bool expected = true;
            // Act
            Person oneDima = new Person("Dima");
            bool result = oneDima.CompareTo(new Person("Anton")) > 0; // Dima is more than Anton
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CompareTo_PersonDima_To_string()
        {
            // Arrange
            Person oneDima = new Person("Dima");
            // Act

            // Assert
            Assert.ThrowsException<System.Exception>(() => oneDima.CompareTo("Anton"));
        }
        [TestMethod]
        public void Clone_PersonSasha_PersonPetya()
        {
            // Arrange
            Person oneDima = new Person("Dima");

            // Act
            Person secondDima = (Person)oneDima.Clone();
            secondDima.FirstName = "Petya";
            // Assert
            Assert.AreNotEqual(oneDima.FirstName, secondDima.FirstName);
        }
    }
}
