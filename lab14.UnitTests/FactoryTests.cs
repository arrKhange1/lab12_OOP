using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab14;
using lab11;

namespace lab14.UnitTests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            bool expected = true;

            // Act
            Factory coll = new Factory();
            bool result = coll.stack != null;

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}

