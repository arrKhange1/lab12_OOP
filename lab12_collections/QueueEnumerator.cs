using System;
using System.Collections.Generic;
using System.Collections;
using lab10;

namespace lab12_collections
{
    public class QueueEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
    {
        QueueNode<T> head = default(QueueNode<T>), fixedHead;
        int cnt = -1;
        public QueueEnumerator(QueueNode<T> head)
        {
            fixedHead = head;
        }

        public void Dispose() {}
        
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public T Current => head.data;

        public bool MoveNext()
        {
            if (cnt == -1) 
            {
                head = fixedHead;
                if (head == null) return false;
                ++cnt;
                return true;
            }
            else if (head != null)
            {
                head = head.next; 
                ++cnt;
            }
            if (head == null) return false;
            return true;
        }

        public void Reset()
        {
            cnt = -1;
            head = default(QueueNode<T>);
        }
    }
}