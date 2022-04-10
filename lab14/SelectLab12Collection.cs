using System;
using System.Collections.Generic;
using System.Text;
using lab12_collections;
using lab11;

namespace lab14
{
    class SelectLab12Collection
    {
        public static void Select()
        {
            ListBasedQueue<Person> list = new ListBasedQueue<Person>();
            list.Push(new Person[] { new Worker("Ben", "Milkiway", "Slesar"), new Person("Jack"), new Worker("Ben","Tesla", "Cleaner"), new Worker("Ben", "Twix", "Engineer"), new Person("Smith"), });

            Console.WriteLine("Lab12Collection:\n");
            foreach (var elem in list) Console.WriteLine(elem.ToString());
            Console.WriteLine();

            var result = list.Select(a => a.FirstName == "Ben");
            Console.WriteLine("Select Result:\n");
            foreach (var elem in result) Console.WriteLine(elem.ToString());
            Console.WriteLine();
        }
    }
}
