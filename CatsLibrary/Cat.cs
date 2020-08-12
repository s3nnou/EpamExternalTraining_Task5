using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ClassModels
{
    /// <summary>
    /// Class for a basic model class serialization and deserialization demostration work
    /// </summary>
    [Serializable]
    [DataContract]
    public class Cat: IExtensibleDataObject
    {
        [NonSerialized]
        /// <summary>
        /// Round-tripping between different versions of the type
        /// </summary>
        ExtensionDataObject serializationData;

        /// <summary>
        /// Cat's name
        /// </summary>
        [DataMember]
        private string _name;

        /// <summary>
        /// Cat's weight
        /// </summary>
        [DataMember]
        private UInt16 _weight;
        
        /// <summary>
        /// Cat's color
        /// </summary>
        [DataMember]
        private Color _color;

        /// <summary>
        /// Cat Class constructor
        /// </summary>
        public Cat() { }

        /// <summary>
        /// Cat Class constructor
        /// </summary>
        public Cat(string name, UInt16 weight, Color color)
        {
            Name = name;
            Weight = weight;
            Color = color;
        }

        public string Name { get => _name; set => _name = value; }
        public ushort Weight { get => _weight; set => _weight = value; }
        public Color Color { get => _color; set => _color = value; }

        /// <summary>
        /// Stores any data from the future version of the type that is unknown to the current version
        /// </summary>
        ExtensionDataObject IExtensibleDataObject.ExtensionData
        {
            get
            {
                return serializationData;
            }
            set { serializationData = value; }
        }

        /// <summary>
        /// Method for IComparable implimetation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 - if bigger, 0 - if equal, -1 - if not</returns>
        public override bool Equals(object obj)
        {
            if(obj is Cat)
            {
                Cat cat = obj as Cat;

                return cat.Name == this.Name && cat.Weight == this.Weight && cat.Color == this.Color;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for hashcode calculation
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Weight.GetHashCode() ^ this.Color.GetHashCode();
        }

        /// <summary>
        /// Returns Cat's data in a text format
        /// </summary>
        /// <returns>text</returns>
        public override string ToString()
        {
            return string.Format($"Cat: {Name} - {Weight} - {Color}");
        }
    }
}
