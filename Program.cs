using System;
using Library.Danvas3.models;

namespace Danvas3 // Note: actual namespace depends on the project name.
{
    class Program
    {
        static List<Course> courses = new List<Course>();
        static List<Person> students = new List<Person>();
        /*
        static Assignment testAssignment = new Assignment
        {
            Name = "Test Assignment",
            Description = "This is a test assignment",
            TotalAvailablePoints = 100,
            DueDate = DateTime.Now.AddDays(7)
        };
        */

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Danvas 3 - Learning Management System");
                Console.WriteLine("1. Create a course");
                Console.WriteLine("2. Create a student");
                Console.WriteLine("3. Add a student to a course");
                Console.WriteLine("4. Remove a student from a course");
                Console.WriteLine("5. List all courses");
                Console.WriteLine("6. Search for courses");
                Console.WriteLine("7. List all students");
                Console.WriteLine("8. Search for a student");
                Console.WriteLine("9. List all courses for a student");
                Console.WriteLine("10. Update a course's information");
                Console.WriteLine("11. Update a student's information");
                Console.WriteLine("12. Create an assignment");
                Console.WriteLine("13. View course information");
                Console.WriteLine("0. Exit");

                int choice = GetChoice(13);

                switch (choice)
                {
                    case 1:
                        CreateCourse();
                        break;
                    case 2:
                        CreateStudent();
                        break;
                    case 3:
                        AddStudentToCourse();
                        break;
                    case 4:
                        RemoveStudentFromCourse();
                        break;
                    case 5:
                        ListAllCourses();
                        break;
                    case 6:
                        SearchCourses();
                        break;
                    case 7:
                        ListAllStudents();
                        break;
                    case 8:
                        SearchStudents();
                        break;
                    case 9:
                        ListCoursesForStudent();
                        break;
                    case 10:
                        UpdateCourse();
                        break;
                    case 11:
                        UpdateStudent();
                        break;
                    case 12:
                        CreateAssignment();
                        break;
                    case 13:
                        ShowCourseInfo();
                        break;
                    case 0:
                        choice = 0;
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }                      
            }
        }

        static int GetChoice(int maxChoice)
        {
            Console.Write("Enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > maxChoice)
            {
                Console.Write("Invalid choice. Enter a number from 0 to {0}: ", maxChoice);
            }
            return choice;
        }

        static void CreateCourse()
        {
            Console.Write("Enter the course code: ");
            string code = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter the course name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter the course description: ");
            string description = Console.ReadLine() ?? string.Empty;
            Course course = new Course
            {
                Code = code,
                Name = name,
                Description = description
            };
            courses.Add(course);
            course.Roster = new List<Person>(); // initialize roster 
            course.Assignments = new List<Assignment>(); // initialize assignment list 
            Console.WriteLine("Course created successfully!");
            Console.ReadKey();
        }

        static void CreateStudent()
        {
            Console.Write("Enter the student's name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Student Classification: (F)reshman, S(O)phomore, (J)unior, (S)enior");
            string classificationString = Console.ReadLine() ?? string.Empty;
            Person.ConvertStringToClassification(classificationString);

            try
            {
                Classification classification = Person.ConvertStringToClassification(classificationString);
                Person student = new Person(name, classification);
                students.Add(student);
                Console.WriteLine("Student created successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid classification string: " + ex.Message);
            }

            Console.ReadKey();
        }

        static void AddStudentToCourse()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no courses to add a student to.");
                Console.ReadKey();
                return;
            }
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students to add to a course.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter the course code:");
            string code = Console.ReadLine() ?? string.Empty;

            Course course = courses.FirstOrDefault(c => c?.Code == code);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            if (course.Roster == null)
            {
                course.Roster = new List<Person>(); // create the roster list if it doesn't exist
            }

            Console.WriteLine("Enter ID of student to be added to course:");
            int id = int.Parse(Console.ReadLine());
            Person student = students.FirstOrDefault(s => s?.ID == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }
            if (course.Roster.Contains(student))
            {
                Console.WriteLine("Student is already enrolled in the course.");
                return;
            }

            course.Roster.Add(student);
            Console.WriteLine($"{student.Name} added to {course.Name} roster.");


            Console.ReadKey();
        }

        static void RemoveStudentFromCourse()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no courses to remove a student from.");
                Console.ReadKey();
                return;
            }
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students to remove from a course.");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter the course code: ");
            string code = Console.ReadLine() ?? string.Empty;
            Course course = courses.Find(c => c?.Code == code);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Enter ID of student to be added to course:");
            int id = int.Parse(Console.ReadLine());
            Person student = students.FirstOrDefault(s => s?.ID == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }
            if (!course.Roster.Contains(student))
            {
                Console.WriteLine("Student is not enrolled in this course.");
                return;
            }
            course.Roster.Remove(student);
            Console.WriteLine("{0} has been removed from {1}.", student.Name, course.Name);
            Console.ReadKey();
        }

        static void ListAllCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no courses to list.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Courses:");
            foreach (Course course in courses)
            {
                Console.WriteLine("{0} - {1}", course.Code, course.Name);
            }
            Console.ReadKey();
        }

        static void SearchCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no courses to search.");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter the search query: ");
            string query = Console.ReadLine().ToLower() ?? string.Empty;
            List<Course> results = courses.FindAll(c => c.Name.ToLower().Contains(query) || c.Description.ToLower().Contains(query));
            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Search results:");
            foreach (Course course in results)
            {
                Console.WriteLine("{0} - {1}", course.Code, course.Name);
            }
            Console.ReadKey();
        }

        static void ListAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students to list.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Students:");
            foreach (Person student in students)
            {
                Console.WriteLine($"[{student.ID}] - {student.Name}");
            }
            Console.ReadKey();
        }

        static void SearchStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students to search.");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter the search query: ");
            string query = Console.ReadLine().ToLower() ?? string.Empty;
            List<Person> results = students.FindAll(s => s.Name.ToLower().Contains(query));
            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Search results:");
            foreach (Person student in results)
            {
                Console.WriteLine($"[{student.ID}] - {student.Name}");
            }
            Console.ReadKey();
        }

        static void ListCoursesForStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students to list courses for.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Enter a student ID to list courses for:");
            int id = int.Parse(Console.ReadLine());
            Person student = students.FirstOrDefault(s => s?.ID == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"Courses for student {student.ID} ({student.Name}):");

            foreach (Course course in courses)
            {
                if (course.Roster.Contains(student))
                {
                    Console.WriteLine($"{course.Code} - {course.Name}");
                }
            }

                Console.ReadKey();
        }

        static void UpdateCourse()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no courses to update.");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter the course code: ");
            string code = Console.ReadLine() ?? string.Empty;
            Course course = courses.Find(c => c?.Code == code);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Enter the new information for the course:");
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;
            course.Name = name;
            course.Description = description;
            Console.WriteLine("{0} has been updated.", course.Name);
            Console.ReadKey();
        }

        static void UpdateStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students to update.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter ID for student to be updated:");
            int id = int.Parse(Console.ReadLine());

            Person student = students?.FirstOrDefault(s => s?.ID == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"Enter new name for {student.Name} (leave blank to keep current name):");
            string nameInput = Console.ReadLine() ?? string.Empty;
            string name = string.IsNullOrEmpty(nameInput) ? student.Name : nameInput;

            Console.WriteLine($"Enter new classification for {student.Name} (F)reshman, S(O)phomore, (J)unior, (S)enior (leave blank to keep current classification):");
            string classificationStringInput = Console.ReadLine() ?? string.Empty;
            Classification classification = string.IsNullOrEmpty(classificationStringInput) ? student.Classification : Person.ConvertStringToClassification(classificationStringInput);

            student.Name = name;
            student.Classification = classification;
            Console.WriteLine("{0} has been updated.", student.Name);
            Console.ReadKey();
        }

        static void CreateAssignment()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no courses to create an assignment for.");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter the course code: ");
            string code = Console.ReadLine() ?? string.Empty;
            Course course = courses.Find(c => c?.Code == code);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Enter the new assignment's information:");
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;
            Console.Write("Total available points: ");
            int totalPoints = int.Parse(Console.ReadLine());
            Console.Write("Due date (mm/dd/yyyy): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Assignment assignment = new Assignment(name, description, totalPoints, dueDate);
            course.Assignments.Add(assignment);
            Console.WriteLine("{0} has been added to {1}.", assignment.Name, course.Name);
            Console.ReadKey();
        }

        static void ShowCourseInfo()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no courses to display.");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter the course code: ");
            string code = Console.ReadLine() ?? string.Empty;
            Course course = courses.Find(c => c?.Code == code);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("{0} ({1})", course.Name, course.Code);
            Console.WriteLine("Description: {0}", course.Description);
            Console.WriteLine("Students:");

            bool emptyroster = !course.Roster.Any();
            if (emptyroster)
            {
                Console.WriteLine("There are no students assigned to this course.");
            }

            foreach (Person student in course.Roster)
            {
                Console.WriteLine("- {0}", student.Name);
            }
            Console.WriteLine("Assignments:");
            foreach (Assignment assignment in course.Assignments)
            {
                Console.WriteLine("- {0} ({1} points, due {2})", assignment.Name, assignment.TotalAvailablePoints, assignment.DueDate);
            }
            Console.ReadKey();
        }




    }
}