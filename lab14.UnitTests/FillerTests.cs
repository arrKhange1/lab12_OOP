using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab14;
using lab11;
using System.Linq;

namespace lab14.UnitTests
{
    [TestClass]
    public class FillerTests
    {
        [TestMethod]
        public void FilledWith5()
        {
            // Arrange
            int expected = 5;

            // Act
            Factory coll = new Factory();
            Filler.Fill(coll, 5);

            int result = coll.stack.Count;

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}

