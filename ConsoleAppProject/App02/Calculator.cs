using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This class will calculate either:
    /// -the bmi value for an input weight and height in metric system.
    /// -the closest value on the chart for the given bmi.
    /// </summary>
    public static class Calculator
    {
        public const int HEIGHT_START = 5;
        public const int WEIGHT_START = 3;
        /// <summary>
        /// Recieve two values and a target and return the closest value to the target.
        /// </summary>
        /// <param name="ValOne">first value</param>
        /// <param name="ValTwo">second value</param>
        /// <param name="Target">target value</param>
        /// <returns>the closest value</returns>
        public static int GetClosest(int ValOne, int ValTwo, int Target)
        {
            if (Target - ValOne >= ValTwo - Target)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Iterate the array and compare the user's weight and height to the chart values.
        /// </summary>
        /// <param name="Weight">User's Weight</param>
        /// <param name="Height">User's height</param>
        /// <param name="Array">The 2D chart</param>
        /// <returns>A pair of (row, col) values</returns>
        public static Tuple<int,int> GetIndex(int Weight, int Height, string[,] Array)
        {
            int RowIndex = 0;
            int ColIndex = 0;

            for (int i = HEIGHT_START; i < Array.GetLength(0); i++)
            {
                for(int j = WEIGHT_START; j<Array.GetLength(1); j++)
                {
                    /**
                     * If height, weight <= then chart value then we are returning 
                     * the closest value of the chart to the user's weight and height. 
                     */
                    if((Convert.ToInt32(Array[i,1]) >= Height) && (Convert.ToInt32(Array[1, j]) >= Weight))
                    {
                        if ((GetClosest(Convert.ToInt32(Array[i - 1, 1]), Convert.ToInt32(Array[i, 1]), Height) == 1))
                        {
                            RowIndex = i;
                        }
                        else
                            RowIndex = i - 1;

                        if ((GetClosest(Convert.ToInt32(Array[1, j - 1]), Convert.ToInt32(Array[1, j]), Weight) == 1))
                        {
                            ColIndex = j;
                        }
                        else
                            ColIndex = j - 1;

                        return Tuple.Create(RowIndex, ColIndex);
                    }
                }
            }

            return Tuple.Create(0, 0);
        }



        /// <summary>
        /// Calculate BMI for a given weight and height.
        /// </summary>
        /// <param name="weight">Input weight</param>
        /// <param name="height">Input height</param>
        /// <returns>Bmi as integer value.</returns>
        public static double CalculateBmi(int Kilograms, double Centimeters)
        {
            int CmInMeters = 100;
            double Meters = Centimeters / CmInMeters;
            return (Kilograms / (Meters * Meters));
        }
    }
}
