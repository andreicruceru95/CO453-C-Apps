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
        public const int APP01 = 1;
        public const int APP02 = 2;
        public const int APP03 = 3;
        public const int APP04 = 4;
        public const int APP05 = 5;
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            PrintHeading("BNU CO453 Applications Programming");

            try
            {
                Console.WriteLine("\tChose Application:");
                ListApps();

                ChoseApplication(Convert.ToInt32(Console.ReadLine()));
            }
            catch(ArgumentOutOfRangeException)
            {
                
            }

           
        }

        public static void ChoseApplication(int AppNumber)
        {
            switch (AppNumber)
            {
                case APP01:
                    PrintHeading("Distance Converter");

                    DistanceConverter converter = new DistanceConverter();
                    converter.RunDistanceConverter();
                    break;

                case APP02:
                    PrintHeading("BMI Converter");

                    BMI.RunBmiConverter();
                    break;

                case APP03:
                    break;

                case APP04:
                    break;

                case APP05:
                    break;

                default:
                    Console.WriteLine("\tThis number is not recognized. Try again!");
                    break;
            }
        }

        /// <summary>
        ///  Print a heading with app and author name.
        /// </summary>
        private static void PrintHeading(string Title)
        {
            Console.WriteLine("\t\t--------------------------------------\n");
            Console.WriteLine("\t\t\t" + Title + "\n");
            Console.WriteLine("\t\t\t   App by Andrei Cruceru              \n");
            Console.WriteLine("\t\t--------------------------------------\n");
            Console.Beep();
        }

        /// <summary>
        /// List the applications
        /// </summary>
        private static void ListApps()
        {
            Console.WriteLine("\t1. " + Apps.DistanceConverter + "\n\t2. " + Apps.BMIConverter +
                "\n\t3. " + Apps.StudentMarks + "\n\t4. " + Apps.SocialNetwork + "\n\t5. " + Apps.RPS);
        }

    }
}
