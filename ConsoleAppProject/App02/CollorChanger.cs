using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App02
{
    public static class CollorChanger
    {
        /// <summary>
        /// Change the color of the text depending of the input value.
        /// </summary>
        /// <param name="ChartBmiValue">The input value.</param>
        public static void ChangeColor(double ChartBmiValue)
        {

            if (ChartBmiValue > 39)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (ChartBmiValue > 30)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (ChartBmiValue > 24)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (ChartBmiValue > 18)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

        }
    }
}
