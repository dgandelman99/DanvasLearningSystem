using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Danvas3.models
{
    public class Assignment
    {
        public Assignment(string? name, string? description, int totalPoints, DateTime dueDate)
        {
            Name = name;
            Description = description;
            TotalAvailablePoints = totalPoints;
            DueDate = dueDate;
            AssignmentId = Course.GetNextAssignmentId(); // assign the next available id for particular course
            Grades = new Dictionary<Person, int>(); // initialize grade list
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }

        public int AssignmentId { get; set; }

        public Dictionary<Person, int> Grades { get; set; }

    }
}
