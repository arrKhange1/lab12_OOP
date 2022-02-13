using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab10.UnitTests
{
    [TestClass]
    public class PersonComparerTests
    {
        [TestMethod]
        public void Compare_PersonDima_PersonAnton_Returns1()
        {
            // Arrange
            Person dima = new Person("Dima", 5);
            Person anton = new Person("Anton", 5);
            int expected = 1;
            // Act
            PersonComparer comparer = new PersonComparer();
            int result = comparer.Compare(dima, anton);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Compare_PersonAnton_PersonDima_ReturnsMinus1()
        {
            // Arrange
            Person dima = new Person("Dima", 5);
            Person anton = new Person("Anton", 5);
            int expected = -1;
            // Act
            PersonComparer comparer = new PersonComparer();
            int result = comparer.Compare(anton, dima);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Compare_PersonAnton_Person_Returns0()
        {
            // Arrange
            Person anton1 = new Person("Anton", 5);
            Person anton2 = new Person("Anton", 5);
            int expected = 0;
            // Act
            PersonComparer comparer = new PersonComparer();
            int result = comparer.Compare(anton1, anton2);
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}