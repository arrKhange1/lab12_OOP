using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab11.UnitTests
{
    [TestClass]
    public class AdministrationTests
    {
        [TestMethod]
        public void ConstructorWithParams_StringHelloWorld()
        {
            // Arrange
            string expected = "HelloWorld";
            // Act
            Administration admin = new Administration("HelloWorld");
            string result = admin.FirstName;

            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Clone_AdminSasha_AdminPetya()
        {
            // Arrange
            Administration oneDima = new Administration("Sasha");

            // Act
            Administration secondDima = (Administration)oneDima.Clone();
            secondDima.FirstName = "Petya";
            // Assert
            Assert.AreNotEqual(oneDima.FirstName, secondDima.FirstName);
        }
        
    }
}
