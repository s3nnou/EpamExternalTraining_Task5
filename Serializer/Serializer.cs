using Serializer;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace SerializerClass
{
    /// <summary>
    /// Class for a serializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomSerializer<T>: ISerialize
    {
        /// <summary>
        /// Serialization for any item into xml format
        /// </summary>
        /// <param name="obj">item to serialize</param>
        /// <param name="filePath">path to the file</param>
        public void SerializeToXml(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(T));
                dataContractSerializer.WriteObject(fs, obj);
            }
        }

        /// <summary>
        /// Serialization for any item from xml format
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>item class</returns>
        public T DeserializeFromXml(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                DataContractSerializer DataContractSerializer = new DataContractSerializer(typeof(T));
                return (T)DataContractSerializer.ReadObject(fs);
            }
        }

        /// <summary>
        /// Serialization for any item into dat format
        /// </summary>
        /// <param name="obj">item to serialize</param>
        /// <param name="filePath">path to the file</param>
        public void SerializeToBinary(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Serialization for any item from dat format
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>item class</returns>
        public T DeserializeFromBinary(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(fs);
            }
        }

        /// <summary>
        /// Serialization for any item into json format
        /// </summary>
        /// <param name="obj">item to serialize</param>
        /// <param name="filePath">path to the file</param>
        public void SerializeToJson(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                dataContractJsonSerializer.WriteObject(fs, obj);
            }
        }

        /// <summary>
        /// Serialization for any item from json format
        /// </summary>
        /// <param name="filePath">path to the file</param>
        /// <returns>item class</returns>
        public T DeserializeFromJson(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)dataContractJsonSerializer.ReadObject(fs);
            }
        }
    }
}
