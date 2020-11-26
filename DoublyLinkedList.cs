using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AlgoAndDs
{
    public class DoublyLinkedList<T>:ICollection<T>
    {
        private int _size = 0;
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }


        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public bool IsEmpty()
        {
            return Count == 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            //yield helps to write function that helps u to access values one at a time useing
            //built inb c# function such as for loop

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetReverseEnumerator()
        {
            DoublyLinkedListNode<T> current = Tail;
        
            while (current != null)
            {
                yield return current.Data;
                current = current.Prev;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

     

      
        public void Add(T item)
        {
            if (Head == null)
            {
                Head = new DoublyLinkedListNode<T>(item, null, null);
            }
            else
            {
                DoublyLinkedListNode<T> node = Head;
                //loop until last node
                while (node != null)
                {
                    node = node.Next;
                }
                //or
                //for(; node.Next != null; node = node.Next){}
                node.Next = new DoublyLinkedListNode<T>(item, null, null);
            }

            _size++;
        }

        public void Add(T item, int index)
        {
            int internalIndex = 0;
            
            if (Head == null)
            {
                Head = new DoublyLinkedListNode<T>(item, null, null);
            }
            else
            {
                DoublyLinkedListNode<T> node = Head;
                DoublyLinkedListNode<T> existingNode;
                //loop until index and get node at index

                for (; node != null; node = node.Next, internalIndex++)
                {
                    if (internalIndex == index)
                    {
                        if (node.Data == null)
                        {
                            existingNode = node;
                            node.Next = new DoublyLinkedListNode<T>(item, existingNode.Prev, existingNode);
                        }
                      
                    }
                }
                
            }

            _size++;
        }

        /// <summary>
        /// Find the index of a value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int IndexOf(Object obj)
        {
            int index = 0;
            DoublyLinkedListNode<T> trav;
            if (obj == null)
            {
                for (trav = Head; trav != null; trav = trav.Next, index++)
                {
                    if (trav.Data == null)
                    {
                        return index;
                    }
                }
            }
            else
            {
                for (trav = Head; trav != null; trav = trav.Next, index++)
                {
                    if (obj.Equals(trav.Data))
                    {
                        return index;
                    }
                }
            }
            return -1;
        }
        public void AddFirst(T item)
        {
            if (IsEmpty())
            {
                Head = Tail = new DoublyLinkedListNode<T>(item, null, null);
            }
            else
            {
                Head.Prev = new DoublyLinkedListNode<T>(item, null, Head);
                Head = Head.Prev;
            }
            Count++; 
        }


        public void AddHead (T item)
        {
            //Allocate the new node
            //new node.. doesnt have a previous node cos it's new
            var adding = 
                new DoublyLinkedListNode<T>(item, null, Head);
          
            //if there was an existing head node
            //update its previous pointer to the new node
            if (Head != null)
            {
                Head.Prev = adding;
            }

            //set the header pointer to the new node
            Head = adding;

            //if the list was empty (tails is null)
            if (Tail == null)
            {
                //the head and tail are the same
                Tail = Head;
            }

            //increment count value
            Count++;
        }

     
        public void Clear()
        {
            //go thru list na deallocate
            DoublyLinkedListNode<T> trav = Head;
            while (trav != null)
            {
                DoublyLinkedListNode<T> next = trav.Next;
                trav.Prev = trav.Next = null;
                trav.Data = default(T);
                trav = next;
            }

            Head = Tail = trav = null;
            _size = 0;
        }
        public void AddLast(T item)
        {
            if (IsEmpty())
            {
                Head = Tail = new DoublyLinkedListNode<T>(item, null, null);
            }
            else
            {
                Tail.Next = new DoublyLinkedListNode<T>(item, Tail, null);
                Tail = Tail.Next;
            }
            Count++;
        }
        public void AddTail(T item)
        {
            //set previous of new node to existing node
            if (Tail != null)
            {
               AddHead(item);
            }
            else
            {
                var adding =
                    new DoublyLinkedListNode<T>(item, Tail, null);
                Tail.Next = adding;
                Tail = adding;
                Count++;
            }
        }

        public bool GetHead(out T value)
        {
            value = default;
            return false;
        }

        public bool GetTail(out T value)
        {
            value = default;
            return false;
        }
      
        
        public bool Contains(T item)
        {
           //or return Find(item) != null;
           return IndexOf(item) != -1;
        }

        public T PeekFirst()
        {
            if(IsEmpty())
                throw new Exception("Empty List");
            return Head.Data;
        }
        public T PeekLast()
        {
            if (IsEmpty())
                throw new Exception("Empty List");
            return Tail.Data;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
                throw new Exception("Empty List");

            //extract data at the head and move the head pointer forwards one node
            T data = Head.Data;
            Head = Head.Next;
            --_size;

            //if the list is empty set the tail to nul as well
            if (IsEmpty()) Tail = null;

            //do memory clean of the previous node
            else
                Head.Prev = null;
           
            return data;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
                throw new Exception("Empty List");

            //extract data at the head and move the head pointer forwards one node
            T data = Tail.Data;
            Tail = Tail.Prev;
            --_size;

            //if the list is empty set the tail to nul as well
            if (IsEmpty()) Head = null;

            //do memory clean of the previous node
            else
                Tail.Next = null;

            return data;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        private T Remove(DoublyLinkedListNode<T> node)
        {
            if (node.Prev == null) return RemoveFirst();
            if (node.Next == null) return RemoveLast();
            
            //make the pointerd skio over nodes
            node.Next.Prev = node.Next;
            node.Prev.Next = node.Next;

            //Temp store the data we want to return
            T data = node.Data;

            //clean memory
            node.Data = default(T);
            node = node.Prev = node.Next = null;

            --_size;
            //retruen data at node removed
            return data;
        }


        private T RemoveAt(int index)
        {
            if (index < 0 || index >= _size) 
                throw new ArgumentException("Invalid index");

            int i;
            DoublyLinkedListNode<T> trav;

            //search from first of list
            //check if index is closer to the front or back.. stil linear
            if (index < _size / 2)
            {
                for (i = 0, trav = Head; i != index; i++)
                    trav = trav.Next;
            }
            else
            {
                for (i = 0, trav = Tail; i != index; i--)
                    trav = trav.Next;
            }

            return Remove(trav);

        }

        /// <summary>
        /// Remove the first occurrence of the item fromthe lidt
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            var found = Find(item);
            if (found == null)
                return false;

            var previous = found.Prev;
            var next = found.Next;

            if (previous == null)
            {
                //remove the head node
                Head = next;
                if (Head != null)
                {
                    Head.Prev = null;
                }
            }
            else
            {
                previous.Next = next;
            }

            if (next == null)
            {
                //remove the tail
                Tail = previous;
                if (Tail != null)
                {
                    Tail.Next = null;
                }
            }
            else
            {
                next.Prev = previous;
            }

            Count--;
            return true;
        }

        /// <summary>
        /// Remove the  occurrence of the item fromthe lidt
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Remove(Object obj)
        {
            DoublyLinkedListNode<T> trav = Head;
            if (obj == null)
            {
                for (trav = Head; trav != null; trav = trav.Next)
                {
                    if (trav.Data == null)
                    {
                        Remove(trav);
                        return true;
                    }
                }
            }
            else
            {
                for (trav = Head; trav != null; trav = trav.Next)
                {
                    if (obj.Equals(trav.Data))
                    {
                        Remove(trav);
                        return true;
                    }
                }
            }
            return false;
        }
        private DoublyLinkedListNode<T> Find(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return current;
                }

                current = current.Next;
            }
            return null;
        }

      

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            DoublyLinkedListNode<T> trav = Head;
            while (trav != null)
            {
                sb.Append(trav.Data + ", ");
                trav = trav.Next;
            }
            return sb.ToString();
        }
    }
}
