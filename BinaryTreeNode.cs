using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class BinaryTreeNode<T> : IComparable<T> 
        where T : IComparable<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public BinaryTreeNode(T value)
        {
            Data = value;
        }

        public BinaryTreeNode(BinaryTreeNode<T> left, BinaryTreeNode<T> right, T value):this(value)
        {
            Left = left;
            Right = right;
        }

        public int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(BinaryTreeNode<T> other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Data.CompareTo(other.Data);
        }

        public int CompareTo(T other)
        {
           return Data.CompareTo(other);
        }
    }
}
