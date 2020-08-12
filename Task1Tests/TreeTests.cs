using StudentLibrary;
using System;
using System.Collections.Generic;
using Xunit;
using TreeClass;

namespace Task1Tests
{
    public class TreeTests
    {
        /// <summary>
        /// Tree population test. Creates Tree and adds new element
        /// </summary>
        /// <param name="studentsToAdd">List of students to add</param>
        /// <param name="newStudent">New student to add</param>
        /// <param name="expectedStudents">Epxected List of students</param>
        [Theory]
        [MemberData(nameof(Data1))]
        public void Tree_Population(List<Student> studentsToAdd, Student newStudent, List<Student> expectedStudents)
        {
            Tree<Student> t_tree = new Tree<Student>();

            foreach(var item in studentsToAdd)
            {
                t_tree.Add(item);
            }

            t_tree.Add(newStudent);

            Tree<Student> ex_tree = new Tree<Student>();

            foreach (var item in expectedStudents)
            {
               ex_tree.Add(item);
            }

            Assert.Equal(ex_tree.ToList(), t_tree.ToList());
        }

        /// <summary>
        /// Data for a Tree_Population test
        /// </summary>
        public static IEnumerable<object[]> Data1 =>
       new List<object[]>
       {
            new object[] { new List<Student> { new Student("Vanya", "Math", 40, new DateTime(2020, 01, 01)),
                new Student("Dime", "Math", 65, new DateTime(2020, 01, 01)),
                new Student("Kirill", "Math", 20, new DateTime(2020, 01, 01)),
                new Student("Methodiy", "Math", 99, new DateTime(2020, 01, 01))
            },                new Student("Vitaliy", "Math", 76, new DateTime(2020, 01, 01)),
            new List<Student> { new Student("Vanya", "Math", 40, new DateTime(2020, 01, 01)),
                new Student("Dime", "Math", 65, new DateTime(2020, 01, 01)),
                new Student("Kirill", "Math", 20, new DateTime(2020, 01, 01)),
                new Student("Methodiy", "Math", 99, new DateTime(2020, 01, 01)),
                new Student("Vitaliy", "Math", 76, new DateTime(2020, 01, 01))
            }},

           
       };

        /// <summary>
        /// Argument exeption case of an additon to the tree
        /// </summary>
        /// <param name="studentsToAdd">List of students to add</param>
        /// <param name="newStudent">New student to add</param>
        /// <param name="expectedStudents">Epxected List of students</param>
        [Theory]
        [MemberData(nameof(Data1))]
        public void Tree_ArgumentExetion_Add(List<Student> studentsToAdd, Student newStudent, List<Student> expectedStudents)
        {
            Tree<Student> t_tree = new Tree<Student>();

            foreach (var item in studentsToAdd)
            {
                t_tree.Add(item);
            }
            List<Student> sameStudents = t_tree.ToList();

            Assert.Throws<ArgumentException>(() => t_tree.Add(sameStudents[0]));

        }

        /// <summary>
        /// Finding a wanted elemnt by value
        /// </summary>
        /// <param name="students">List of students to be added to the tree</param>
        /// <param name="expectedStudent">Expected strudent to be found </param>
        [Theory]
        [MemberData(nameof(Data2))]
        public void Tree_FindDataMethod_Test(List<Student> students, Student expectedStudent)
        {
            Tree<Student> t_tree = new Tree<Student>();

            foreach (var item in students)
            {
                t_tree.Add(item);
            }

            Student testStudent = t_tree.FindData(expectedStudent);

            Assert.Equal(expectedStudent, testStudent);
        }

        /// <summary>
        /// Data for a Tree_FindDataMethod test
        /// </summary>
        public static IEnumerable<object[]> Data2 =>
        new List<object[]>
      {
            new object[] { new List<Student> { new Student("Vanya", "Math", 40, new DateTime(2020, 01, 01)),
                new Student("Dime", "Math", 65, new DateTime(2020, 01, 01)),
                new Student("Kirill", "Math", 20, new DateTime(2020, 01, 01)),
                new Student("Methodiy", "Math", 99, new DateTime(2020, 01, 01))
            },                new Student("Methodiy", "Math", 99, new DateTime(2020, 01, 01)),},
      };

        /// <summary>
        /// Replacment data test. Replaces an old data with a new one.
        /// </summary>
        /// <param name="students">List of students to be added to the tree</param>
        /// <param name="newStudent">new student to be inserted</param>
        /// <param name="expectedstudents">List of students with replaced student</param>
        [Theory]
        [MemberData(nameof(Data3))]
        public void Tree_ReplaceMethod_Test(List<Student> students, Student newStudent, List<Student> expectedstudents)
        {
            Tree<Student> t_tree = new Tree<Student>();

            foreach (var item in students)
            {
                t_tree.Add(item);
            }

            t_tree.Replace(new Student("Methodiy", "Math", 99, new DateTime(2020, 01, 01)), newStudent);

            Tree<Student> ex_tree = new Tree<Student>();

            foreach (var item in expectedstudents)
            {
                ex_tree.Add(item);
            }

            Assert.Equal(ex_tree.ToList(), t_tree.ToList());
        }

        /// <summary>
        /// Data for a Tree_ReplaceMethod test
        /// </summary>
        public static IEnumerable<object[]> Data3 =>
       new List<object[]>
       {
            new object[] { new List<Student> { new Student("Vanya", "Math", 40, new DateTime(2020, 01, 01)),
                new Student("Dime", "Math", 65, new DateTime(2020, 01, 01)),
                new Student("Kirill", "Math", 20, new DateTime(2020, 01, 01)),
                new Student("Methodiy", "Math", 99, new DateTime(2020, 01, 01))
            },                new Student("Vitaliy", "Math", 76, new DateTime(2020, 01, 01)),
            new List<Student> { new Student("Vanya", "Math", 40, new DateTime(2020, 01, 01)),
                new Student("Dime", "Math", 65, new DateTime(2020, 01, 01)),
                new Student("Kirill", "Math", 20, new DateTime(2020, 01, 01)),
                new Student("Vitaliy", "Math", 76, new DateTime(2020, 01, 01))
            }},


       };


        /// <summary>
        /// Tree balance test. Balances tree by rearranging nodes by given cretaria.
        /// </summary>
        /// <param name="students">List of students to be added to the tree</param>
        /// <param name="students">List of expeted balanced students to be added to the tree</param>
        [Theory]
        [MemberData(nameof(Data4))]
        public void Tree_Balance_Test(List<Student> students, List<Student> expectedstudents)
        {
            Tree<Student> t_tree = new Tree<Student>();

            foreach (var item in students)
            {
                t_tree.Add(item);
            }

            t_tree.Balance();

            Tree<Student> ex_tree = new Tree<Student>();

            foreach (var item in expectedstudents)
            {
                ex_tree.Add(item);
            }

            Assert.Equal(ex_tree.ToList(), t_tree.ToList());
        }

        /// <summary>
        /// Data for a Tree_Balance test
        /// </summary>
        public static IEnumerable<object[]> Data4 =>
       new List<object[]>
       {
            new object[] { new List<Student> {
                new Student("Test", "Math", 35, new DateTime(2020, 01, 01)),
                new Student("Test", "Math", 87, new DateTime(2020, 01, 01)),
                new Student("Test", "Math", 3, new DateTime(2020, 01, 01)),
                new Student("Test", "Math", 82, new DateTime(2020, 01, 01)),
                new Student("Test", "Math", 23, new DateTime(2020, 01, 01))
            },
            new List<Student> {
             new Student("Test", "Math", 87, new DateTime(2020, 01, 01)),
             new Student("Test", "Math", 35, new DateTime(2020, 01, 01)),
             new Student("Test", "Math", 3, new DateTime(2020, 01, 01)),
             new Student("Test", "Math", 82, new DateTime(2020, 01, 01)),
             new Student("Test", "Math", 23, new DateTime(2020, 01, 01)),
            }},
       };

        /// <summary>
        /// Tree serialization and deserialization tests.
        /// </summary>
        /// <param name="students">List of students to be added to the tree</param>
        /// <param name="filepath">path to the file</param>
        [Theory]
        [MemberData(nameof(Data5))]
        public void Tree_SerializationAndDeserialization_Test(List<Student> students, string filepath)
        {
            Tree<Student> t_tree = new Tree<Student>();

            foreach (var item in students)
            {
                t_tree.Add(item);
            }

            Tree<Student> ex_tree = new Tree<Student>();

            t_tree.Serialize(filepath);

            ex_tree.Deserialize(filepath);  
           

            Assert.Equal(ex_tree.ToList(), t_tree.ToList());
        }

        /// <summary>
        /// Data for a Tree_SerializationAndDeserialization test
        /// </summary>
        public static IEnumerable<object[]> Data5 =>
       new List<object[]>
       {
            new object[] { new List<Student> {
                new Student("Test", "Math", 35, new DateTime(2020, 01, 01)),
                new Student("Test", "Math", 87, new DateTime(2020, 01, 01)),
                new Student("Test", "Math", 54, new DateTime(2020, 01, 01)),

            },
            new string(@"..\..\..\..\Res\Task1.xml")},
       };
    }
}
