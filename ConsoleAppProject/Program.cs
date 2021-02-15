using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// This Project has been modified by:
    /// Andrei Cruceru 08/01/2021
    /// </summary>
    public static class Program
    {
        public const int APP01 = 1;
        public const int APP02 = 2;
        public const int APP03 = 3;
        public const int APP04 = 4;
        public const int APP05 = 5;
        public static BMI bmi = new BMI();

        public static string[] Apps = new string[]
        {
            "Distance Convertor",
            "BMI Calculator",
            "Student Grades",
            "Exit"
        };

        public static void Main(string[] args)
        {
            ConsoleHelper.PrintText("BNU CO453 Applications Programming", true);

            try
            {
                ChoseApplication(ConsoleHelper.SelectChoice("\tChose one of the following applications:",Apps));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}:\t{ex.Message}");
            }
        }

        public static void ChoseApplication(int AppNumber)
        {
            switch (AppNumber)
            {
                case APP01:
                    ConsoleHelper.PrintText("Distance Converter", true);

                    //Create an object
                    DistanceConverter converter = new DistanceConverter();
                    converter.RunDistanceConverter();

                    break;

                case APP02:
                    ConsoleHelper.PrintText("BMI Converter", true);
                    ConsoleHelper.PrintText(bmi.GetDescription(), false);
                    bmi.RunBmiConverter();
                    break;

                case APP03:
                    StudentMarks students = new StudentMarks();
                    students.Run();
                    break;

                case APP04:

                case APP05:

                default:                    
                    break;
            }
        }

    }
}
