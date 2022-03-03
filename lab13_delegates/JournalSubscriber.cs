using System;
using System.Collections.Generic;
using System.Text;
using lab10;
using lab12_collections;

namespace lab13_delegates
{

    public class JournalEntry<T>
    {
        public JournalEntry(string name, string evName, T[] obj)
        {
            CollName = name;
            EventName = evName;
            EventParticipants = obj;
        }
        public string CollName { get; set; }
        public string EventName { get; set; }
        public T[] EventParticipants { get; set; }
    }
    public class JournalSubscriber<T>
    {
        public List<JournalEntry<T>> Journal;

        public JournalSubscriber()
        {
            Journal = new List<JournalEntry<T>>();
        }

        public void Add(object source, CollectionHandlerEventArgs<T> args)
        {
            JournalEntry<T> journalElem = new JournalEntry<T>(args.Name, args.EventName, args.EventParticipants);
            Journal.Add(journalElem);
        }

        public void Print()
        {
            foreach(var elem in Journal)
            {
                Console.WriteLine($"CollectionName: {elem.CollName}, EventName: {elem.EventName}, EventParticipants: ");
                foreach(var eventParticipant in elem.EventParticipants)
                {
                    Console.WriteLine($"{eventParticipant.ToString()} ");
                }
                Console.WriteLine();
            }
        }
    }
}
