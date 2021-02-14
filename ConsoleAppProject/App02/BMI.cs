using Microsoft.AspNetCore.Mvc;
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
    public class BMI
    {
        public const double FEET_IN_CM = 30.48;
        public const double INCH_IN_CM = 2.54;
        public const double POUND_IN_KG = 0.453592;
        public const double STONE_IN_KG = 6.35029;
        public const string E_OBESE = "40";
        public const string OBESE = "31";
        public const string OVERWEIGHT = "25";
        public const string HEALTHY = "19";
        public const string UNDERWEIGHT = "1";

        [BindProperty]
        public int Weight { get; set; }
        [BindProperty]
        public int WeightInStones { get; set; }
        [BindProperty]
        public int WeightInPounds { get; set; }

        [BindProperty]
        public int Height { get; set; }
        [BindProperty]
        public int HeightInFeet { get; set; }
        [BindProperty]
        public int HeightInInches { get; set; }
        public int Bmi { get; set; } = 0;

        public string[] UnitsType = new string[]
        {
            "Imperial",
            "Metric",
        };

        /// <summary>
        /// Run the application in steps.
        /// </summary>
        public void RunBmiConverter()
        {
            GetInput();
            CalculateBmi(false);
            Chart.CreateChart(Weight, Height);
            PrintChartDetails();
            PrintBMIDetails();
        }

        /// <summary>
        /// Get input from the user.
        /// If user choses metric, get weight in kilograms and height in centimeters.
        /// If user choses imperial, get weight in pounds and height in feet and inches for more precision.
        /// </summary>
        private void GetInput()
        {
            switch (ConsoleHelper.SelectChoice("Please chose a unit type from the following", UnitsType))
            {
                //if imperial
                case 1:
                    Weight = Convert.ToInt32((ConsoleHelper.InputNumber("Enter your weight in stones >") * STONE_IN_KG) +
                            (ConsoleHelper.InputNumber("Enter your weight in pounds >") * POUND_IN_KG));

                    Height = Convert.ToInt32((ConsoleHelper.InputNumber("Enter your heigth in feet >") * FEET_IN_CM) +
                            (ConsoleHelper.InputNumber("Enter your heigth in inches >") * INCH_IN_CM));                   

                    break;
                //if metric
                default:
                    Weight = Convert.ToInt32(ConsoleHelper.InputNumber("Enter your weight in kilograms >"));
                    Height = Convert.ToInt32(ConsoleHelper.InputNumber("Enter your height in centimeters >"));

                    break;
            }
        }

        /// <summary>
        /// Explain the chart and display user's bmi.
        /// </summary>
        private void PrintChartDetails()
        {
            Console.WriteLine("\n\tWHO (World Health Organisation) weight status as illustrated below:\n");

            CollorChanger.ChangeColor(E_OBESE);
            Console.WriteLine($"\n\t{EnumHelper<Categories>.GetName(Categories.E_OBESE)}");
            CollorChanger.ChangeColor(OBESE);
            Console.WriteLine($"\n\t{EnumHelper<Categories>.GetName(Categories.OBESE)}");
            CollorChanger.ChangeColor(OVERWEIGHT);
            Console.WriteLine($"\n\t{EnumHelper<Categories>.GetName(Categories.OVERWEIGHT)}");
            CollorChanger.ChangeColor(HEALTHY);
            Console.WriteLine($"\n\t{EnumHelper<Categories>.GetName(Categories.HEALTHY)}");
            CollorChanger.ChangeColor(UNDERWEIGHT);
            Console.WriteLine($"\n\t{EnumHelper<Categories>.GetName(Categories.UNDERWEIGHT)}");
        }

        /// <summary>
        /// Print details about the user's bmi.
        /// </summary>
        /// <param name="Weight">User's weight</param>
        /// <param name="Height">User's Height</param>
        private void PrintBMIDetails()
        {
            Console.WriteLine("\n\n\tYou should see your BMI value highlighted on the chart.\n\t" +
               "If it is not there, is because your height or weight is higher than the average.\n\t " +
               "Your BMI value is aproximately" + Bmi);
        }

        //public int CalcTest()
        //{
        //    return (int)Calculator.CalculateBmi(Weight, Height);
        //}

        /// <summary>
        /// Calculate Bmi;
        /// </summary>
        public string CalculateBmi(bool isMetric)
        {
            if(!isMetric)
            {
                Weight = Convert.ToInt32((WeightInPounds * POUND_IN_KG) + (WeightInStones * STONE_IN_KG));
                Height = Convert.ToInt32((HeightInFeet * FEET_IN_CM) + (HeightInInches * INCH_IN_CM));
               
            }
            Bmi = (int)Calculator.CalculateBmi(Weight, Height);
            var Details = CalculateCategory(Bmi);
            return $"Your result is {Bmi}. You are in the {Details.Item1} range. {Details.Item2}";
        }

        public string GetDescription()
        {
            return "\t\tYour BMI, or Body Mass Index, is a measure of your weight compared to your height.\n" +
                "\t Accurate assessments of obesity are important, as being overweight or obese significantly\n" +
                "\tincreases your risk of a variety of medical conditions including type 2 diabetes, heart disease and cancer.\n\n" +
                "\t\tFor most adults, BMI gives a good estimate of your weight-related health risks. If your BMI is over 35,\n" +
                "\tyour weight is definitely putting your health at risk,tregardless of the factors below. However,\n" +
                "\tthere are some situations where BMI may underestimate or overestimate these risks in the 25 - 35 BMI range.\n\n" +
                "\tThe main ones are:\n\n" +
                "\t\t-Children\n" +
                "\t\t-Pregnant women.\n" +
                "\t\tMuscle Builders.\n" +
                "\t\tBAME: Black, Asian and other minority ethnic groups.\n";
        }

        public Tuple<string, string> CalculateCategory(int Bmi)
        {

            if (Bmi >= Convert.ToInt32(E_OBESE))
            {
                return Tuple.Create(EnumHelper<Categories>.GetName(Categories.E_OBESE), EnumHelper<Categories>.GetDescription(Categories.E_OBESE));
            }
            else if (Bmi >= Convert.ToInt32(OBESE))
            {
                return Tuple.Create(EnumHelper<Categories>.GetName(Categories.OBESE), EnumHelper<Categories>.GetDescription(Categories.OBESE));
            }
            else if (Bmi >= Convert.ToInt32(OVERWEIGHT))
            {
                return Tuple.Create(EnumHelper<Categories>.GetName(Categories.OVERWEIGHT), EnumHelper<Categories>.GetDescription(Categories.OVERWEIGHT));
            }
            else if (Bmi >= Convert.ToInt32(HEALTHY))
            {
                return Tuple.Create(EnumHelper<Categories>.GetName(Categories.HEALTHY), EnumHelper<Categories>.GetDescription(Categories.HEALTHY));
            }
            else
            {
                return Tuple.Create(EnumHelper<Categories>.GetName(Categories.UNDERWEIGHT), EnumHelper<Categories>.GetDescription(Categories.UNDERWEIGHT));
            }
        }
    }
}
