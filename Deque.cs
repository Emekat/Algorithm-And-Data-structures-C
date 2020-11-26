 using System;
 using System.Collections;
 using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class Deque<T>:IEnumerable<T>
    {
        readonly DoublyLinkedList<T> store  = new DoublyLinkedList<T>();

        public void EnqueueTail(T value)
        {
            store.AddTail(value);
        }
        public void EnqueueHead(T value)
        {
            store.AddHead(value);
        }

        public T DequeueHead()
        {
            T value;
            if(store.GetHead(out value))
            {
                store.RemoveFirst();
                return value;
            }
            throw new InvalidOperationException();

        }

        public T DequeueTail()
        {
            T value;
            if (store.GetTail(out value))
            {
                store.RemoveFirst();
                return value;
            }
            throw new InvalidOperationException();

        }

        public bool PeekHead(out T value)
        {
            return store.GetHead(out value);
        }

        public bool PeekTail(out T value)
        {
            return store.GetTail(out value);
        }

        public int Count()
        {
            return store.Count;
        }
        public IEnumerator<T> GetEnumerator()
        {
           return store.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
