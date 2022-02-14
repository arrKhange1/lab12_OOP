using System;
using System.Collections.Generic;
using System.Text;
using lab10;

namespace lab12_collections
{
    public class QueueNode<T>
    {
        public QueueNode(T data, QueueNode<T> next)
        {
            this.data = data;
            this.next = next;
        }
        public QueueNode(T data)
        {
            this.data = data;
            next = null;
        }
        public T data;
        public QueueNode<T> next;
    }

    class DoubleNode<T>
    {
        public DoubleNode(T data)
        {
            this.data = data;
            next = null;
            prev = null;
        }

        public T data;
        public DoubleNode<T> next, prev;
    }
}

