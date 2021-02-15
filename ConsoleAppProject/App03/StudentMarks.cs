using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleAppProject.App03
{
    public class StudentMarks
    {
        //string dir = @"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App03";
        string SerializationFile = Path.Combine(@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App03", "Student.bin");

        //private int MediumMark = 0;
        private List<Student> Students = new List<Student>();
        private string[] Choices = new string[]
        {
            "Add new Student",
            "Award/Update Mark",
            "Display list of students",
            "See Statistics",
            "Exit App"
        };

        public void Run()
        {
            var finished = false;
            while (!finished)
            {
                switch (ConsoleHelper.SelectChoice("Please select an action", Choices))
                {
                    case 1:
                        var ID = Convert.ToInt32(ConsoleHelper.InputString("Please enter a new Student ID >"));
                        Student student = CheckID(ID);

                        if (student is null)
                        {
                            AddNew(ID,
                                   ConsoleHelper.InputString("Please enter Student's First Name >"),
                                   ConsoleHelper.InputString("Please enter Student's Last Name >"));
                            Console.WriteLine($"\n\tStudent with Student ID {ID} Added!");
                            SaveFile();
                        }
                        else
                            Console.WriteLine($"\n\tID {ID} already exists. Try again!");
                        break;
                    case 2:
                        ID = Convert.ToInt32(ConsoleHelper.InputString("Please enter the Student's ID of which you want to award >"));
                        student = CheckID(ID);

                        if (student != null)
                        {
                            AwardMark(ID,
                                      Convert.ToInt32(ConsoleHelper.InputNumber("Please enter the mark >", 1, 100)));
                            SaveFile();
                        }
                        else
                        {
                            Console.WriteLine($"\n\tStudent with ID {ID} is not recognised. Please try again!");
                        }

                        break;

                    case 3:
                        DisplayStudents();
                        break;

                    case 4:
                        Student StudentMin = GetStatistics().Item1;
                        Student StudentMax = GetStatistics().Item2;
                        int MediumMark = GetStatistics().Item3;

                        Console.WriteLine($"\tThe lowest mark is {StudentMin.Mark} and it belongs to :\n\t{StudentMin.StudentID} {StudentMin.FullName()}");
                        Console.WriteLine($"\tThe highest mark is {StudentMax.Mark} and it belongs to :\n\t{StudentMax.StudentID} {StudentMax.FullName()}");
                        Console.WriteLine($"\tThe medium mark is {MediumMark}");

                        StudentMin.Mark = MediumMark;

                        Console.WriteLine($"\tThe medium grade is {StudentMin.CalculateGrade()}");
                        break;
                    case 5:
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
        public void AddNew(int ID,string FirstName, string LastName)
        {
            if(CheckID(ID) == null)
            {
                Student student = new Student();

                student.StudentID = ID;
                student.FirstName = FirstName;
                student.LastName = LastName;

                Students.Add(student);            
            }
        }

        /// <summary>
        /// Check if the ID already exists.
        /// </summary>
        /// <param name="ID">ID to validate</param>
        /// <returns>true if the id is available, false otherwise</returns>
        public Student CheckID(int ID)
        {
            foreach (Student Student in Students)
            {
                if (Student.StudentID == ID)
                {
                    //Console.WriteLine("\n\tID already exists. Try another ID.");

                    return Student;
                }                
            }

            return null;
        }

        /// <summary>
        /// Award mark to a student.
        /// </summary>
        /// <param name="ID">Student's ID</param>
        /// <param name="Mark">The Mark to add</param>
        /// <returns></returns>
        public string AwardMark(int ID, int Mark)
        {
            Student student = CheckID(ID);
            if (student != null)
            {
                student.Mark = Mark; 
                SaveFile();

                return $"\n\tAdded {Mark} Mark for {student.FirstName} {student.LastName}";               
            }
            else
            {
                return $"\n\tID {ID} could not be found! Check that you entered the right details.";
            }            
        }

        /// <summary>
        /// Display a list of students.
        /// </summary>
        public void DisplayStudents()
        {
            ReadFile();
            var StudentsSorted = Students.OrderBy(S => S.StudentID).ToList();

            Console.WriteLine("\n\t\tID\tFirst Name\tLast Name\tMark\tGrade\n");

            foreach (Student student in StudentsSorted)
            {
                Console.WriteLine($"\t\t{student.StudentID}\t{student.FirstName}\t\t{student.LastName}\t\t{student.Mark}\t{student.CalculateGrade()}");
            }
        }

        /// <summary>
        /// Find the students with the lowest and highest mark and calculate the mean.
        /// </summary>
        /// <returns>The students with the lowest and highest mark.</returns>
        public Tuple<Student,Student, int> GetStatistics()
        {
            var MediumMark = 0;            
            Student StudentMin = new Student();
            StudentMin.Mark = 100;
            Student StudentMax = new Student();

            ReadFile();

            foreach(Student student in Students)
            {
                MediumMark += student.Mark;

                if(student.Mark < StudentMin.Mark)
                {
                    StudentMin = student;
                }

                if(student.Mark > StudentMax.Mark)
                {
                    StudentMax = student;
                }
            }
            MediumMark = Convert.ToInt32(MediumMark / Students.Count());
            
            return Tuple.Create(StudentMin,StudentMax, MediumMark);
        }

        public void SaveFile()
        {
            using (Stream stream = File.Open(SerializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, Students);
            }
        }

        public void ReadFile()
        {
            using (Stream stream = File.Open(SerializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                Students = (List<Student>)bformatter.Deserialize(stream);
            }
        }
    }
}
