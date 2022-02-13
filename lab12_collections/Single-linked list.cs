using System;
using System.Collections.Generic;
using System.Text;
using lab10;

namespace lab12_collections
{
    class SingleLinkedList<T>  where T : IEquatable<T>
    {
        SingleNode<T> head;
        private int _count;
        public int Count { get { return _count; } }
        public SingleLinkedList()
        {
            head = null;
            _count = 0;
        }

        public void Delete()
        {
            head = null;
            _count = 0;
            Console.WriteLine("SingleLinkedList удален!");
        }
        public void Print()
        {
            SingleNode<T> newHead = head;
            if (newHead == null) return;
            while(newHead != null)
            {
                if (newHead.data.GetType().Name == "Person" || newHead.data.GetType().Name == "Worker")
                    Console.WriteLine($"{newHead.data.ToString()}");
                else
                    Console.WriteLine($"{newHead.data} ");
                newHead = newHead.next;
            }
            Console.WriteLine();
        }
        public void Add(T obj)
        {
            SingleNode<T> newHead = head;
            if (newHead == null)
            {
                head = new SingleNode<T>(obj);
                ++_count;
                return;
            }
            while(newHead.next != null)
                newHead = newHead.next;

            newHead.next = new SingleNode<T>(obj);
            ++_count;

            
        }
        public void AddAfter(T obj)
        {
            if (head == null) return;

            SingleNode<T> newHead = head;
            while(newHead != null)
            {
                if (newHead.data.Equals(obj)) //&& (newHead.data.GetType().Name == "Person" && obj.GetType().Name == "Person" || newHead.data.GetType().Name == "Worker" && obj.GetType().Name == "Worker"))
                {
                    SingleNode<T> next = newHead.next;
                    SingleNode<T> newObj = new SingleNode<T>(obj);
                    newHead.next = newObj;
                    newObj.next = next;
                    newHead = newObj;
                    ++_count;
                }
                newHead = newHead.next;

            }
        }
    }
}
