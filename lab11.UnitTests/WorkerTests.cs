using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab11.UnitTests
{
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void ConstructorWithParams_StringBen_StringTesla_StringEngineer()
        {
            // Arrange
            string expected = "BenTeslaEngineer";
            // Act
            Worker worker = new Worker("Ben", "Tesla", "Engineer");
            string result = worker.FirstName + worker.factoryName + worker.positionName;

            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Clone_EngineerSasha_EngineerPetya()
        {
            // Arrange
            Worker oneDima = new Worker("Sasha", "Tesla", "Engineer");

            // Act
            Worker secondDima = (Worker)oneDima.Clone();
            secondDima.FirstName = "Petya";
            // Assert
            Assert.AreNotEqual(oneDima.FirstName, secondDima.FirstName);
        }
        [TestMethod]
        public void GetterBaseClass_WorkerBen_Contains_PersonBen()
        {
            // Arrange
            bool expected = true;
            Worker worker = new Worker("Ben", "Tesla", "Cleaner");

            // Act
            bool result = worker.BasePerson.FirstName == worker.FirstName;
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Equals_NullObject()
        {
            // Arrange
            bool expected = false;
            Worker worker = new Worker("Ben", "Tesla", "Cleaner");

            // Act
            bool result = worker.Equals(null);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Equals_SameReference()
        {
            // Arrange
            bool expected = true;
            Worker worker = new Worker("Ben", "Tesla", "Cleaner");

            // Act
            bool result = worker.Equals(worker);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Equals_DifferentReffsSameData()
        {
            // Arrange
            bool expected = true;
            Worker worker1 = new Worker("Ben", "Tesla", "Cleaner");
            Worker worker2 = new Worker("Ben", "Tesla", "Cleaner");

            // Act
            bool result = worker1.Equals(worker2);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void GetHashCode_ReturnedInt()
        {
            // Arrange
            bool expected = true;
            Worker worker = new Worker("Ben", "Tesla", "Cleaner");


            // Act
            bool result = worker.GetHashCode().GetType().Name == "Int32";
            // Assert
            Assert.AreEqual(result, expected);
        }

    }
}
