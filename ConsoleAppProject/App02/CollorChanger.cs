using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App02
{
    public static class CollorChanger
    {
        public const int RED = 39;
        public const int MAGENTA = 30;
        public const int BLUE = 24;
        public const int GREEN = 18;

        /// <summary>
        /// Change the color of the text depending of the input value.
        /// </summary>
        /// <param name="ChartBmiValue">The input value.</param>
        public static void ChangeColor(string ChartBmiValue)
        {
            var value = Convert.ToInt32(ChartBmiValue);
            
            if (value > RED)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (value > MAGENTA)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (value > BLUE)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (value > GREEN)
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
