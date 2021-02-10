using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This class will create and display a bmi chart with a highlited
    /// value for the user's bmi.
    /// The chart will contain multiple collors to display the bmi values according to their danger
    /// to health.
    /// </summary>
    public static class Chart
    {
        public const int LENGTH = 26;
        public const int HEIGHT = 21;
        public const int MIN_ROW = 4;
        public const int MAX_ROW = 21;
        public const int MIN_COL = 2;
        public const int MAX_COL = 26;
        public const double FEET_IN_CM = 30.48;
        public const double INCH_IN_CM = 2.54;
        public const double POUND_IN_KG = 0.453592;

        public static string[,] BmiChart = new string[21, 26];

        /// <summary>
        /// Create the layout of the chart.
        /// </summary>
        /// <param name="Height">User's Height</param>
        /// <param name="Weight">User's weight</param>
        public static void CreateChart(int Height, int Weight)
        {
            BmiChart[0, 0] = "  W  ";
            BmiChart[0, 1] = " LBS ";
            BmiChart[1, 0] = "     ";
            BmiChart[1, 1] = " KGS ";
            BmiChart[MIN_COL, 0] = "  H  ";
            BmiChart[MIN_COL, 1] = "     ";
            BmiChart[MIN_COL + 1, 0] = " FT  ";
            BmiChart[MIN_COL + 1, 1] = " CM  ";

            //steps:
            AddToLeft();
            AddToTop();
            WriteBmiValues();

            //tuple
            var Index = Calculator.GetIndex(Height, Weight, BmiChart);

            //pass the 2 variables of the tuple
            PrintChart(Index.Item1, Index.Item2);
        }
        /// <summary>
        /// Add the values to the left of the chart.
        /// </summary>
        private static void AddToLeft()
        {
            var FeetValue = 5;
            var InchAmount = 0;
            const int InchMax = 11;
            /**
             * Add the Height values to the left
             */
            for (int i = MIN_ROW; i < HEIGHT; i++)
            {
                if (InchAmount == InchMax + 1)
                {
                    FeetValue++;
                    InchAmount = 0;
                }
                if (InchAmount >= InchMax - 1)
                {
                    BmiChart[i, 0] = " " + FeetValue + "\"" + InchAmount;
                }
                else
                {
                    BmiChart[i, 0] = " " + FeetValue + "\"" + InchAmount + " ";
                }

                BmiChart[i, 1] = " " + Math.Round((FeetValue * FEET_IN_CM) + (InchAmount * INCH_IN_CM), 0) + " ";
                InchAmount++;
            }
        }

        /// <summary>
        /// Add Values to the top of the chart
        /// </summary>
        private static void AddToTop()
        {
            const int PoundToAdd = 5;
            var MinPoundValue = 95;
            /**
             * Add the weight values to the top.
             */
            for (int j = MIN_COL; j < LENGTH; j++)
            {
                MinPoundValue += PoundToAdd;

                BmiChart[0, j] = " " + MinPoundValue + " ";
                BmiChart[1, j] = " " + Math.Round((MinPoundValue * POUND_IN_KG), 0) + "  ";
                BmiChart[MIN_COL, j] = "     ";
            }
        }

        /// <summary>
        /// Print the chart on the screen.
        /// </summary>
        /// <param name="HeightOnChart">The user's height value on the chart.</param>
        /// <param name="WeightOnChart">The user's weight value on the chart.</param>
        public static void PrintChart(int HeightOnChart, int WeightOnChart)
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {
                    /**
                     * Change the text collor for the weight and height values.
                     */
                    if ((i == 0) || (j == 0) || (i == 1) || (j == 1))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else if ((i > MIN_ROW - 1) && (j > MIN_COL - 1))
                    {
                        CollorChanger.ChangeColor(BmiChart[i, j]);
                    }

                    //Highlight the user's bmi
                    if ((i == HeightOnChart) && (j == WeightOnChart))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(BmiChart[i, j]);
                }

                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Calculate and write the BMI values in the chart.
        /// </summary>
        public static void WriteBmiValues()
        {
            for (int i = MIN_ROW; i < HEIGHT; i++)
            {
                for (int j = MIN_COL; j < LENGTH; j++)
                {
                    BmiChart[i, j] = " " + Math.Round(Calculator.CalculateBmi(Convert.ToInt32(BmiChart[1, j]), Convert.ToInt32(BmiChart[i, 1])), 0) + "  ";

                }
            }
        }
    }
}
