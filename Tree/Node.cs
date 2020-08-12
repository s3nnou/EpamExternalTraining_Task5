using System;

namespace TreeClass
{
    /// <summary>
    /// Class for node representation
    /// </summary>
    /// <typeparam name="T">Generic</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="data">Data</param>
        public Node(T data)
        {
            Left = null;
            Right = null;
            Data = data;
        }

        /// <summary>
        /// Left side
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right side
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Data to handle
        /// </summary>
        public T Data { get; set; }

    }
}
