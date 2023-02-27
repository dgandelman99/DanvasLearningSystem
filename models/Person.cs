using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Danvas.models
{
    public class Person : Item
    {
        //        public string Name { get; set; }
        public int studentID { get; set; }
        public PersonClass Classification { get; set; }
        //        public string Grades { get; set; }
        public Dictionary<int, double> Grades { get; set; }

        public Person()
        {
            Name = string.Empty;
            Grades = new Dictionary<int, double>();
        }

        public override string ToString()
        {
            return $"[{studentID}] {Name} - {Classification}";
        }

        public enum PersonClass
        {
            Freshman, Sophomore, Junior, Senior
        }
    }
}
