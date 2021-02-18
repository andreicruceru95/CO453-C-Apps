using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleAppProject.App03
{
    public class StudentMarks
    {
        private List<Student> Students = Streamer.ReadFile();
        private string[] Choices = new string[]
        {
            "Add new Student",
            "Award/Update Mark",
            "Display list of students",
            "See Statistics",
            "See Grade profile",
            "Exit App"
        };
        
        /// <summary>
        /// Run the application in steps.
        /// </summary>
        public void Run()
        {
            //Students = Streamer.ReadFile();

            var finished = false;
            while (!finished)
            {
                switch (ConsoleHelper.SelectChoice("Please select an action", Choices))
                {
                    case 1:
                        AddNew();
                        break;

                    case 2:
                        AwardMark();
                        break;

                    case 3:
                        DisplayStudents();
                        break;

                    case 4:
                        Student StudentMin = GetStatistics().Item1;
                        Student StudentMax = GetStatistics().Item2;
                        int MediumMark = GetStatistics().Item3;

                        Console.WriteLine($"\n\tThe lowest mark is {StudentMin.Mark} and it belongs to :\n\t{StudentMin.StudentID} {StudentMin.FullName()}");
                        Console.WriteLine($"\n\tThe highest mark is {StudentMax.Mark} and it belongs to :\n\t{StudentMax.StudentID} {StudentMax.FullName()}");
                        Console.WriteLine($"\n\tThe medium mark is {MediumMark}");

                        StudentMin.Mark = MediumMark;

                        Console.WriteLine($"\n\tThe medium grade is {StudentMin.CalculateGrade()}");
                        break;

                    case 5:
                        Console.WriteLine($"\n\t{GetProfile().Item1}% students have achieved a 1 class grade.");
                        Console.WriteLine($"\n\t{GetProfile().Item2}% students have achieved a 2,1 class grade.");
                        Console.WriteLine($"\n\t{GetProfile().Item3}% students have achieved a 2,2 class grade.");
                        Console.WriteLine($"\n\t{GetProfile().Item4}% students have achieved a 3 class grade.");
                        Console.WriteLine($"\n\t{GetProfile().Item5}% students have failled.");

                        break;

                    case 6:
                        Streamer.SaveFile(Students);
                        finished = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Add a new student to the db.
        /// </summary>
        /// <param name="ID">Student ID</param>
        /// <param name="FirstName">Student's first name</param>
        /// <param name="LastName">Student's last name</param>
        public void AddNew()
        {
            try
            {
                var ID = Convert.ToInt32(ConsoleHelper.InputString("Please enter a new Student ID >"));

                Student student = new Student();

                if (CheckID(ID) == null)
                {
                    student.StudentID = ID;
                    student.FirstName = ConsoleHelper.InputString("Please enter Student's First Name >");
                    student.LastName = ConsoleHelper.InputString("Please enter Student's Last Name >");

                    Students.Add(student);

                    Console.WriteLine($"\n\tStudent with Student ID {ID} Added!");
                }
                else
                    Console.WriteLine($"\n\tID {ID} already exists. Try again!");
            }
            catch(FormatException)
            {
                Console.WriteLine("\t\tPlease enter ID as whole numbers!");
            }
        }

        /// <summary>
        /// Check if the ID already exists.
        /// </summary>
        /// <param name="ID">ID to validate</param>
        /// <returns>student if the id is available, null otherwise</returns>
        public Student CheckID(int ID)
        {
            foreach (Student Student in Students)
            {
                if (Student.StudentID == ID)
                {
                    return Student;
                }                
            }
            return null;
        }

        /// <summary>
        /// Award mark to a student.
        /// </summary>
        public void AwardMark()
        {
            try
            {
                int ID = Convert.ToInt32(ConsoleHelper.InputString("Please enter the Student's ID of which you want to award >"));
                Student student = CheckID(ID);

                if (student != null)
                {
                    student.Mark = Convert.ToInt32(ConsoleHelper.InputNumber("Please enter the mark >", 1, 100));

                    Console.WriteLine($"\n\tAdded {student.Mark} Mark for {student.FirstName} {student.LastName}");
                }
                else
                {
                    Console.WriteLine($"\n\tStudent with ID {ID} is not recognised. Please try again!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\t\tPlease enter ID as whole numbers!");
            }
        }            
        

        /// <summary>
        /// Display a list of students.
        /// </summary>
        public void DisplayStudents()
        {
            var StudentsSorted = Students.OrderBy(S => S.StudentID).ToList();

            Console.WriteLine("\n\t\tID\tFirst Name\tLast Name\tMark\tGrade\n");

            foreach (Student student in StudentsSorted)
            {
                Console.WriteLine($"\t\t{student.StudentID}\t{student.FirstName}\t\t{student.LastName}\t\t{student.Mark}" +
                    $"\t{EnumHelper<Grades>.GetName(student.CalculateGrade())}");
            }
        }

        /// <summary>
        /// Find the students with the lowest and highest mark and calculate the mean.
        /// </summary>
        /// <returns>The students with the lowest and highest mark.</returns>
        public Tuple<Student,Student, int, Tuple<int, int, int, int, int>> GetStatistics()
        {
            var MediumMark = 0;            
            Student StudentMin = new Student();
            StudentMin.Mark = 100;
            Student StudentMax = new Student();
            int first = 0;
            int second = 0;
            int secondII = 0;
            int third = 0;
            int failled = 0;

            foreach (Student student in Students)
            {
                MediumMark += student.Mark;
                if (student.Mark > 70)
                    first++;
                else if (student.Mark > 60)
                    second++;
                else if (student.Mark > 50)
                    secondII++;
                else if (student.Mark > 40)
                    third++;
                else
                    failled++;

                if (student.Mark < StudentMin.Mark)
                    StudentMin = student;
                if(student.Mark > StudentMax.Mark)
                    StudentMax = student;
            }
            MediumMark = Convert.ToInt32(MediumMark / Students.Count());
            
            return Tuple.Create(StudentMin,StudentMax, MediumMark, Tuple.Create(first, second, secondII, third, failled));
        }
        /// <summary>
        /// return the percentage of students for each grade category.
        /// </summary>
        /// <returns>the percentages for each grade.</returns>
        public Tuple<double, double, double, double, double> GetProfile()
        {
            var totalStudents = Students.Count();
            var gradeCount = GetStatistics().Item4;
            double first = Math.Round(Convert.ToDouble(gradeCount.Item1  * 100 / totalStudents), 2);
            double second = Math.Round(Convert.ToDouble(gradeCount.Item2 * 100 / totalStudents), 2);
            double secondII = Math.Round(Convert.ToDouble(gradeCount.Item3 * 100 / totalStudents), 2);
            double third = Math.Round(Convert.ToDouble(gradeCount.Item4 * 100 / totalStudents), 2);
            double failled = Math.Round(Convert.ToDouble(gradeCount.Item5 * 100 / totalStudents), 2);

            return Tuple.Create(first, second, secondII, third, failled);
        }
    }
}
