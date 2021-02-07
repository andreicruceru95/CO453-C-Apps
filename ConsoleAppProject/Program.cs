using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Andrei Cruceru 06/01/2021
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            PrintHeading("BNU CO453 Applications Programming");
            ChoseApplication(1);
           
        }

        public static void ChoseApplication(int AppNumber)
        {
            switch (AppNumber)
            {
                case 0:
                    PrintHeading("Distance Converter");

                    DistanceConverter converter = new DistanceConverter();
                    converter.RunDistanceConverter();
                    break;

                case 1:
                    PrintHeading("BMI Converter");

                    BMI.RunBmiConverter();
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("\tThis number is not recognized. Try again!");
                    break;
            }
        }

        /// <summary>
        ///  Print a heading with app and author name.
        /// </summary>
        private static void PrintHeading(string title)
        {
            Console.WriteLine("\t\t--------------------------------------\n");
            Console.WriteLine("\t\t\t" + title + "\n");
            Console.WriteLine("\t\t\t   App by Andrei Cruceru              \n");
            Console.WriteLine("\t\t--------------------------------------\n");
            Console.Beep();
        }

    }
}
