using StudentLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Tree
{
    [Serializable]
    /// <summary>
    /// This is a class for a binary tree
    /// </summary>
    /// <typeparam name="T">Type is everything that can be compared</typeparam>
    class Tree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Node to store a Root of a Tree
        /// </summary>
        private Node<T> Root { get; set; }

        /// <summary>
        /// List for balancing
        /// </summary>
        private List<Node<T>> NodesList { get; set; }

        /// <summary>
        /// Method to Adding a new Node to a Tree
        /// </summary>
        /// <param name="value">Inserted value</param>
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


        /// <summary>
        /// Method for a Tree Balancing
        /// </summary>
        public void Balance()
        {
            void ConvertTreeToList(Node<T> parent)
            {
                if(parent != null)
                {
                    ConvertTreeToList(parent.Left);
                    NodesList.Add(parent);
                    ConvertTreeToList(parent.Right);
                }
            }

            Node<T> NewParentCreation(List<Node<T>> nodes, int start, int finish)
            {
                if (start > finish)
                {
                    return null;
                }

                int middle = (start + finish) / 2;
                Node<T> newParent= nodes[middle];

                newParent.Left = NewParentCreation(nodes, start, middle - 1);
                newParent.Right = NewParentCreation(nodes, middle + 1, finish);

                return newParent;
            }

            ConvertTreeToList(Root);

            int newStart = NodesList.Count - ((NodesList.Count - 1) / 2);

            Node<T> newRoot = NodesList[newStart];

            newRoot.Left = NewParentCreation(NodesList, 0, newStart - 1);
            newRoot.Right = NewParentCreation(NodesList, newStart + 1, NodesList.Count - 1);

            Root = newRoot;
        } 

        /// <summary>
        /// Method for a serialization
        /// </summary>
        /// <param name="path">Output file path</param>
        public void Serialize(string path)
        {
            using(TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Tree<T>));
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Method for a deserialization
        /// </summary>
        /// <param name="path">Input File path</param>
        /// <returns>new tree</returns>
        public Tree<T> Deserialize(string path)
        {
            Tree<T> binaryTree;

            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Tree<T>));
                binaryTree = (Tree<T>)serializer.Deserialize(reader);
            }

            return binaryTree;
        }
    }
}
