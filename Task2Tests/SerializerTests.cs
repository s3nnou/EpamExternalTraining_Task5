using ClassModels;
using SerializerClass;
using System;
using System.Collections.Generic;
using Xunit;

namespace Task2Tests
{
    public class SerializerTests
    {
        /// <summary>
        /// XML serialization and deserialization test for a one instanse of class
        /// </summary>
        /// <param name="cat">Cat object to be serialized</param>
        /// <param name="filepath">path to the file</param>
        [Theory]
        [MemberData(nameof(Data1))]
        public void XML_SerializationAndDeserialization_ForAClassObject_Test(Cat cat, string filepath)
        {
            CustomSerializer<Cat> serializer = new CustomSerializer<Cat>();

            serializer.SerializeToXml(cat, filepath);

            Cat t_cat = serializer.DeserializeFromXml(filepath);

            Assert.Equal(cat, t_cat);
        }

        /// <summary>
        /// Data for a  XML_SerializationAndDeserialization_ForAClassObject test
        /// </summary>
        public static IEnumerable<object[]> Data1 =>
        new List<object[]>
        { 
            new object[] { new Cat("Barsik", 5, Color.red),
            new string(@"..\..\..\..\Res\Task21.xml")},
            new object[] { new Cat("Kesha", 15, Color.white),
            new string(@"..\..\..\..\Res\Task21.xml")},
            new object[] { new Cat("Murka", 6, Color.black),
            new string(@"..\..\..\..\Res\Task21.xml")},
        };

        /// <summary>
        /// Binary serialization and deserialization test for a one instanse of class
        /// </summary>
        /// <param name="cat">Cat object to be serialized</param>
        /// <param name="filepath">path to the file</param>
        [Theory]
        [MemberData(nameof(Data2))]
        public void Binary_SerializationAndDeserialization_ForAClassObject_Test(Cat cat, string filepath)
        {
            CustomSerializer<Cat> serializer = new CustomSerializer<Cat>();

            serializer.SerializeToBinary(cat, filepath);

            Cat t_cat = serializer.DeserializeFromBinary(filepath);

            Assert.Equal(cat, t_cat);
        }

        /// <summary>
        /// Data for a Dat_SerializationAndDeserialization_ForAClassObject test
        /// </summary>
        public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {
            new object[] { new Cat("Barsik", 5, Color.red),
            new string(@"..\..\..\..\Res\Task21.dat")},
            new object[] { new Cat("Kesha", 15, Color.white),
            new string(@"..\..\..\..\Res\Task21.dat")},
            new object[] { new Cat("Murka", 6, Color.black),
            new string(@"..\..\..\..\Res\Task21.dat")},
        };

        /// <summary>
        /// Json serialization and deserialization test for a one instanse of class
        /// </summary>
        /// <param name="cat">Cat object to be serialized</param>
        /// <param name="filepath">path to the file</param>
        [Theory]
        [MemberData(nameof(Data3))]
        public void JSON_SerializationAndDeserialization_ForAClassObject_Test(Cat cat, string filepath)
        {
            CustomSerializer<Cat> serializer = new CustomSerializer<Cat>();

            serializer.SerializeToJson(cat, filepath);

            Cat t_cat = serializer.DeserializeFromJson(filepath);

            Assert.Equal(cat, t_cat);
        }

        /// <summary>
        /// Data for a  Json_SerializationAndDeserialization_ForAClassObject test
        /// </summary>
        public static IEnumerable<object[]> Data3 =>
        new List<object[]>
        {
            new object[] { new Cat("Barsik", 5, Color.red),
            new string(@"..\..\..\..\Res\Task21.json")},
            new object[] { new Cat("Kesha", 15, Color.white),
            new string(@"..\..\..\..\Res\Task21.json")},
            new object[] { new Cat("Murka", 6, Color.black),
            new string(@"..\..\..\..\Res\Task21.json")},
        };

        /// <summary>
        /// XML serialization and deserialization test for a one instanse of class
        /// </summary>
        /// <param name="cats">Cat object to be serialized</param>
        /// <param name="filepath">path to the file</param>
        [Theory]
        [MemberData(nameof(Data4))]
        public void XML_SerializationAndDeserialization_ForACollection_Test(CatsCollection<Cat> cats, string filepath)
        {
            CustomSerializer<CatsCollection<Cat>> serializer = new CustomSerializer<CatsCollection<Cat>>();

            serializer.SerializeToXml(cats, filepath);

            CatsCollection<Cat>  t_cats = serializer.DeserializeFromXml(filepath);

            Assert.Equal(cats, t_cats);
        }

        /// <summary>
        /// Data for a  XML_SerializationAndDeserialization_ForACollection_Test test
        /// </summary>
        public static IEnumerable<object[]> Data4 =>
        new List<object[]>
        {
            new object[] { new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black),}),
            new string(@"..\..\..\..\Res\Task22.xml")},
            new object[] { new CatsCollection<Cat>(new List<Cat>{
                new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red),}),
            new string(@"..\..\..\..\Res\Task22.xml")}
        };

        /// <summary>
        /// Binary serialization and deserialization test for a one instanse of class
        /// </summary>
        /// <param name="cats">Cat object to be serialized</param>
        /// <param name="filepath">path to the file</param>
        [Theory]
        [MemberData(nameof(Data5))]
        public void Binary_SerializationAndDeserialization_ForACollection_Test(CatsCollection<Cat> cats, string filepath)
        {
            CustomSerializer<CatsCollection<Cat>> serializer = new CustomSerializer<CatsCollection<Cat>>();

            serializer.SerializeToBinary(cats, filepath);

            CatsCollection<Cat> t_cats = serializer.DeserializeFromBinary(filepath);

            Assert.Equal(cats, t_cats);
        }

        /// <summary>
        /// Data for a  Binary _SerializationAndDeserialization_ForACollection_Test test
        /// </summary>
        public static IEnumerable<object[]> Data5 =>
        new List<object[]>
        {
            new object[] { new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black),}),
            new string(@"..\..\..\..\Res\Task22.dat")},
             new object[] { new CatsCollection<Cat>(new List<Cat>{
                new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red),}),
            new string(@"..\..\..\..\Res\Task22.xml")}
        };

        /// <summary>
        /// JSON serialization and deserialization test for a one instanse of class
        /// </summary>
        /// <param name="cats">Cat object to be serialized</param>
        /// <param name="filepath">path to the file</param>
        [Theory]
        [MemberData(nameof(Data5))]
        public void JSON_SerializationAndDeserialization_ForACollection_Test(CatsCollection<Cat> cats, string filepath)
        {
            CustomSerializer<CatsCollection<Cat>> serializer = new CustomSerializer<CatsCollection<Cat>>();

            serializer.SerializeToJson(cats, filepath);

            CatsCollection<Cat> t_cats = serializer.DeserializeFromJson(filepath);

            Assert.Equal(cats, t_cats);
        }

        /// <summary>
        /// Data for a  JSON_SerializationAndDeserialization_ForACollection_Test test
        /// </summary>
        public static IEnumerable<object[]> Data6 =>
        new List<object[]>
        {
            new object[] { new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black),}),
            new string(@"..\..\..\..\Res\Task22.json")},
             new object[] { new CatsCollection<Cat>(new List<Cat>{
                new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red),}),
            new string(@"..\..\..\..\Res\Task22.xml")}
        };
    }
}
