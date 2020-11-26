using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class DoublyLinkedListNode<T>
    {
        public T Data;
       
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        public DoublyLinkedListNode()
        {
            this.Data = default(T);
            this.Prev = null;
            this.Next = null;
        }
        public DoublyLinkedListNode(T data, DoublyLinkedListNode<T> prev, DoublyLinkedListNode<T> next)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }

    }

}
