using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This application will read integer type values from the user
    /// and convert it to a chosen unit value.
    /// </summary>
    /// <author>
    /// Andrei Cruceru version 0.1
    /// </author>
    public class DistanceConverter
    {
        /// <summary>
        /// Run the program in steps.
        /// </summary>
        public void RunDistanceConverter()
        {
            PrintHeading();
            int valueToBeConverted = SelectMainUnit();
            int valueToConvertTo = SelectConversionUnit();
            double amount = ReadAmount();

            double result =(ConvertUnit(valueToBeConverted) / ConvertUnit(valueToConvertTo)) * amount;

            Console.Clear();
            PrintHeading();

            Console.WriteLine("\t" + amount + " " + TranslateUnit(valueToBeConverted)  +
                            " translates to " + result + " " + TranslateUnit(valueToConvertTo));

        }
        /// <summary>
        ///  Print a heading with app and author name.
        /// </summary>
        private void PrintHeading()
        {
            Console.WriteLine("----------------------------\n");
            Console.WriteLine("     Distance converter     \n");
            Console.WriteLine("   App by Andrei Cruceru    \n");
            Console.WriteLine("----------------------------\n");
        }
        /// <summary>
        /// Ask the user for an unit input.
        /// </summary>        
        public int SelectMainUnit()
        {
            Console.WriteLine("\tPlease enter the number associated with the distance unit you want to convert: \n");

            PrintUnitList();   

            return int.Parse(Console.ReadLine());  
        }

        /// <summary>
        /// Ask the user to input a conversion unit.
        /// </summary>
        private int SelectConversionUnit()
        {
            Console.WriteLine("\tPlease enter the number asociated with the distance unit to convert to: \n");

            PrintUnitList();

            return int.Parse(Console.ReadLine());
            
        }

        /// <summary>
        /// Print a list of distance unit options.
        /// </summary>
        private void PrintUnitList()
        {
            Console.WriteLine("\t1." + DistanceUnits.Feet + "\n");
            Console.WriteLine("\t2." + DistanceUnits.Metres + "\n");
            Console.WriteLine("\t3." + DistanceUnits.Kilometres + "\n");
            Console.WriteLine("\t4." + DistanceUnits.Miles + "\n");
            Console.WriteLine("\t5." + DistanceUnits.NoUnit + "\n");
        }

        /// <summary>
        /// Ask the user for an amount that need to be converted.
        /// </summary>
        /// <returns></returns>
        private double ReadAmount()
        {
            Console.WriteLine("\n\tPlease select amount!");
            
            return double.Parse(Console.ReadLine()); 

        }

        /// <summary>
        /// Return the value of each unit in miles.
        /// </summary>
        /// <param name="choice">Represents the user's input.</param>
        /// <returns>Return the value of the input in miles.</returns>
        private double ConvertUnit(int choice)
        {
            switch(choice)
            {
                case 1: 
                     return 0.000189394;
                case 2:
                     return 0.000621371;
                case 3:
                    return 0.621371;
                case 4:
                    return 1;
                default:
                    return 1; 
            }
        }

        private String TranslateUnit(int unitNumber)
        {
            switch(unitNumber)
            {
                case 1:
                    return "feet";
                case 2:
                    return "meters";
                case 3:
                    return "kilometers";
                case 4:
                    return "miles";
                default:
                    return "no unit";
            }
        }

        
   }
}
