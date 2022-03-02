using System;
using lab10;
using lab12_collections;

namespace lab13_delegates
{
    class Program
    {

        static void FirstPart(ListBasedQueuePublisher<Person> listFirst, JournalSubscriber<Person> journalFirst)
        {
            Console.WriteLine("\n--- События OnCountChanged and OnReferenceChanged на первой коллекции (Часть 1) ---\n");

            Console.WriteLine("Добавили элементы разными способами:\n");

            listFirst.Push(new Person("John"));
            listFirst.Push(new Person("Talor"));
            listFirst.Push(new Person[] { new Person("Ben"), new Person("Colin") });
            listFirst.Print();

            Console.WriteLine("Журнал:\n");
            journalFirst.Print();

            Console.WriteLine("Удалили элемент:\n");
            listFirst.Pop();
            listFirst.Print();
            Console.WriteLine("Журнал:\n");
            journalFirst.Print();

            Console.WriteLine("Поменяли ссылку на голову:\n");
            listFirst.Head = new QueueNode<Person>(new Person("Nick"));
            listFirst.Print();

            Console.WriteLine("Журнал:\n");
            journalFirst.Print();
        }

        static void SecondPart(ListBasedQueuePublisher<Person> listFirst, ListBasedQueuePublisher<Person> listSecond, JournalSubscriber<Person> journalSecond)
        {
            Console.WriteLine("\n--- События OnReferenceChanged из обеих коллекций (Часть 2) ---\n");

            listSecond.Push(new Person("Gilbert"));
            listSecond.Push(new Person("Stefan"));
            listSecond.Push(new Person[] { new Person("Amanda"), new Person("Christopher") });

            Console.WriteLine("list1:\n");
            listFirst.Print();

            Console.WriteLine("list2:\n");
            listSecond.Print();

            Console.WriteLine("Меняем ссылки на головы у обеих коллекций:\n");
            listFirst.Head = new QueueNode<Person>(new Person("Ashley"));
            listSecond.Head = new QueueNode<Person>(new Person("Ethan"));

            Console.WriteLine("list1:\n");
            listFirst.Print();

            Console.WriteLine("list2:\n");
            listSecond.Print();

            Console.WriteLine("Журнал:\n");
            journalSecond.Print();
        }

        static void Main(string[] args)
        {
            ListBasedQueuePublisher<Person> listFirst = new ListBasedQueuePublisher<Person>("First");
            ListBasedQueuePublisher<Person> listSecond = new ListBasedQueuePublisher<Person>("Second");

            JournalSubscriber<Person> journalFirst = new JournalSubscriber<Person>();
            JournalSubscriber<Person> journalSecond = new JournalSubscriber<Person>();


            listFirst.OnCollectionCountChanged += journalFirst.Add;
            listFirst.OnCollectionReferenceChanged += journalFirst.Add;
            listFirst.OnCollectionReferenceChanged += journalSecond.Add;

            listSecond.OnCollectionReferenceChanged += journalSecond.Add;

            FirstPart(listFirst, journalFirst);
            journalSecond.Journal.Clear(); // очистка от об изменении ссылки головы из первого задания
            Console.WriteLine("--------------------------------------");
            SecondPart(listFirst, listSecond, journalSecond);


        }
    }
}
