using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Danvas.models
{
    public class Course : Item
    {
        /*
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Roster { get; set; }
        public List<int> Assignments { get; set; }
        public List<int> Modules { get; set; }
        */

        public int Code { get; set; }
        //       public string Name { get; set; }
        //       public string Description { get; set; }


        public List<Person> Roster = new List<Person>();
        public List<Item> Assignments = new List<Item>();
        public List<Item> Modules = new List<Item>();

        public Course() { }
        public override string ToString()
        {
            return $"[{Code}] - {Name}";
        }

    }
}