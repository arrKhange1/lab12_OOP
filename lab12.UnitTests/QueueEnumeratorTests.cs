using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using lab10;
using lab12_collections;

namespace lab12.UnitTests
{
    [TestClass]
    public class QueueEnumeratorTests
    {
        [TestMethod]
        public void Constr_ReturnFixedHeadCurrHeadAreEqualTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            QueueEnumerator<Person> enumer = new QueueEnumerator<Person>(q.head);
            bool result = enumer.fixedHead == q.head;
            

            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void PropertyCurrent_ReturnAntonTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            QueueEnumerator<Person> enumer = new QueueEnumerator<Person>(q.head);
            enumer.MoveNext();
           
            bool result = enumer.Current.ToString() == "Anton";


            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void MoveNext_ReturnCurrentHeadAntonAndHeadEqualToFixedHeadTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            QueueEnumerator<Person> enumer = new QueueEnumerator<Person>(q.head);
            enumer.MoveNext();
            bool result = enumer.head.data.ToString() == "Anton" && enumer.head == enumer.fixedHead;

            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void MoveNext_ReturnCurrHeadAndFixedHeadAreNullTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            QueueEnumerator<Person> enumer = new QueueEnumerator<Person>(q.head);
            enumer.MoveNext();
            bool result = enumer.head == null && enumer.fixedHead == null;

            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void MoveNext_ReturnAllToObjectsTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person[] { new Person("Anton"), new Person("Jack") });
            QueueEnumerator<Person> enumer = new QueueEnumerator<Person>(q.head);
            enumer.MoveNext();
            var head = enumer.head.data.ToString();
            enumer.MoveNext();
            var head1 = enumer.head.data.ToString();
            bool result = head == "Anton" && head1 == "Jack";

            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void MoveNext_ReturnFalseAsEnumeratorEnds()
        {
            // Arrange
            bool expected = false;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person[] { new Person("Anton"), new Person("Jack") });
            QueueEnumerator<Person> enumer = new QueueEnumerator<Person>(q.head);
            enumer.MoveNext();
            var head = enumer.head.data.ToString();
            enumer.MoveNext();
            bool result = enumer.MoveNext();

            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void Reset_ReturnHeadNullTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person[] { new Person("Anton"), new Person("Jack") });
            QueueEnumerator<Person> enumer = new QueueEnumerator<Person>(q.head);
            enumer.MoveNext();
            enumer.Reset();
            bool result = enumer.head == null;

            // Assert
            Assert.AreEqual(result, expected);

        }
    }
}
