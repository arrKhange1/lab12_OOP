using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace lab12_collections
{
    public class ListBasedQueue<T>: ICloneable, IEnumerable<T> where T: IEquatable<T>
    {
        public QueueNode<T> head;
        private int _count;
        public int Count { get { return _count; }  }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(head);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public ListBasedQueue()
        {
            head = null;
            _count = 0;
        }

        public ListBasedQueue(ListBasedQueue<T> collToCopy)
        {
            head = ((ListBasedQueue<T>)collToCopy.Clone()).head;
            _count = collToCopy._count;
        }

        public virtual object Clone()
        {
            if (head == null) return null;
            ListBasedQueue<T> cloned = new ListBasedQueue<T>();
            QueueNode<T> newHead = head, savedClonedHead;
            cloned.head = new QueueNode<T>(head.data);
            savedClonedHead = cloned.head;
            newHead = newHead.next;

            while(newHead != null)
            {
                cloned.head.next = new QueueNode<T>(newHead.data);
                newHead = newHead.next;
                cloned.head = cloned.head.next;
            }
            cloned.head = savedClonedHead;
            cloned._count = _count;

            return cloned;

        }

        public object Memberwise()
        {
            return MemberwiseClone();
        }


        public void Delete()
        {
            head = null;
            _count = 0;
            Console.WriteLine("ListBasedQueue удалена!");
        }
        public void Print()
        {
            QueueNode<T> newHead = head;
            if (newHead == null) return;
            while (newHead != null)
            {
                if (newHead.data.GetType().Name == "Person" || newHead.data.GetType().Name == "Worker")
                    Console.WriteLine($"{newHead.data.ToString()}");
                else
                    Console.WriteLine($"{newHead.data} ");
                newHead = newHead.next;
            }
            Console.WriteLine();
        }

        public bool Contains(T obj)
        {
            QueueNode<T> newHead = head;
            bool contains = false;
            while(newHead != null)
            {
                if (newHead.data.Equals(obj)) contains = true;
                newHead = newHead.next;
            }
            return contains;
        }
        public void Push(T obj)
        {
            QueueNode<T> newHead = head;
            if (newHead == null)
            {
                head = new QueueNode<T>(obj);
                ++_count;
                return;
            }
            while (newHead.next != null)
                newHead = newHead.next;

            newHead.next = new QueueNode<T>(obj);
            ++_count;


        }

        public void Push(T[] arr)
        {
            if (head == null)
            {
                head = new QueueNode<T>(arr[0]);
                QueueNode<T> newHead = head;
                for (int i = 1; i < arr.Length; ++i)
                {
                    newHead.next = new QueueNode<T>(arr[i]);
                    newHead = newHead.next;
                }
                
            }
            else
            {
                QueueNode<T> newHead = head;
                while (newHead.next != null)
                    newHead = newHead.next;
                
                for (int i = 0; i < arr.Length; ++i)
                {
                    newHead.next = new QueueNode<T>(arr[i]);
                    newHead = newHead.next;
                }
            }

            _count += arr.Length;




        }
        
        public void Pop()
        {
            if (head == null) return;
            
            head = head.next;
            --_count;
        }

        public void Pop(int num)
        {
            if (head == null) return;
            
            for (int i = 0; i< num && head != null; ++i)
            {
                head = head.next;
                --_count;
            }
        }
    }
}

