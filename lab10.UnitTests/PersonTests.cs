using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab10.UnitTests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Number_ConstructorWithoutParams()
        {
            // Arrange
            var number = new Number();
            int expected = 1;
            // Act
            int result = number.Num;
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Number_ConstructorWithParams()
        {
            // Arrange
            var number = new Number(5);
            int expected = 5;
            // Act
            int result = number.Num;
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Number_ToString()
        {
            // Arrange
            var number = new Number(5);
            string expected = "5";
            // Act
            string result = number.ToString();
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void ConstructorWithoutParams_nEquals1_FirstNameEqualsNoName()
        {
            // Arrange
            string firstNameExpected = "NoName";
            int numExpected = 1;
            // Act
            Person person = new Person();
            // Assert
            Assert.AreEqual(person.FirstName, firstNameExpected);
            Assert.AreEqual(person.n.Num, numExpected);
        }
        [TestMethod]
        public void ConstructorWithtParams_nEquals5_FirstNameEqualsHelloWorld()
        {
            // Arrange
            string firstNameExpected = "HelloWorld";
            int numExpected = 5;
            // Act
            Person person = new Person("HelloWorld",5);
            // Assert
            Assert.AreEqual(person.FirstName, firstNameExpected);
            Assert.AreEqual(person.n.Num, numExpected);
        }
        [TestMethod]
        public void ConstructorWithtParams_nEquals1_FirstNameEqualsHelloWorld()
        {
            // Arrange
            string firstNameExpected = "HelloWorld";
            int numExpected = 1;
            // Act
            Person person = new Person("HelloWorld", new Number());
            // Assert
            Assert.AreEqual(person.FirstName, firstNameExpected);
            Assert.AreEqual(person.n.Num, numExpected);
        }
        [TestMethod]
        public void CompareTo_PersonDima_To_PersonAnton() 
        {
            // Arrange
            bool expected = true;
            // Act
            Person oneDima = new Person("Dima", 5);
            bool result = oneDima.CompareTo(new Person("Anton", 10)) > 0; // Dima is more than Anton
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CompareTo_PersonDima_To_string()
        {
            // Arrange
            Person oneDima = new Person("Dima", 5);
            // Act

            // Assert
            Assert.ThrowsException<System.Exception>(() => oneDima.CompareTo("Anton"));
        }
        [TestMethod]
        public void Clone_Dima5_SecondDima5()
        {
            // Arrange
            Person oneDima = new Person("Dima", 5);

            // Act
            Person secondDima = (Person)oneDima.Clone();
            secondDima.FirstName = "SecondDima";
            // Assert
            Assert.AreNotEqual(oneDima.FirstName, secondDima.FirstName);
        }
        [TestMethod]
        public void Getter_nEquals5()
        {
            // Arrange
            int expected = 5;
            // Act
            int result = new Person("Dima", 5).Num;
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Setter_nEquals1()
        {
            // Arrange
            int expected = 1;
            // Act
            Person person = new Person();
            person.Num = -5;
            int result = person.Num;
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Setter_nEquals200()
        {
            // Arrange
            int expected = 200;
            // Act
            Person person = new Person();
            person.Num = 200;
            int result = person.Num;
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
