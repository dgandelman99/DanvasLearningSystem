using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Library.Danvas3.models
{
    public class Person
    {
        public string Name { get; set; }
        public Classification Classification { get; set; }

        public Dictionary<Assignment, int> Grades { get; set; }

        public int ID { get; private set; } // ID is now read-only
        private static int nextID = 1; // static field to keep track of the next ID to assign
        public Person(string name, Classification classification)
        {
            Name = name;
            Classification = classification;
            ID = nextID;
            nextID++;
        }


        public static Classification ConvertStringToClassification(string s)
        {
            switch (s.ToUpper())
            {
                case "F":
                    return Classification.Freshman;
                case "O":
                    return Classification.Sophomore;
                case "J":
                    return Classification.Junior;
                case "S":
                    return Classification.Senior;
                default:
                    return Classification.Freshman;
            }

        }
    }
    public enum Classification
    {
        Freshman, Sophomore, Junior, Senior, TA, Instructor
    }
    public class Student : Person
    {
        public Student(string name, Classification classification) : base(name, classification)
        {
        }

    }

    public class TA : Person
    {
        public int EmployeeID { get; set; }
        public TA(string name, int id) : base(name, Classification.TA)
        {
        }
    }

    public class Instructor : Person
    {
        public int EmployeeID { get; set; }
        public Instructor(string name, int id) : base(name, Classification.Instructor)
        {
        }
    }

}
