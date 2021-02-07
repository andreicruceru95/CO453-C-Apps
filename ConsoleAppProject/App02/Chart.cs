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
        public const int MIN_COL = 2;
        public const double FEET_IN_CM = 30.48;
        public const double INCH_IN_CM = 2.54;
        public const double POUND_IN_KG = 0.453592;
        
        public static string[,] BmiChart = new string[21, 26];
        
        /// <summary>
        /// Create the layout of the chart.
        /// </summary>
        public static void CreateChart(int Weight, int Height)
        {
            int RowCount = 0;
            int ColCount = 0;
            int FeetValue = 5;
            int InchAmount = 0;
            int InchMax = 11;
            int PoundToAdd = 5;
            int MinPoundValue = 95;
            int WeightOnChart = 0;
            int HeightOnChart = 0;

            BmiChart[0, 0] = "  W  ";
            BmiChart[0, 1] = " LBS ";
            BmiChart[1, 0] = "     ";
            BmiChart[1, 1] = " KGS ";
            BmiChart[MIN_COL, 0] = "  H  ";
            BmiChart[MIN_COL, 1] = "     ";
            BmiChart[MIN_COL + 1, 0] = " FT  ";
            BmiChart[MIN_COL + 1, 1] = " CM  ";

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

                /**
                 * Check if the closest height value on the chart to the user's height.
                 */
                if (((i > MIN_ROW + 1) && Height <= Convert.ToDouble(BmiChart[i, 1])))
                {
                    RowCount++;

                    if (Calculator.GetClosest(Convert.ToInt32(BmiChart[i - 1, 1]), Convert.ToInt32(BmiChart[i, 1]), Height) == 0)
                    {

                        HeightOnChart = i - (RowCount);
                    }
                    else
                    {
                        HeightOnChart = i - (RowCount - 1);
                    }
                }

                InchAmount++;
            }
            /**
             * Add the weight values to the top.
             */
            for (int j = MIN_COL; j < LENGTH; j++)
            {
                MinPoundValue += PoundToAdd;

                BmiChart[0, j] = " " + MinPoundValue + " ";
                BmiChart[1, j] = " " + Math.Round((MinPoundValue * POUND_IN_KG), 0) + "  ";
                BmiChart[MIN_COL, j] = "     ";

                /**
                * Check if the closest weight value on the chart to the user's weight.
                */
                if (((j > MIN_COL) && Weight <= Convert.ToInt32(BmiChart[1, j])))
                {
                    ColCount++;

                    if (Calculator.GetClosest(Convert.ToInt32(BmiChart[1, j - 1]), Convert.ToInt32(BmiChart[1, j]), Weight) == 0)
                    {
                        WeightOnChart = j - (ColCount);
                    }
                    else
                    {
                        WeightOnChart = j - (ColCount - 1);
                    }
                }
            }

            WriteBmiValues();
            PrintChart(WeightOnChart, HeightOnChart);
        }

        /// <summary>
        /// Print the chart on the screen.
        /// </summary>
        /// <param name="UserBmi">The user's bmi value.</param>
        public static void PrintChart( int WeightOnChart, int HeightOnChart)
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
                        int ChartBmiValue = Convert.ToInt32(BmiChart[i, j]);

                        CollorChanger.ChangeColor(ChartBmiValue);
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
        /// <param name="UserWeight"></param>
        /// <param name="UserHeight"></param>
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
