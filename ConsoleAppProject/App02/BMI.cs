using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This application will calculate the bmi for some input weight and height.
    /// The user can pick between imperial or metric units before inputing values.
    /// </summary>
    /// <author>
    /// Andrei Cruceru version 1.3
    /// </author>
    public static class BMI
    {
        public const string METRIC = "metric";
        public const string IMPERIAL = "imperial";
        public const string EXIT = "exit";
        public const string WEIGHT_MESSAGE = "Please enter your weight in ";
        public const string HEIGHT_MESSAGE = "Please enter your height in ";
        public const string IMP_HEIGHT_MESSAGE = "Please enter the number of ";
        
        public const double FEET_IN_CM = 30.48;
        public const double INCH_IN_CM = 2.54;
        public const double POUND_IN_KG = 0.453592;     
               

        /// <summary>
        /// Run the application in steps.
        /// </summary>
        public static void RunBmiConverter()
        {
            GetInput();
        }
        /// <summary>
        /// Get input from the user.
        /// If user choses metric, get weight in kilograms and height in centimeters.
        /// If user choses imperial, get weight in pounds and height in feet and inches for more precision.
        /// </summary>
        private static void GetInput()
        {
            //int Weight = 0;
            //int Height = 0;

            bool finished = false;
            while (!finished)
            {
                try
                {
                    Console.WriteLine("\tPlease chose a unit type: \n\t0. Metric\n\t1. Imperial\n\t2. Exit \n\n\n\t>");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {

                        case 0:
                            Console.WriteLine(WEIGHT_MESSAGE + "Kilograms");
                            int Weight = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine(HEIGHT_MESSAGE + "centimeters");
                            int Height = Convert.ToInt32(Console.ReadLine());
                            
                            Display(Weight, Height);

                            break;

                        case 1:
                            Console.WriteLine(WEIGHT_MESSAGE + "Pounds");
                            int PoundsAmount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine(IMP_HEIGHT_MESSAGE + "feet");
                            int FeetAmount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine(IMP_HEIGHT_MESSAGE + "inches");
                            int InchAmount = Convert.ToInt32(Console.ReadLine());
                            
                            int ImperialHeight = Convert.ToInt32((FeetAmount * FEET_IN_CM) + (InchAmount * INCH_IN_CM));
                            int ImperialWeight = Convert.ToInt32((PoundsAmount * POUND_IN_KG));

                            Display(ImperialWeight, ImperialHeight);

                            break;

                        case 2:
                            finished = true;
                            break;

                        default:
                            Console.WriteLine("\tYour choice is not an option!\n\n\tPlease chose between metric or imperial");
                            
                            break;
                    }
                    
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tSomething Went Wrong, try again!\n\n\tMake sure you input the right numbers!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }              

        /// <summary>
        /// Calculate and print the chart on the screen.
        /// </summary>
        private static void Display(int Weight, int Height)
        {
            Chart.CreateChart(Weight, Height);
            PrintChartDetails();
            PrintBMIDetails(Weight, Height);
        }

        /// <summary>
        /// Explain the chart and display user's bmi.
        /// </summary>
        private static void PrintChartDetails()
        {
            CollorChanger.ChangeColor(40);
            Console.WriteLine("\tExtremely Obese");
            CollorChanger.ChangeColor(31);
            Console.WriteLine("\tObese");
            CollorChanger.ChangeColor(25);
            Console.WriteLine("\tOverweight");
            CollorChanger.ChangeColor(19);
            Console.WriteLine("\tHealthy");
            CollorChanger.ChangeColor(1);
            Console.WriteLine("\tUnderWeight");              
        }

        /// <summary>
        /// Print the user's bmi on the screen using the same collor as the chart value.
        /// </summary>
        private static void PrintBMIDetails(int Weight, int Height)
        {
            double UserBMI = Math.Round(Calculator.CalculateBmi(Weight, Height), 0);

            CollorChanger.ChangeColor(UserBMI);

            Console.WriteLine("\n\n\tYou should see your BMI value highlighted on the chart.\n\t" +
               "If it is not there, is because your height or weight is higher than the average.\n\t " +
               "Your BMI value is aproximately" + UserBMI);
        }

        
    }
}
