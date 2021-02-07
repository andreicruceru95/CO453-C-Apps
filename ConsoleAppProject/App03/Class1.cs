using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleAppProject.App03
{
    public class Student
    {
        public int  StudentID { get; set; }
        [Required, StringLength(20), Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required, StringLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Range(0, 100)]
        public int Mark { get; set; }
    }
}
