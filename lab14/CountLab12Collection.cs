using System;
using System.Collections.Generic;
using System.Text;
using lab12_collections;
using lab11;

namespace lab14
{
    class CountLab12Collection
    {
        public static void Count()
        {
            ListBasedQueue<Person> list = new ListBasedQueue<Person>();
            list.Push(new Person[] { new Worker("Ben", "Milkiway", "Slesar"), new Person("Jack"), new Worker("Ben", "Tesla", "Cleaner"), new Worker("Ben", "Twix", "Engineer"), new Person("Smith"), });

            int result = list.Select(a => a.FirstName == "Ben").GetCount();
            Console.WriteLine($"Count Result: {result}\n");
        }
    }
}
