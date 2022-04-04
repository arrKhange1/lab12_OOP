using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab14;
using lab11;
using System.Linq;

namespace lab14.UnitTests
{
    [TestClass]
    public class IntersectLINQTests
    {
        [TestMethod]
        public void CollCount0()
        {
            // Arrange
            int expected = 0;

            // Act
            Factory coll = new Factory();
            FillerForTest.Fill(coll, 5);

            int result = IntersectionLINQ.Intersect(coll);

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
