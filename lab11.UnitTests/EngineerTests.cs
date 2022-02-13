using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab11.UnitTests
{
    [TestClass]
    public class EngineerTests
    {
        [TestMethod]
        public void ConstructorWithParams_StringBen_StringTesla_StringEngineer()
        {
            // Arrange
            string expected = "BenTeslaEngineer";
            // Act
            Engineer engineer = new Engineer("Ben", "Tesla", "Engineer");
            string result = engineer.FirstName + engineer.factoryName + engineer.positionName;

            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Clone_EngineerSasha_EngineerPetya()
        {
            // Arrange
            Engineer oneDima = new Engineer("Sasha", "Tesla", "Engineer");

            // Act
            Engineer secondDima = (Engineer)oneDima.Clone();
            secondDima.FirstName = "Petya";
            // Assert
            Assert.AreNotEqual(oneDima.FirstName, secondDima.FirstName);
        }

    }
}
