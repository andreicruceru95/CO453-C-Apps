using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleAppProject.App03
{
    public class Student
    {
        public const int A_MIN = 70;
        public const int B_MIN = 60;
        public const int C_MIN = 50;
        public const int D_MIN = 40;

        public int StudentID { get; set; }
        [Required, StringLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, StringLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Range(0, 100)]
        public int Mark { get; set; }
        public Grades Grade { get; set; }


        //public Student(int StudentID, string FirstName, string LastName)
        //{
        //    this.StudentID = StudentID;
        //    this.FirstName = FirstName;
        //    this.LastName = LastName;
        //}

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public Grades CalculateGrade()
        {
            if (Mark < D_MIN)
                return Grades.F;
            else if (Mark < C_MIN)
                return Grades.D;
            else if (Mark < B_MIN)
                return Grades.C;
            else if (Mark < A_MIN)
                return Grades.B;
            else //if (Mark >= A_MIN)
                return Grades.A;
            //else
               // return Grades.NULL;
        }

    //    public void Do()
    //    {
    //        //EnumHelper<Grades>.GetName(Grade);
    //    }
    //    public string DisplayGradeName(Grades Grade)
    //    {
    //        var DisplayName = Grade.GetAttribute<DisplayAttribute>();
    //        return DisplayName.Name;
    //    }
    }
}
