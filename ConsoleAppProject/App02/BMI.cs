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
        public const int EXIT_CHOICE = 2;

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
            var finished = false;
            do
            {
                try
                {
                    Console.WriteLine($"\tPlease chose a unit type: \n\t0. {METRIC} \n\t1. {IMPERIAL}\n\t2. {EXIT}\n\n\n\t\t>");
                    var choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {

                        case 0:
                            Console.WriteLine($"{WEIGHT_MESSAGE} Kilograms");
                            var Weight = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"{HEIGHT_MESSAGE} centimeters");
                            var Height = Convert.ToInt32(Console.ReadLine());

                            Display(Weight, Height);

                            break;

                        case 1:
                            Console.WriteLine($"{WEIGHT_MESSAGE} Pounds");
                            var PoundsAmount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"{IMP_HEIGHT_MESSAGE} feet");
                            var FeetAmount = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"{IMP_HEIGHT_MESSAGE} inches");
                            var InchAmount = Convert.ToInt32(Console.ReadLine());

                            var ImperialHeight = Convert.ToInt32((FeetAmount * FEET_IN_CM) + (InchAmount * INCH_IN_CM));
                            var ImperialWeight = Convert.ToInt32((PoundsAmount * POUND_IN_KG));

                            Display(ImperialWeight, ImperialHeight);

                            break;

                        case EXIT_CHOICE:
                            finished = true;
                            break;

                        default:
                            Console.WriteLine($"\tYour choice is not an option!\n\n\tPlease chose between {METRIC} or {IMPERIAL}");

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType()}:\t{ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while(!finished);
        }

        /// <summary>
        /// Display the chart on the screen.
        /// </summary>
        /// <param name="Weight">User's weight</param>
        /// <param name="Height">user's height</param>
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
            Console.WriteLine("\n\tWHO (World Health Organisation) weight status as illustrated below:\n");

            CollorChanger.ChangeColor(40);
            Console.WriteLine("\n\tExtremely Obese");
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
        /// Print details about the user's bmi.
        /// </summary>
        /// <param name="Weight">User's weight</param>
        /// <param name="Height">User's Height</param>
        private static void PrintBMIDetails(int Weight, int Height)
        {
            var UserBMI = Math.Round(Calculator.CalculateBmi(Weight, Height), 0);

            CollorChanger.ChangeColor(UserBMI);

            Console.WriteLine("\n\n\tYou should see your BMI value highlighted on the chart.\n\t" +
               "If it is not there, is because your height or weight is higher than the average.\n\t " +
               "Your BMI value is aproximately" + UserBMI);
        }

        public static string GetDescription()
        {
            return "\tYour BMI, or Body Mass Index, is a measure of your weight compared to your height. Accurate assessments of obesity are important,\n" +
                "as being overweight or obese significantly increases your risk of a variety of medical conditions including type 2 diabetes, heart disease and cancer.\n" +
                "\tFor most adults, BMI gives a good estimate of your weight-related health risks. If your BMI is over 35, your weight is definitely putting your health at risk,\n" +
                "regardless of the factors below. However, there are some situations where BMI may underestimate or overestimate these risks in the 25 - 35 BMI range. The main ones are:\n" +
                "\t-Children\n" +
                "\t-Pregnant women.\n" +
                "\tMuscle Builders.\n" +
                "\tBAME: Black, Asian and other minority ethnic groups.\n";
        }
    }
}
