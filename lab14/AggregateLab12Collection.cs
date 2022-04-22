using System;
using System.Collections.Generic;
using System.Text;
using lab12_collections;
using lab11;

namespace lab14
{
    class AggregateLab12Collection
    {
        public static void Aggregate()
        {
            ListBasedQueue<int> list = new ListBasedQueue<int>();
            list.Push(new int[] { 1, 3, 2, 5, 4, 6, 8, 7, 9, 10 });

            Console.WriteLine("Aggregate Collection:\n");
            foreach (var elem in list) Console.Write(elem + " ");
            Console.WriteLine("\n");



            var result = list.Select(a => a % 2 == 0).Aggregate((a, b) => a+b); 
            Console.Write("Aggregate Result: ");
            Console.WriteLine(result + "\n");
        }
    }
}
