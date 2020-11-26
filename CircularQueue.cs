using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class CircularQueue<T>
    {
        private int _max;
        private T[] _element;
        private int _rear;
        private int _front;
        private int _count;
        public CircularQueue(int size)
        {
            _max = size;
            _element = new T[_max];
            _rear = -1;
            _front = 0;
            _count = 0;
        }

        public void Enqueue(T value)
        {
            if (_count == _max)
            {
                //add to front of list
                return;
            }
            else
            {
                _rear = (_rear + 1) % _max;
                _element[_rear] = value;
                _count++;
            }
        }

        public T Dequeue(T value)
        {
            if (_count == 0)
            {
                //add to front of list
                throw new InvalidOperationException("Queue is empty");
            }
            else
            {
                return _element[_rear];
            }
        }

      

        public void Delete()
        {
            if (_count == 0)
            {
                //add to front of list
                throw new InvalidOperationException("Queue is empty");
            }
            else
            {
                _front = (_front + 1) % _max;
                _count--;
            }
        }

        public void PrintQueue()
        {
            
            if (_count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0, j = 0; j < _count; i = (i + 1) % _max, j++)
                {
                    Console.WriteLine("Item[" + (i + 1) +"]: "+ _element[i]);

                }
            }
        }
    }
}
