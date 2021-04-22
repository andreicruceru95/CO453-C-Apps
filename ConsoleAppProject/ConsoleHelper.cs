using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject
{
    /// <summary>
    /// This class will provide and validate any user input required across the 
    /// ConsoleApp project.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        ///  Print a message or App title on the screen.
        /// </summary>
        /// <param name="text">string input</param>
        /// <param name="title">type of text</param>
        public static void PrintString(string text, bool isTitle)
        {
            if(isTitle)
            {
                Console.WriteLine("\t\t--------------------------------------\n");
                Console.WriteLine($"\t\t\t{text}\n");
                Console.WriteLine("\t\t\tApp by Andrei Cruceru              \n");
                Console.WriteLine("\t\t--------------------------------------\n");
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        /// <summary>
        /// take input from the user
        /// </summary>
        /// <param name="choices">list of choices</param>
        /// <param name="message">A message to describe the list.</param>
        /// <returns>the user's choice number</returns>
        public static int SelectChoice(string message,string[] choices)
        {
            Console.WriteLine($"\n\t{message}\n");
            ListChoices(choices);

            return (int)(InputNumber("\n\tPlease enter your choice number >", 1, choices.Length));
        }

        /// <summary>
        /// Print choices on the screen
        /// </summary>
        /// <param name="choices">a list of choices</param>
        private static void ListChoices(string[] choices)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"\t{i + 1}\t{choices[i]}");
            }
        }

        /// <summary>
        /// Get an double type input from the user.
        /// </summary>
        /// <param name="prompt">input message</param>
        /// <returns>the number.</returns>
        public static double InputNumber(string prompt)
        {
            try
            {
                Console.Write($"\n\t{prompt}");

                return Convert.ToDouble(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("\tPlease type in a number!");

                return InputNumber(prompt);
            }
        }

        /// <summary>
        /// Validate that a number is inside a range.
        /// </summary>
        /// <param name="prompt">A message</param>
        /// <param name="min">the minumum number allowed</param>
        /// <param name="max">the maximum number allowed</param>
        /// <returns>A number allowed</returns>
        public static double InputNumber(string prompt, double min, double max)
        {
            var number = InputNumber(prompt);

            if (min <= number && number <= max)
            {
                return number;
            }
            else
            {
                Console.WriteLine($"\tThe number needs to be between {min} and {max}");

                return InputNumber(prompt, min, max);
            }
        }

        /// <summary>
        /// Read a string input from the user. The input cannot be null.
        /// </summary>
        /// <param name="message">Message passed to user</param>
        /// <returns>string input</returns>
        public static string InputString(string message)
        {
            Console.WriteLine($"\n\t{message}");
            string input = Console.ReadLine();

            if (!(string.IsNullOrWhiteSpace(input)))
                return input;

            else
            {
                Console.WriteLine("\n\tCannot leave empty!\n");
                return InputString(message);
            }
        }

        /// <summary>
        /// Print a string message on console with a given indentation level.
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="message"></param>
        public static void PrintString(IndentLevel layer, string message)
        {
            string indentation = TranslateLayer(layer);

            Console.WriteLine($"{indentation}{message}");
        }

        /// <summary>
        /// Translate a layer enum type to an indentation level.
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private static string TranslateLayer(IndentLevel layer)
        {
            switch(layer)
            {
                case IndentLevel.Level1:
                    return "\t";
                case IndentLevel.Level2:
                    return "\t\t";
                case IndentLevel.Level3:
                    return "\t\t\t";
                case IndentLevel.Level4:
                    return "\t\t\t\t";
                case IndentLevel.Level5:
                    return "\t\t\t\t\t";
            }
            return string.Empty;
        }
    }
}
