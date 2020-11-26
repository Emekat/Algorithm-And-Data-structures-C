using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class UnionFind
    {
        //num of elems ion union find
        private int size;

        //track tjhe sizes of each of the components
        private int[] sz;

        //points to the parent of i if id[i]=i then i is a root node
        private int[] id;

        private int numOfComponents;
        public UnionFind(int N)
        {
            if(N <=0)
                throw new InvalidOperationException("size <= 0 is not allowed");

            this.size = numOfComponents = N;
            id = new int[N];
            sz = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;//link to itself (selfroot)
                sz[i] = i;//each component is originally of size one
            }
        }

        //find the component set p belongs to
        public int Find(int p)
        {
          //find root of component/st
          int root = p;
          while (root != id[root])
          {
              root = id[root];
          }

          //compress the path leading back to the root (path compression) - ammortized constant time complexity
          while (p != root)
          {
              int next = id[p];
              id[p] = root;
              p = next;
          }

          return root;
        }

        //chase parent pointer until i == id[i], move i up one level of the tree, when theey are equal, you re in the root
        private int Root(int i)
        {
            while (i != id[i])
            {
                //flatten the tree
                //path compression
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }

        //O(n)
        //public void Union(int p, int q)
        //{
        //    int pid = id[p];
        //    int qid = id[q];
        //    for (int i = 0; i < id.Length; i++)
        //    {
        //        if (id[i] == pid)
        //            id[i] = qid;
        //    }
        //}

        //O(n)
        //chamge root of p to point to root of q
        //public void Union(int p, int q)
        //{
        //    int i = Root(p);
        //    int j = Root(q);

        //    id[i] = j;
        //}

        //link the root of the smaller tree to the root of thr larger tree after checking the size
        //O(logN)
        //weighted
        public void Union(int p, int q)
        {
            int root1 = Root(p);
            int root2 = Root(q);


            //elements are already in the same group
            if(root1 == root2)
                return;
            //merge two components/sets together
            if (sz[root1] < sz[root2])
            {
                id[root1] = root2;
                sz[root2] += sz[root1];
            }
            else
            {
                id[root2] = root1;
                sz[root1] += sz[root2];
            }
            //decrease number of components/sets by one

            numOfComponents--;
        }
        public bool Connected(int p, int q)
        {
            return id[p] == id[q];
            //or return Find(p) == Find(Q); //this does path compression
        }

        public int ComponentSize(int p)
        {
            return sz[Find(p)]; //this does path compression
        }

        public int Size()
        {
            return size; //this does path compression
        }

        public int Component()
        {
            return numOfComponents; //this does path compression
        }

        public void Unify(int p, int q)
        {
            int root1
        }
    }
}
