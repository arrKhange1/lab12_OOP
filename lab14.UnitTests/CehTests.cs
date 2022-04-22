using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab14;
using lab11;

namespace lab14.UnitTests
{
    [TestClass]
    public class CehTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            string expected = "Ceh";
            bool expected2 = true;

            // Act
            Ceh ceh = new Ceh("Ceh");
            string result = ceh.Name;
            bool result2 = ceh.CehElem != null;

            // Assert
            Assert.AreEqual(result, expected);
            Assert.AreEqual(result2, expected2);
        }
    }
}
