using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClassModels
{
    /// <summary>
    /// Class for a  ICollection<T> class serialization and deserialization demostration work
    /// </summary>
    /// <typeparam name="T">Class Type to store</typeparam>
    [Serializable]
    [DataContract]
    public class CatsCollection<T> : ICollection<T> where T : Cat, IExtensibleDataObject
    {
        [NonSerialized]
        /// <summary>
        /// Round-tripping between different versions of the type
        /// </summary>
        ExtensionDataObject serializationData;

        /// <summary>
        /// Inner class collection
        /// </summary>
        [DataMember]
        private List<T> _cats;

        /// <summary>
        /// Class constructor
        /// </summary>
        public CatsCollection()
        {
            _cats = new List<T>();
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        public CatsCollection(IEnumerable<T> cats)
        {
            _cats = cats.ToList();
        }
        /// <summary>
        /// Class inner collection item indexer
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>item</returns>
        public T this[int index] => (T)_cats[index];

        /// <summary>
        /// Stores any data from the future version of the type that is unknown to the current version
        /// </summary>
        ExtensionDataObject ExtensionData
        {
            get
            {
                return serializationData;
            }
            set { serializationData = value; }
        }

        /// <summary>
        /// Collection state
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Method for an item search
        /// </summary>
        /// <param name="value">item to find</param>
        /// <returns>if it's there - true, else - false</returns>
        public bool Contains(T value)
        {
            bool found = false;

            foreach (T item in _cats)
            {
                
                if (value.Equals(item))
                {
                    found = true;
                }
            }

            return found;
        }

        /// <summary>
        /// Method for an item addition
        /// </summary>
        /// <param name="value">item to add</param>
        public void Add(T value)
        {

            if (!Contains(value))
            {
                _cats.Add(value);
            }
            else
            {
                throw new ArgumentException("Cannot contain equal items");
            }
        }

        /// <summary>
        /// Method for a collection wipe
        /// </summary>
        public void Clear() => _cats.Clear();

        /// <summary>
        /// Method for a copying
        /// </summary>
        /// <param name="array">array to copy to</param>
        /// <param name="arrayIndex">from where</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection");

            _cats.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns current collection size
        /// </summary>
        public int Count => _cats.Count;

        /// <summary>
        /// Method for an item removal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value) => _cats.Remove(value);

        /// <summary>
        /// Enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator() => _cats.GetEnumerator();

        /// <summary>
        /// Gets an enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Method for hashcode calculation
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return _cats.Select(obj => obj.GetHashCode()).Sum() ^ Count.GetHashCode();
        }

        /// <summary>
        /// Method for IComparable implimetation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 - if bigger, 0 - if equal, -1 - if not</returns>
        public override bool Equals(object obj)
        {
            if (obj is CatsCollection<T>)
            {
                CatsCollection<T> collection = obj as CatsCollection<T>;

                if (collection.Count == this.Count)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        if (!collection[i].Equals(_cats[i]))
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
        /// Returns collection data in a text format
        /// </summary>
        /// <returns>text</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in _cats)
            {
                stringBuilder.Append(item.ToString());
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }


}

