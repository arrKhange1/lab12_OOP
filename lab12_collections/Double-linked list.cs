using System;
using System.Collections.Generic;
using System.Text;

namespace lab12_collections
{
    class DoubleLinkedList<T> where T: IEquatable<T>
    {
        DoubleNode<T> head, tail;
        private int _count;
        public int Count { get { return _count; } }
        public DoubleLinkedList()
        {
            head = tail = null;
            _count = 0;
        }

        public void Delete()
        {
            head = tail = null;
            _count = 0;
            Console.WriteLine("DoubleLinkedList удален!");
        }
        public void Print()
        {
            DoubleNode<T> newHead = head;
            if (newHead == null) return;
            while (newHead != null)
            {
                if (newHead.data.GetType().Name == "Person" || newHead.data.GetType().Name == "Worker")
                    Console.WriteLine($"{newHead.data.ToString()}");
                else
                    Console.WriteLine($"{newHead.data} ");
                newHead = newHead.next;
            }

            Console.WriteLine($"Кол-во элементов: {Count}\n");
        }

        public void ReversedPrint()
        {
            if (head == null) return;
            DoubleNode<T> newTail = tail;
            while(newTail != null)
            {
                if (newTail.data.GetType().Name == "Person" || newTail.data.GetType().Name == "Worker")
                    Console.WriteLine($"{newTail.data.ToString()}");
                else
                    Console.WriteLine($"{newTail.data} ");
                newTail = newTail.prev;
            }
            Console.WriteLine($"Кол-во элементов: {Count}\n");
        }
        public void Add(T obj)
        {
            DoubleNode<T> newHead = head;
            if (newHead == null)
            {
                head = new DoubleNode<T>(obj);
                tail = head;
                ++_count;
                return;
            }
            tail.next = new DoubleNode<T>(obj);
            DoubleNode<T> prevTail = tail;
            tail = tail.next;
            tail.prev = prevTail;
            ++_count;
            
        }

        public void RemoveElement(T obj)
        {
            if (head == null) return;
            else if (head.data.Equals(obj) && head.next == null)
            {
                head = null;
                --_count;
                return;
            }
            DoubleNode<T> newHead = head;
            while(newHead != null)
            {
                if (newHead.data.Equals(obj) && newHead.prev == null) { head = newHead.next; --_count; }
                else if (newHead.data.Equals(obj)) 
                { 
                    newHead.prev.next = newHead.next;
                    if (newHead.next != null) newHead.next.prev = newHead.prev;
                    --_count; 
                }
                newHead = newHead.next;
            }
        }
    }
}
