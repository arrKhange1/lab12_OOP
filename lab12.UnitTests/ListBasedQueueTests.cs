using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab12_collections;
using lab10;

namespace lab12.UnitTests
{
    [TestClass]
    public class ListBasedQueueTests
    {
        [TestMethod]
        public void GetEnumerator_ReturnHeadData_Anton()
        {
            // Arrange
            string expected = "Anton";
            // Act
            ListBasedQueue < Person > q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            var enumer = q.GetEnumerator();
            enumer.MoveNext();
            string result = enumer.Current.ToString();

            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void CopyConstr_ReturnDifferentHeadRefs()
        {
            // Arrange
            bool expected = false;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            ListBasedQueue<Person> q1 = new ListBasedQueue<Person>(q);
            bool result = q1.head == q.head;
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void MemberwiseCopy_ReturnSameHeadRefs()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            ListBasedQueue<Person> q1 = (ListBasedQueue<Person>)q.Memberwise();
            
            bool result = q1.head == q.head;
            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void Clone_ReturnEqualElemsAndDifferentRefsTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            q.Push(new Worker("Dima"));
            ListBasedQueue<Person> q1 = (ListBasedQueue<Person>)q.Clone();
            bool result = true;
            while(q1.head != null)
            {
                if (q1.head == q.head || q.head.data.ToString() != q1.head.data.ToString()) result = false;
                q1.head = q1.head.next;
                q.head = q.head.next;
            }

            // Assert
            Assert.AreEqual(result, expected);

        }


        [TestMethod]
        public void DeleteQueue_ReturnNull()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            q.Delete();

            bool result = q.head == null;
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void Contains_ReturnContainsAntonTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            bool contains = q.Contains(new Person("Anton"));

            bool result = contains == true;
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void Push_ReturnOneElemAntonTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            

            bool result = q.Count == 1 && q.head.data.ToString() == "Anton";
            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void PushtoNonEmptyQueue_ReturnTwoElemAntonTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Jora"));
            q.Push(new Worker("Ben"));
            q.Push(new Person("Anton"));


            bool result = q.head.data.ToString() == "Jora" && q.head.next.data.ToString() == "Ben" && q.head.next.next.data.ToString() == "Anton";
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void PushSome_ReturnTwoElemsAntonAndIgorTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person[] { new Person("Anton"), new Person("Igor")});


            bool result = q.Count == 2 && q.head.data.ToString() == "Anton" && q.head.next.data.ToString() == "Igor";
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void PushSomeNonEmptyQueueHeadAndNextAlready_ReturnTwoElemsAntonAndIgorTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Bill"));
            q.Push(new Person("Sasha"));
            q.Push(new Person[] { new Person("Anton"), new Person("Igor") });


            bool result = q.Count == 4 &&  q.head.data.ToString() == "Bill" && q.head.next.data.ToString() == "Sasha" && q.head.next.next.data.ToString() == "Anton" && q.head.next.next.next.data.ToString() == "Igor";
            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void PushSomeNonEmptyQueue_ReturnTwoElemsAntonAndIgorTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Bill"));
            q.Push(new Person[] { new Person("Anton"), new Person("Igor") });


            bool result = q.Count == 3 && q.head.data.ToString() == "Bill" && q.head.next.data.ToString() == "Anton" && q.head.next.next.data.ToString() == "Igor";
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void Pop_ReturnZeroElemAndHeadNullTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person("Anton"));
            q.Pop();

            bool result = q.Count == 0 && q.head == null;
            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void PopSome_ReturnZeroElemAndHeadNullTrue()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueue<Person> q = new ListBasedQueue<Person>();
            q.Push(new Person[] { new Person("Anton"), new Person("Igor") });
            q.Pop(2);

            bool result = q.Count == 0 && q.head == null;
            // Assert
            Assert.AreEqual(result, expected);

        }
    }
}
