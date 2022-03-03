using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab13_delegates;
using lab10;
using lab12_collections;

namespace lab13.UnitTests
{
    [TestClass]
    public class ListBasedQueuePublisherTests
    {
        [TestMethod]
        public void PublisherConstructor()
        {
            // Arrange
            string expected = "First";
            // Act
            ListBasedQueuePublisher<Person> list = new ListBasedQueuePublisher<Person>("First");
            string result = list.Name;

            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void PublisherHeadChangeEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueuePublisher<Person> list = new ListBasedQueuePublisher<Person>("First");
            JournalSubscriber<Person> journal = new JournalSubscriber<Person>();
            list.OnCollectionReferenceChanged += journal.Add;
            list.Push(new Person("Kane"));

            list.Head = new QueueNode<Person>(new Person("Jack"));

            bool result = list.head.data.ToString() == "Jack" && journal.Journal[0].EventName == "changed";

            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void PublisherPushObjEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueuePublisher<Person> list = new ListBasedQueuePublisher<Person>("First");
            JournalSubscriber<Person> journal = new JournalSubscriber<Person>();
            list.OnCollectionCountChanged += journal.Add;
            list.Push(new Person("Kane"));


            bool result = journal.Journal[0].EventName == "push(T obj)";

            // Assert
            Assert.AreEqual(result, expected);
            
        }

        [TestMethod]
        public void PublisherPushArrEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueuePublisher<Person> list = new ListBasedQueuePublisher<Person>("First");
            JournalSubscriber<Person> journal = new JournalSubscriber<Person>();
            list.OnCollectionCountChanged += journal.Add;
            list.Push(new Person[] { new Person("Kane"), new Person("Mike")});


            bool result = journal.Journal[0].EventName == "push(T[] arr)";

            // Assert
            Assert.AreEqual(result, expected);
            
        }


        [TestMethod]
        public void PublisherPopEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            ListBasedQueuePublisher<Person> list = new ListBasedQueuePublisher<Person>("First");
            JournalSubscriber<Person> journal = new JournalSubscriber<Person>();
            list.OnCollectionCountChanged += journal.Add;
            list.Push(new Person[] { new Person("Kane"), new Person("Mike") });
            list.Pop();


            bool result = journal.Journal[1].EventName == "pop";

            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void ArgsConstructor()
        {
            // Arrange
            bool expected = true;
            // Act
            CollectionHandlerEventArgs<Person> args = new CollectionHandlerEventArgs<Person>("coll1", "push", new Person[] { new Person("Ben") });
            bool result = args.Name == "coll1" && args.EventName == "push" && args.EventParticipants[0].FirstName == "Ben";


            // Assert
            Assert.AreEqual(result, expected);

        }

    }
}
