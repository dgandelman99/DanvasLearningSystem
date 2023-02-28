using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Danvas3.models
{
    public class CourseManager
    {
        private static Course _course;
        public static void SetCourse(Course course)
        {
            _course = course;
        }
        public static void Start(Course course)
        {
            SetCourse(course);
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Danvas 3 - Learning Management System");
                Console.WriteLine("============COURSE CONTENT MANAGER============");
                Console.WriteLine("Selected Course [{0}]: {1}", course.Code, course.Name);
                Console.WriteLine("1. Display Course Information");
                Console.WriteLine("2. Manage Assignments");
                Console.WriteLine("3. Exit");

                int choice = GetChoice(3);

                switch (choice)
                {
                    case 1:
                        ShowCourseInfo();
                        break;
                    case 2:
                        ShowAssignmentMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting Course Manager...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        Console.ReadKey();
                        break;
                }
            }

            static int GetChoice(int maxChoice)
            {
                Console.Write("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > maxChoice)
                {
                    Console.Write("Invalid choice. Enter a number from 0 to {0}: ", maxChoice);
                    Console.ReadKey();
                }
                return choice;
            }

            static void ShowCourseInfo()
            {
                Console.WriteLine(_course);
                /*
                Console.WriteLine("===========================");
                Console.WriteLine("Modules:");
                foreach (var module in _course?.Modules)
                {
                    Console.WriteLine(module);
                }
   
                Console.ReadKey();
                */
                Console.WriteLine("===========================");
                Console.WriteLine("Assignments:");

                foreach (var group in _course.AssignmentGroups)
                {
                    if (group.Name != null)
                    {
                        Console.WriteLine($"---Group: {group.Name} (Weight: {group.Weight})----");
                    }

                    foreach (var assignment in group.Assignments)
                    {
                        Console.WriteLine($"[{assignment.AssignmentId}] {assignment.Name}: {assignment.Grades.Count} submissions");
                    }
                }

                Console.ReadKey();
                Console.WriteLine("===========================");
                Console.WriteLine("Roster:");

                foreach (var person in _course.Roster)
                {
                    Console.WriteLine(person);
                }
                Console.ReadKey();
                Console.WriteLine("===========================");

            }

            static void ShowAssignmentMenu()
            {
                                Console.Clear();
                Console.WriteLine("Danvas 3 - Learning Management System");
                Console.WriteLine("============COURSE ASSIGNMENT MANAGER============");
                Console.WriteLine("Selected Course [{0}]: {1}", _course.Code, _course.Name);
                Console.WriteLine("1. Display Course Information");
                Console.WriteLine("2. Add Assignment");
                Console.WriteLine("3. Remove Assignment");
                Console.WriteLine("4. Update Assignment");
                Console.WriteLine("5. Modify Grades");
                Console.WriteLine("6. Show Student Grades");
                Console.WriteLine("7. Create Group");
                Console.WriteLine("8. Update Group");
                Console.WriteLine("9. Delete Group");
                Console.WriteLine("10. Add Assignment to Group");
                Console.WriteLine("11. Remove Assignment from Group");
                Console.WriteLine("0. Exit");

                int choice2 = GetChoice(3);
                switch (choice2)
                {
                    case 1:
                        ShowCourseInfo();
                        break;
                    case 2:
                        ShowAssignmentMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting Course Manager...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        Console.ReadKey();
                        break;
                }

            }


        }


    }
}

