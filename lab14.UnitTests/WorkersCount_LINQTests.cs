using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab14;
using lab11;
using System.Linq;

namespace lab14.UnitTests
{
    [TestClass]
    public class WorkersCount_LINQTests
    {
        [TestMethod]
        public void CollCount1()
        {
            // Arrange
            int expected = 1;

            // Act
            Factory coll = new Factory();
            FillerForTest.Fill(coll, 5);

            int result = WorkersCount_LINQForTest.Count(coll);

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}











