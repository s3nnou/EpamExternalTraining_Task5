using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    class Tree<T> where T : IComparable<T>
    {
        Node<T> Root { get; set; }

        public void Add(T value)
        {
            if(Root != null)
            {
                Node<T> currNode = Root;
                Node<T> newNode = new Node<T>(value);
                Node<T> parentNode = null;

                while (currNode != null)
                {
                    parentNode = currNode;

                    if (currNode.Data.CompareTo(value) == 1)
                    {
                        currNode = currNode.Left;
                    }
                    else if(currNode.Data.CompareTo(value) == 0)
                    {
                        throw new ArgumentException("There are equal data");
                    }
                    else if(currNode.Data.CompareTo(value) == -1)
                    {
                        currNode = currNode.Left;
                    }
                }

                if (parentNode.Data.CompareTo(value) == 1)
                {
                    parentNode = currNode.Left;

                }
                else
                {
                    parentNode  = currNode.Left;
                }

            }
            else
            {
                Root = new Node<T>(value);
            }
        }
    }
}
