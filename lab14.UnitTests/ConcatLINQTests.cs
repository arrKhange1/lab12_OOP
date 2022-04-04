using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab14;
using lab11;
using System.Linq;

namespace lab14.UnitTests
{
    [TestClass]
    public class ConcatLINQTests
    {
        [TestMethod]
        public void ConcatCollCount()
        {
            // Arrange
            bool expected = true;

            // Act
            Factory coll = new Factory();
            Filler.Fill(coll, 5);

            int firstColl = coll.stack.Select((Ceh ceh) => ceh.CehElem).First().Count;
            int secondColl = coll.stack.Select((Ceh ceh) => ceh.CehElem).Last().Count;

            bool result = firstColl + secondColl == ConcatLINQ.Concat(coll);

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
