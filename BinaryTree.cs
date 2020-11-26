using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AlgoAndDs
{
    /// <summary>
    /// References: William Fisset
    /// Data Structure and Algorithm (Syncfusion)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T>:IEnumerable<T>
    where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        

        public int Count { get; private set; }

        public bool AddNode(T value)
        {
            if (Contains(value))
            {
                return false;
            }

            _head = Add(_head, value);
            Count++;
            return true;
        }


        private BinaryTreeNode<T> Add(BinaryTreeNode<T> node, T value)
        {
            //base case: found leaf node
            if(node == null)
                node = new BinaryTreeNode<T>(null, null, value);
            else
            {
                //place elems values in left subtree
                if (value.CompareTo(node.Data) < 0)
                {
                    node.Left = Add(node.Left, value);
                }
                else
                {
                    node.Right = Add(node.Right, value);
                }
            }

            return node;
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            //value is less than current node value
            if (value.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                {
                    //no left, make it new left node
                    node.Left = new BinaryTreeNode<T>(null, null, value);
                }
                else
                {
                    //add to left node
                    AddTo(node.Left, value);
                }
            }
            else
            {
                //if theres no right add to the right
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(null, null, value);
                }
                else
                {
                    //add to Right node
                    AddTo(node.Right, value);
                }
            }
          
        }
        public bool Contains(T value)
        {
            return Contains(_head, value);
        }

        public bool Contains(BinaryTreeNode<T> node, T value)
        {
            if (node == null) return false;
            int cmp = value.CompareTo(node.Data);

            //dig into left subtree
            if (cmp < 0)
                return Contains(node.Left, value);

            //dig into right subtree
            if (cmp > 0)
                return Contains(node.Right, value);

            //found the value
            else return true;
        }
        
        //computes height of tree (O(n))
        public int Height()
        {
            return Height(_head);
        }

        //recursive helper method to compute the height of the tree
        private int Height(BinaryTreeNode<T> node)
        {
            if (node == null) return 0;
            return Math.Max(Height(node.Left), Height(node.Left)) + 1;
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool Remove(T value)
        {
            if (Contains(value))
            {
                _head = Remove(_head, value);
                Count--;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Remove syncfusion way
        //public bool Remove(T value)
        //{
        //    BinaryTreeNode<T> current, parent;
     
        //    // Find the node to remove.
        //    current = FindWithParent(value, out parent);
      
        //    if (current == null)
        //    {
        //        return false;
        //    }

        //    Count--;

        //    // Case 1: If current has no right child, current's left replaces current.
        //    if (current.Right == null)
        //    {
        //        if (parent == null)
        //        {
        //            _head = current.Left;
        //        }
        //        else
        //        {

        //            int result = parent.CompareTo(current.Data);
        //            if (result > 0)
        //            {
        //                // If parent value is greater than current value,
        //                // make the current left child a left child of parent.

        //                parent.Left = current.Left;
        //            }
        //            else if (result < 0)
        //            {
        //                // If parent value is less than current value,
        //                // make the current left child a right child of parent.
        //                parent.Right = current.Left;
        //            }
        //        }
        //    }
        //    // Case 2: If current's right child has no left child, current's right child
        //    //         replaces current.
        //    else if (current.Right.Left == null)
        //    {
        //        current.Right.Left = current.Left;
        //        if (parent == null)
        //        {
        //            _head = current.Right;
        //        }
        //        else
        //        {
        //            int result = parent.CompareTo(current.Data);
        //            if (result > 0)
        //            {
        //                // If parent value is greater than current value,
        //                // make the current right child a left child of parent.
        //                parent.Left = current.Right;
        //            }
        //            else if (result < 0)
        //            {
        //                // If parent value is less than current value,
        //                // make the current right child a right child of parent.
        //                parent.Right = current.Right;
        //            }
        //        }
        //    }

        //    // Case 3: If current's right child has a left child, replace current with current's
        //    //         right child's left-most child.
        //    else
        //    {
        //        // Find the right's left-most child.
        //        BinaryTreeNode<T> leftmost = current.Right.Left;
        //        BinaryTreeNode<T> leftmostParent = current.Right;
        //        while (leftmost.Left != null)
        //        {
        //            leftmostParent = leftmost;
        //            leftmost = leftmost.Left;
        //        }
        //        // The parent's left subtree becomes the leftmost's right subtree.

        //        leftmostParent.Left = leftmost.Right;
        //        // Assign leftmost's left and right to current's left and right children.

        //        leftmost.Left = current.Left;
        //        leftmost.Right = current.Right;
        //        if (parent == null)
        //        {
        //            _head = leftmost;
        //        }
        //        else
        //        {
        //            int result = parent.CompareTo(current.Data);
        //            if (result > 0)
        //            {
        //                // If parent value is greater than current value,
        //                // make leftmost the parent's left child.
        //                parent.Left = leftmost;
        //            }
        //            else if (result < 0)
        //            {
        //                // If parent value is less than current value,
        //                // make leftmost the parent's right child.
        //                parent.Right = leftmost;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public bool Contains(T value)
        //{
        //    // Defer to the node search helper function.
        //    BinaryTreeNode<T> parent;
        //    return FindWithParent(value, out parent) != null;
        //}


        /// <summary>
        /// Finds and returns the first node containing the specified value. If the value
        /// is not found, it returns null. Also returns the parent of the found node (or null)
        /// which is used in Remove.
        /// </summary>
        //private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        //{
        //    // Now, try to find data in the tree.
        //    BinaryTreeNode<T> current = _head;
        //    parent = null;
        //    // While we don't have a match...
        //    while (current != null)
        //    {
        //        int result = current.CompareTo(value);
        //        if (result > 0)
        //        {
        //            // If the value is less than current, go left.
        //            parent = current;
        //            current = current.Left;
        //        }
        //        else if (result < 0)
        //        {
        //            // If the value is more than current, go right.
        //            parent = current;
        //            current = current.Right;
        //        }
        //        else
        //        {
        //            // We have a match!
        //            break;
        //        }
        //    }
        //    return current;
        //}

        private BinaryTreeNode<T> Remove(BinaryTreeNode<T> node, T value)
        {
            if (node == null)
                return null;
            int cmp = value.CompareTo(node.Data);

            //dig into left subtree, if the value we're looking for is smaller than the current value
            if (cmp < 0)
            {
                node.Left = Remove(node.Left, value);
            }
            //dig into right subtree, if the value we're looking for is smaller than the current value
            else if (cmp > 0)
            {
                node.Left = Remove(node.Right, value);
            }
            //find node you want to emove
            else
            {
                //happens with only a right subtree or no subtree at all. 
                if (node.Left == null)
                {
                    var rightChild = node.Right;
                    node.Data = default(T);
                    node = null;
                    return rightChild;
                }
                else if (node.Right == null)
                {
                    var leftChild = node.Left;
                    node.Data = default(T);
                    node = null;
                    return leftChild;
                }
                else
                {
                    //find the leftmost (smallest) value in right subtree by traversing as far left as possible in the right subtree
                    BinaryTreeNode<T> tmp = DigLeft(node.Right);

                    //swap the data
                    node.Data = tmp.Data;

                    //remove smallest value just swiped
                    node.Right = Remove(node.Right, tmp.Data);

                    //according to William Fisset
                    //if we wanted to find the largest node in left sub tree. Here is what to do
                    //var tmp = DigRight(node.Left);
                    // node.Data = tmp.Data;
                    //node.Left = Remove(node.Left, tmp.Data);
                }
            }

            return node;
        }

        private BinaryTreeNode<T> DigLeft(BinaryTreeNode<T> nodeRight)
        {
           var current = nodeRight;
           while (current.Left != null)
           {
               current = current.Left;
           }

           return current;
        }

        private BinaryTreeNode<T> DigRight(BinaryTreeNode<T> nodeLeft)
        {
            var current = nodeLeft;
            while (current.Right != null)
            {
                current = current.Right;
            }

            return current;
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        //O(n)
        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        public void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Data);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        //O(n)
        public void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {

                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Data);
            }
        }
        //used when the nod emust be processed in sort order
        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head); 
        }

        //O(n)
        public void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {

                InOrderTraversal(action, node.Left);
                action(node.Data);
                InOrderTraversal(action, node.Right);
               
            }
        }

        //non recursive
        public IEnumerator<T> InOrderTraversal()
        {
            if (_head != null)

            {
                // Store the nodes we've skipped in this stack (avoids recursion).
                var stack = new System.Collections.Generic.Stack<BinaryTreeNode<T>>();

                BinaryTreeNode<T> current = _head;

                // When removing recursion, we need to keep track of whether
                // we should be going to the left node or the right nodes next.
                bool goLeftNext = true;

                // Start by pushing Head onto the stack.
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // If we're heading left...
                    if (goLeftNext)
                    {

                        // Push everything but the left-most node to the stack.
                        // // We'll yield the left-most after this block.
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    // Inorder is left->yield->right.
                    yield return current.Data;

                    // If we can go right, do so.
                    if (current.Right != null)
                    {
                        current = current.Right;
                        // Once we've gone right once, we need to start
                        // going left again.
                        goLeftNext = true;
                    }
                    else
                    {
                        // If we can't go right, then we need to pop off the parent node
                        // so we can process it and then go to its right node.
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
