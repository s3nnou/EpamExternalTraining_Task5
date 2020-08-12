using StudentLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TreeClass
{
    [Serializable]
    /// <summary>
    /// This is a class for a binary tree
    /// </summary>
    /// <typeparam name="T">Type is everything that can be compared</typeparam>
    public class Tree<T> where T : Student
    {
        /// <summary>
        /// Node to store a Root of a Tree
        /// </summary>
        private Node<T> Root { get; set; }

        /// <summary>
        /// List for balancing
        /// </summary>
        private List<Node<T>> NodesList = new List<Node<T>>();

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

                    if (currNode.Data.CompareTo(value) > 1)
                    {
                        currNode = currNode.Left;
                    }
                    else if(currNode.Data.CompareTo(value) == 0)
                    {
                        throw new ArgumentException("There are equal data");
                    }
                    else if(currNode.Data.CompareTo(value) < -1)
                    {
                        currNode = currNode.Left;
                    }
                }

                if (parentNode.Data.CompareTo(value) > 1)
                {
                    parentNode.Left = newNode;

                }
                else
                {
                    parentNode.Right = newNode;
                }

            }
            else
            {
                Root = new Node<T>(value);
            }
        }

        ///// <summary>
        ///// Method for a node finding
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns>node</returns>
        private Node<T> Find(T value)
        {
            return this.Find(value, this.Root);
        }

        /// <summary>
        /// Method for finding data in a tree
        /// </summary>
        /// <param name="value">data to find</param>
        /// <returns>found data</returns>
        public T FindData(T value)
        {
            Node<T> node = this.Find(value, this.Root);
            return node.Data;
        }

        /// <summary>
        /// Method for a navigation in a tree
        /// </summary>
        /// <param name="value">what to find</param>
        /// <param name="parent">where to find</param>
        /// <returns>found node</returns>
        private Node<T> Find(T value, Node<T> parent)
        {
            if (parent != null)
            {

                if (parent.Data.CompareTo(value) > 1)
                {
                    return Find(value, parent.Right);

                }
                else if (parent.Data.CompareTo(value) == 0)
                {
                    return parent;

                }

                else if (parent.Data.CompareTo(value) < -1)
                {

                    return Find(value, parent.Left);

                }

            }

            return null;
        }

        /// <summary>
        /// Method for a node data replacment
        /// </summary>
        /// <param name="originalValue">data to replace</param>
        /// <param name="newValue">new data</param>
        public void Replace(T originalValue, T newValue)
        {
            Node<T> nodeToReplace = Find(originalValue);
            if (nodeToReplace != null)
            {
                Node<T> newNode = new Node<T>(newValue);

                nodeToReplace.Data = newNode.Data;
            }
            else
            {
                throw new ArgumentNullException("There are no such value");
            }
        }

        /// <summary>
        /// Method for a Tree Balancing
        /// </summary>
        public void Balance()
        {

            Node<T> NewParentCreation(List<Node<T>> nodes, int start, int finish)
            {
                if (start > finish)
                {
                    return null;
                }

                int middle = (start + finish) / 2;
                Node<T> newParent = nodes[middle];

                newParent.Left = NewParentCreation(nodes, start, middle - 1);
                newParent.Right = NewParentCreation(nodes, middle + 1, finish);

                return newParent;
            }

            if (this.NodesList.Count() == 0)
            {
                ConvertTreeToList(Root);
            }

            int newStart = NodesList.Count - ((NodesList.Count) / 2);

            Node<T> newRoot = NodesList[newStart];

            newRoot.Left = NewParentCreation(NodesList, 0, newStart - 1);
            newRoot.Right = NewParentCreation(NodesList, newStart + 1, NodesList.Count - 1);

            Root = newRoot;

        }

        /// <summary>
        /// Utility Method for a tree conversion into the list of nodes
        /// </summary>
        /// <param name="parent">node to start</param>
        private void ConvertTreeToList(Node<T> parent)
        {
            if (parent != null)
            {
                ConvertTreeToList(parent.Left);
                NodesList.Add(parent);
                ConvertTreeToList(parent.Right);
            }
        }

        /// <summary>
        /// Method for a serialization
        /// </summary>
        /// <param name="path">Output file path</param>
        public void Serialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                if (this.NodesList.Count() == 0)
                {
                    ConvertTreeToList(Root);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                serializer.Serialize(fs, ToList());
            }
        }

        /// <summary>
        /// Method for a deserialization
        /// </summary>
        /// <param name="path">Input File path</param>
        /// <returns>new tree</returns>
        public void Deserialize(string path)
        {
            List<T> students;

            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                students = (List<T>)serializer.Deserialize(reader);
            }

            Root = null;
            NodesList.Clear();

            foreach (var item in students)
            {
                Add(item);
            };
        }

        /// <summary>
        /// Converts Tree to a List<T>
        /// </summary>
        /// <returns>List<T></returns>
        public List<T> ToList()
        {
            if(this.NodesList.Count() == 0)
            {
                this.ConvertTreeToList(this.Root);
            }

            List<T> newList = new List<T>();
            foreach(var item in NodesList)
            {
                newList.Add(item.Data);
            }

            return newList;
        }

        /// <summary>
        /// Method for Student objects class comparasion
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>true if equal, false is not</returns>
        public override bool Equals(object obj)
        {
            
            if (obj is Tree<T>)
            {
                Tree<T> tree = obj as Tree<T>;

                tree.ConvertTreeToList(tree.Root);

                if (this.NodesList.Count() == 0)
                {
                    this.ConvertTreeToList(this.Root);
                }

                if (tree.NodesList.Count == this.NodesList.Count)
                {
                    for(int i = 0; i < NodesList.Count; i++)
                    {
                        if (!tree.NodesList[i].Equals(this.NodesList[i]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates HashCode
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            if (this.NodesList.Count() == 0)
            {
                this.ConvertTreeToList(this.Root);
            }

            return Root.GetHashCode() ^ NodesList.GetHashCode() ^ NodesList.Count.GetHashCode() ^ NodesList.Select(obj => obj.GetHashCode()).Sum();
        }

        /// <summary>
        /// Returns Student data in a text format
        /// </summary>
        /// <returns>text</returns>
        public override string ToString()
        {
            if (this.NodesList.Count() == 0)
            {
                this.ConvertTreeToList(this.Root);
            }

            var stringBuilder = new StringBuilder();

            foreach (Node<T> node in NodesList)
            {
                stringBuilder.Append(node.Data.ToString());
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}
