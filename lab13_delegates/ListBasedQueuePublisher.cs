using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using lab10;
using lab12_collections;


namespace lab13_delegates
{

    public class CollectionHandlerEventArgs<T> : EventArgs
    { 
        public CollectionHandlerEventArgs(string name, string evName, T[] obj)
        {
            Name = name;
            EventName = evName;
            EventParticipants = obj;
        }
        public string Name { get; set; }
        public string EventName { get; set; }
        public T[] EventParticipants { get; set; }
    }
    public class ListBasedQueuePublisher<T> : ListBasedQueue<T>, ICloneable, IEnumerable<T> where T : IEquatable<T>
    {
        public string Name { get; set; }

        public QueueNode<T> Head
        {
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<T>(Name, "changed", new T[] {head.data}));

                QueueNode<T> headNext = head.next;
                head = value;
                head.next = headNext;
            }
        }
        public ListBasedQueuePublisher(string name)
        {
            Name = name;
        }

        public event EventHandler<CollectionHandlerEventArgs<T>> OnCollectionCountChanged = delegate { };
        public event EventHandler<CollectionHandlerEventArgs<T>> OnCollectionReferenceChanged = delegate { };

        public override void Push(T obj)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "push(T obj)", new T[] {obj}));
            base.Push(obj);
        }

        public override void Push(T[] arr)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "push(T[] arr)", arr));
            base.Push(arr);
        }

        public override T Pop()
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "pop", new T[] { base.Pop() }));
            return default(T);
        }
    }
}


    
    


