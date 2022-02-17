using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using lab12_collections;
using lab10;

namespace lab12.UnitTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void ConstrTwoParams_ReturnDataCurrAntonAndDataNextJackTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            QueueNode<Person> node = new QueueNode<Person>(new Person("Anton"), new QueueNode<Person>(new Person("Jack")));
            bool result = node.data.ToString() == "Anton" && node.next.data.ToString() == "Jack";

            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void ConstrOneParam_ReturnCurrDataAntonNextRefNull()
        {
            // Arrange
            bool expected = true;
            // Act
            QueueNode<Person> node = new QueueNode<Person>(new Person("Anton"));
            bool result = node.data.ToString() == "Anton" && node.next == null;

            // Assert
            Assert.AreEqual(result, expected);

        }
    }
}
