using System;
using lab10;

namespace lab12_collections
{
    class Program
    {
        static void SingleLinkedList()
        {
            SingleLinkedList<Person> list = new SingleLinkedList<Person>();
            
            list.Add(new Worker ("John", "Tesla", "Slesar"));
            list.Add(new Person("Bill"));
            list.Print();
            list.AddAfter(new Person("Bill"));
            list.AddAfter(new Worker("John")); // добавляет это тк сравнение по классу персон (в качестве Т передаем Person)
            list.Print();
            Console.WriteLine(list.Count);
            list.Delete();
            Console.WriteLine(list.Count);

            Console.WriteLine("----------------------\n");

            DoubleLinkedList<Person> doubleList = new DoubleLinkedList<Person>();
            doubleList.Add(new Worker("John", "Tesla", "Slesar"));
            doubleList.Add(new Person("Bill"));
            doubleList.Add(new Worker("Bill"));
            doubleList.Add(new Worker("Hanna"));
            doubleList.Print();
            doubleList.ReversedPrint();

            doubleList.RemoveElement(new Person("Bill"));
            Console.WriteLine("Rev:");
            doubleList.ReversedPrint();

            Console.WriteLine("Print:");

            doubleList.Print();

            doubleList.Delete();
        }
        static void Main(string[] args)
        {
            SingleLinkedList();
            
            
        }
    }
}
