using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab13_delegates;
using lab10;
using lab12_collections;

namespace lab13.UnitTests
{
    [TestClass]
    public class JournalSubscriberTests
    {
        [TestMethod]
        public void JournalEntryConstructor()
        {
            // Arrange
            bool expected = true;
            // Act
            JournalEntry<Person> journalElem = new JournalEntry<Person>("Coll1", "push", new Person[] { new Person("Bill") });
            bool result = journalElem.CollName == "Coll1" && journalElem.EventName == "push" && journalElem.EventParticipants[0].FirstName == "Bill";

            // Assert
            Assert.AreEqual(result, expected);
            
        }

        [TestMethod]
        public void JournalSubscriberConstructor()
        {
            // Arrange
            bool expected = true;
            // Act
            JournalSubscriber<Person> journal = new JournalSubscriber<Person>();
            bool result = journal.Journal.Count == 0;

            // Assert
            Assert.AreEqual(result, expected);

        }

       

    }
}
