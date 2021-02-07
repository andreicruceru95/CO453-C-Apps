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
        /// Calculate BMI for a given weight and height.
        /// </summary>
        /// <param name="weight">Input weight</param>
        /// <param name="height">Input height</param>
        /// <returns>Bmi as integer value.</returns>
        public static double CalculateBmi(int Kilograms, double Centimeters)
        {
            double Meters = Centimeters / 100;
            return (Kilograms / (Meters * Meters));
        }
    }
}
