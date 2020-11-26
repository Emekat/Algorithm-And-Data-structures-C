using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class Array<T>:ICollection<T>
    {
        public int Count { get; }
        public bool IsReadOnly { get; }
        private T[] _arr;
        private readonly int _capacity;
        private int len = 0;

        public Array():this(16)
        {
            
        } 

        public Array(int capacity)
        {
            if (capacity < 0) throw new ArgumentException("Illegal Capacity: ");
            _capacity = capacity;
            _arr = new T[_capacity];
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

      

    }
}
