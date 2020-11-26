using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class Queue<T>
    {
        private readonly Deque<T> store = new Deque<T>();

     
        public void Enqueue(T value)
        {
            store.EnqueueTail(value);
        }

        public void Dequeue(T value)
        {
            store.DequeueHead();
        }

        public T Peek()
        {
            T value;
            if (store.PeekHead(out value))
            {
                return value;
            }
            throw new InvalidOperationException();
        }
        public int Count
        {
            get
            {
                return store.Count();
            }

        }

    }
}
