using ClassModels;
using SerializerClass;
using System;
using System.Collections.Generic;
using Xunit;

namespace Task2Tests
{
    public class CollectionTest
    {
        /// <summary>
        /// Collection creation tests
        /// </summary>
        /// <param name="cats">List of cats</param>
        /// <param name="ex_cats">Epected CatsCollection</param>
        [Theory]
        [MemberData(nameof(Data1))]
        public void Collection_Population_Test(List<Cat> cats, CatsCollection<Cat> ex_cats)
        {
            CatsCollection<Cat> t_cats = new CatsCollection<Cat>(cats);

            Assert.Equal(ex_cats, t_cats);
        }

        /// <summary>
        /// Data for a Collection_Population_Test
        /// </summary>
        public static IEnumerable<object[]> Data1 =>
        new List<object[]>
        {
            new object[] {new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black) },
                new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black),}),
            },
             new object[] {new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red)},
                new CatsCollection<Cat>(new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red)}),
            },
        };

        /// <summary>
        /// Collection addition test
        /// </summary>
        /// <param name="cats">List of cats</param>
        /// <param name="cat">cat to be added</param>
        /// <param name="ex_cats">Expected CatsCollection</param>
        [Theory]
        [MemberData(nameof(Data2))]
        public void Collection_Addition_Test(List<Cat> cats, Cat cat, CatsCollection<Cat> ex_cats)
        {
            CatsCollection<Cat> t_cats = new CatsCollection<Cat>(cats);

            t_cats.Add(cat);

            Assert.Equal(ex_cats, t_cats);
        }

        /// <summary>
        /// Data for a  Collection_Addition_Test
        /// </summary>
        public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {
            new object[] {new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black) },
                new Cat("Lola", 4, Color.black),
                new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black), new Cat("Lola", 4, Color.black)}),
            },
             new object[] {new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red)},
               new Cat("Mona", 1, Color.black),
               new CatsCollection<Cat>(new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red), new Cat("Mona", 1, Color.black)}),
            },
        };

        /// <summary>
        /// Collection addition exeption test
        /// </summary>
        /// <param name="cats">List of cats</param>
        /// <param name="cat">cat to be added</param>
        /// <param name="ex_cats">Expected CatsCollection</param>
        [Theory]
        [MemberData(nameof(Data3))]
        public void Collection_Addition_ArgumentExeption_Test(List<Cat> cats, Cat cat, CatsCollection<Cat> ex_cats)
        {
            CatsCollection<Cat> t_cats = new CatsCollection<Cat>(cats);

           
            Assert.Throws<ArgumentException>(() => t_cats.Add(cat));
        }

        /// <summary>
        /// Data for a  Collection_Addition_ArgumentExeption_Test
        /// </summary>
        public static IEnumerable<object[]> Data3 =>
        new List<object[]>
        {
            new object[] {new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black) },
                new Cat("Barsik", 5, Color.red),
                new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black), new Cat("Lola", 4, Color.black)}),
            },
             new object[] {new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red)},
               new Cat("Poof", 5, Color.yellow),
               new CatsCollection<Cat>(new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red), new Cat("Mona", 1, Color.black)}),
            },
        };

        /// <summary>
        /// Collection Contains test
        /// </summary>
        /// <param name="cats">List of cats</param>
        /// <param name="cat">cat to be checked</param>
        [Theory]
        [MemberData(nameof(Data4))]
        public void Collection_Contains_Test(List<Cat> cats, Cat cat)
        {
            CatsCollection<Cat> t_cats = new CatsCollection<Cat>(cats);


            Assert.Contains(cat, t_cats);
        }

        /// <summary>
        /// Data for a Collection_Contains_Test(
        /// </summary>
        public static IEnumerable<object[]> Data4 =>
        new List<object[]>
        {
            new object[] {new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black) },
                new Cat("Barsik", 5, Color.red),
               
            },
             new object[] {new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red)},
               new Cat("Poof", 5, Color.yellow),
             
            },
        };

        /// <summary>
        /// Collection Clear test
        /// </summary>
        /// <param name="cats">List of cats</param>
        [Theory]
        [MemberData(nameof(Data5))]
        public void Collection_Clear_Test(List<Cat> cats)
        {
            CatsCollection<Cat> t_cats = new CatsCollection<Cat>(cats);

            t_cats.Clear();

            Assert.Empty(t_cats);
        }

        /// <summary>
        /// Data for a Collection_Clear_Test
        /// </summary>
        public static IEnumerable<object[]> Data5 =>
        new List<object[]>
        {
            new object[] {new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black) },

            },
             new object[] {new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red)},

            },
        };

        /// <summary>
        /// Collection CopyTo test. Copies objects from the Colletion to the array.
        /// </summary>
        /// <param name="ex_cats">Array of Cats to be expected</param>
        /// <param name="t_cats">List of cats to be copied from</param>
        [Theory]
        [MemberData(nameof(Data6))]
        public void Collection_CopyTo_Test(Cat[] ex_cats, CatsCollection<Cat> t_cats)
        {
            Cat[] cats = new Cat[4];

            t_cats.CopyTo(cats, 0);

            Assert.Equal(ex_cats, cats);
        }

        /// <summary>
        /// Data for a Collection_CopyTo_Test and it's exeption tests
        /// </summary>
        public static IEnumerable<object[]> Data6 =>
        new List<object[]>
        {
            new object[] {new Cat[]{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black), new Cat("Lola", 4, Color.black) }
                  ,new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black), new Cat("Lola", 4, Color.black)}),
            },
             new object[] {new Cat[]{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red),new Cat("Murka", 6, Color.black)},
                 new CatsCollection<Cat>(new List<Cat>{
               new Cat("Poof", 5, Color.yellow),new Cat("Dym", 3, Color.black),new Cat("Riyzka", 2, Color.red), new Cat("Murka", 6, Color.black)})

            },
        };

        /// <summary>
        /// Argument Out of Range execption usage case of a CopyTO
        /// </summary>
        /// <param name="ex_cats">Array of Cats to be expected</param>
        /// <param name="t_cats">List of cats to be copied from</param>
        [Theory]
        [MemberData(nameof(Data6))]
        public void Collection_CopyTo_ArgumentOutOfRangeException_Test(Cat[] ex_cats, CatsCollection<Cat> t_cats)
        {
            Cat[] cats = new Cat[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => t_cats.CopyTo(cats, -5));  
        }

        /// <summary>
        /// Argument execption usage case of a CopyTO
        /// </summary>
        /// <param name="ex_cats">Array of Cats to be expected</param>
        /// <param name="t_cats">List of cats to be copied from</param>
        [Theory]
        [MemberData(nameof(Data6))]
        public void Collection_CopyTo_ArgumentException_Test(Cat[] ex_cats, CatsCollection<Cat> t_cats)
        {
            Cat[] cats = new Cat[4];

            Assert.Throws<ArgumentException>(() => t_cats.CopyTo(cats, 100000));

        }

        /// <summary>
        /// Collection item removal
        /// </summary>
        /// <param name="cats">List of original cats</param>
        /// <param name="cat">cat object to be removed</param>
        /// <param name="ex_cats">expected cats colletion</param>
        [Theory]
        [MemberData(nameof(Data7))]
        public void Collection_Remove_Test(CatsCollection<Cat> cats, Cat cat, CatsCollection<Cat> ex_cats)
        {
            cats.Remove(cat);

            Assert.Equal(ex_cats, cats);
        }

        /// <summary>
        /// Data for a Collection_CopyTo_Test and it's exeption tests
        /// </summary>
        public static IEnumerable<object[]> Data7 =>
        new List<object[]>
        {
               new object[]{ new CatsCollection<Cat>(new List<Cat>{
                new Cat("Barsik", 5, Color.red),new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black), new Cat("Lola", 4, Color.black)}),
                new Cat("Barsik", 5, Color.red),
                new CatsCollection<Cat>(new List<Cat>{
               new Cat("Kesha", 15, Color.white),new Cat("Murka", 6, Color.black), new Cat("Lola", 4, Color.black)}),}
        };
    }
}
