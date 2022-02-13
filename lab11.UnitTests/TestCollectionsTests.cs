using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab11.UnitTests
{
    [TestClass]
    public class TestCollectionsTests
    {
        [TestMethod]
        public void ConstructorWithParams_CollectionsDefined()
        {
            // Arrange
            TestCollections test = new TestCollections(5);
            bool expected = true;
            // Act
            bool result = test.DictPerson != null && test.DictString != null && test.StackPerson != null && test.StackString != null;

            // Assert
            Assert.AreEqual(result, expected);
        }
        
        

    }
}
