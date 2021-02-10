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
        public static bool GetClosest(int ValOne, int ValTwo, int Target)
        {
            return Target - ValOne >= ValTwo - Target;
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


            for (int i = HEIGHT_START; i < Array.GetLength(0); i++)
            {
                for(int j = WEIGHT_START; j<Array.GetLength(1); j++)
                {

                    /**
                     * If height, weight <= chart value then we are returning
                     * the closest values from the chart.
                     */
                    if((Convert.ToInt32(Array[i,1]) >= Height) && (Convert.ToInt32(Array[1, j]) >= Weight))
                    {
                        int RowIndex;
                        RowIndex = (GetClosest(Convert.ToInt32(Array[i - 1, 1]), Convert.ToInt32(Array[i, 1]), Height)) ? i : i - 1;

                        int ColIndex;
                        ColIndex = (GetClosest(Convert.ToInt32(Array[1, j - 1]), Convert.ToInt32(Array[1, j]), Weight)) ? j : j - 1;

                        return Tuple.Create(RowIndex, ColIndex);
                    }
                }
            }

            return Tuple.Create(0, 0);
        }

        /// <summary>
        /// Calculate BMI for a given weight and height.
        /// </summary>
        /// <param name="Kilograms">Input weight</param>
        /// <param name="Centimeters">Input height</param>
        public static double CalculateBmi(int Kilograms, double Centimeters)
        {
            const int CmInMeters = 100;
            var Meters = (Centimeters / CmInMeters);

            return (Kilograms / (Meters * Meters));
        }
    }
}
