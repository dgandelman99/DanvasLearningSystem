using System.Reflection;
using System.Collections.Generic;
using System;

namespace Library.Danvas3.models
{
    public class Course
    {

        private string code;
        public string Code
        {
            get { code = code.ToUpper().Replace(" ", ""); return code; }
            set { code = value.ToUpper().Replace(" ", ""); } // convert to uppercase and remove spaces
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public int CreditHours { get; set; }
        public List<Person> Roster { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Module> Modules { get; set; }

        public List<AssignmentGroup> AssignmentGroups { get; set; }

        public Course()
        {
            Roster = new List<Person>(); // initialize roster 
            Assignments = new List<Assignment>(); // initialize assignment list
            Modules = new List<Module>(); // initialize module list
            AssignmentGroups = new List<AssignmentGroup>(); // initialize assignment group list
        }

        public void AddModule(Module module)
        {
            Modules.Add(module);
        }

        public void RemoveModule(Module module)
        {
            Modules.Remove(module);
        }

        public void UpdateModule(Module moduleToUpdate, Module newModule)
        {
            var index = Modules.IndexOf(moduleToUpdate);

            if (index != -1)
            {
                Modules[index] = newModule;
            }
        }

        private static int nextID = 1; // static variable to keep track of the last assignment id used

        public static int GetNextAssignmentId()
        {
            int ID = nextID;
            nextID++;
            return ID;
        }

        public override string ToString()
        {
            return $"[{Code}] - {Name}";
        }


        public void AddAssignmentGroup(AssignmentGroup group)
        {
            AssignmentGroups.Add(group);
        }

        public void RemoveAssignmentGroup(AssignmentGroup group)
        {
            AssignmentGroups.Remove(group);
        }

        public void UpdateAssignmentGroup(AssignmentGroup groupToUpdate, AssignmentGroup newGroup)
        {
            var index = AssignmentGroups.IndexOf(groupToUpdate);

            if (index != -1)
            {
                AssignmentGroups[index] = newGroup;
            }
        }

        public double GetWeightedAverage(Person student)
        {
            double average = 0;

            foreach (var assignmentGroup in AssignmentGroups)
            {
                int totalPoints = 0;
                double totalWeighted = 0;

                foreach (var assignment in assignmentGroup.Assignments)
                {
                    totalPoints += assignment.Grades[student];
                }
                totalWeighted = totalPoints / assignmentGroup.Weight ;
                average += totalWeighted;
            }

            if (average == 0)
            {
                return 0;
            }

            return (double) average;
        }

    }
}