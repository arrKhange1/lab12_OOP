using System;
using lab10;

namespace lab12_collections
{
    class Program
    {
        static void ListBasedQueue()
        {
            ListBasedQueue<Person> q1 = new ListBasedQueue<Person>();
            Console.WriteLine($"Элементов в очереди: {q1.Count}\n");
            q1.Push(new Person[] { new Person("Nathan"), new Worker("David") });
            q1.Push(new Person("Ivan"));
            q1.Push(new Worker("Jenya", "NLMK", "Master"));
            

            q1.Print();
            Console.WriteLine($"Элементов в очереди: {q1.Count}\n");
            Console.WriteLine($"Существует Jenya? - {q1.Contains(new Worker("Jenya"))}\n");
            Console.WriteLine($"Существует Igor? - {q1.Contains(new Worker("Igor"))}\n");

            q1.Pop();
            q1.Print();
            Console.WriteLine($"Элементов в очереди: {q1.Count}\n");


            q1.Push( new Person[] {new Person("Nathan"), new Worker("David")});
            Console.WriteLine($"Элементов в очереди: {q1.Count}\n");
            q1.Print();
            Console.WriteLine($"Существует Nathan? - {q1.Contains(new Person("Nathan"))}\n");
            q1.Pop(2);
            q1.Print();
            Console.WriteLine($"Элементов в очереди: {q1.Count}\n");

            // --------------------------
            Console.WriteLine("--------------- q1 copied to q2 via constructor ---------------------------------------\n");
            ListBasedQueue<Person> q2 = new ListBasedQueue<Person>(q1);
            q1.head.data = new Person("Q1");
            q1.Print();
            q2.Print();
            Console.WriteLine($"Элементов в очереди: {q2.Count}\n");

            // ------------------------
            Console.WriteLine("--------------- Deep clone q1 ---------------------------------------\n");
            var q3  = (ListBasedQueue<Person>)q1.Clone();
            q3.head.data = new Person("Q3");
            Console.WriteLine("q1:\n");
            q1.Print();
            Console.WriteLine("q3 (deep copy of q1)\n");
            q3.Print();

            // -----------
            Console.WriteLine("--------------- Memberwise clone q1 ---------------------------------------\n");
            var q4 = (ListBasedQueue<Person>)q1.Memberwise();
            q4.head.data = new Person("Q4");
            Console.WriteLine("q1:\n");
            q1.Print();
            Console.WriteLine("q4 (memberwise copy of q1)\n");
            q4.Print();

            // ----------
            System.Console.WriteLine("------------ foreach --------------------------\n");
            
            var qForEach = new ListBasedQueue<Person>();

            qForEach.Push(new Worker("Anton"));

            qForEach.Print();

            foreach(var item in qForEach)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
        static void Main(string[] args)
        {
            ListBasedQueue();
            
            
        }
    }
}
