using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class Stack<T>
    {
        private readonly Deque<T> store = new Deque<T>();


        public void Push(T value)
        {
            store.EnqueueHead(value);
        }

        public void Pop(T value)
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
