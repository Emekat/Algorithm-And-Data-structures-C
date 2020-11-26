using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class BSTNode<T>
    {
        public T Data;
        public BSTNode<T> Left;
        public BSTNode<T> Right;
        public BSTNode(T value)
        {
            Data = value;
        }
    }
}
