using System;
using System.Collections.Generic;
using System.Text;
using lab10;

namespace lab12_collections
{
    class SingleNode<T>
    {
        public SingleNode(T data)
        {
            this.data = data;
            next = null;
        }
        public T data;
        public SingleNode<T> next;
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

