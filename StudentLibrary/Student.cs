using System;

namespace StudentLibrary
{
    /// <summary>
    /// Class for Student representation
    /// </summary>
    public class Student: IComparable
    {
        /// <summary>
        /// Student name
        /// </summary>
       public string Name { get; set; }

        /// <summary>
        /// Test name
        /// </summary>
       public string Test { get; set; }

        /// <summary>
        /// Result
        /// </summary>
       public UInt16 Result { get; set; }

        /// <summary>
        /// Test Date
        /// </summary>
       DateTime Date { get; set; }

        /// <summary>
        /// Method for Student objects class comparasion
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>true if equal, false is not</returns>
        public override bool Equals(object obj)
        {
           if(obj is Student)
            {
                Student student = obj as Student;

                if(this.Name == student.Name && this.Result == student.Result && this.Test == student.Test && this.Date == Date)
                {
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
        /// Method for hashcode calculation
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Test.GetHashCode() ^ Result.GetHashCode() ^ Date.GetHashCode();
        }

        /// <summary>
        /// Method for IComparable implimetation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 - if bigger, 0 - if equal, -1 - if not</returns>
        public int CompareTo(object obj)
        {
            return Result.CompareTo(((Student)obj).Result);
        }

        /// <summary>
        /// Returns Student data in a text format
        /// </summary>
        /// <returns>text</returns>
        public override string ToString()
        {
            return string.Format($"{Name} - {Test} - {Result} - {Date}");
        }
    }
}
