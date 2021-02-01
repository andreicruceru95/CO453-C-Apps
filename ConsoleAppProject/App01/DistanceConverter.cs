using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This application will read integer type values from the user
    /// and convert it to a chosen unit value.
    /// In order to convert any unit type to any unit type 
    /// this program will convert all the units to a common unit and will calculate
    /// the result.
    /// In mathematical terms, if x = amount, a = unit to convert, b = unit to convert to and c = common unit,
    /// then x * a = b is the same as x * a * c = b * c.
    /// </summary>
    /// <author>
    /// Andrei Cruceru version 0.1
    /// </author>
    public class DistanceConverter
    {
        public const double FEET_IN_MILES = 0.000189394;
        public const double METERS_IN_MILES = 0.000621371;
        public const double KILOMETERS_IN_MILES = 0.621371;
        public const double MILES_IN_MILES = 1;
        public const double NO_UNIT_IN_MILES = 1;
        public const int ROUND_DECIMALS = 3;

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
                            " translates to " + Math.Round(result, ROUND_DECIMALS) + " " + TranslateUnit(valueToConvertTo));

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
                    return FEET_IN_MILES;
                case 2:
                    return METERS_IN_MILES;
                case 3:
                    return KILOMETERS_IN_MILES;
                case 4:
                    return MILES_IN_MILES;
                default:
                    return NO_UNIT_IN_MILES;
            }
        }

        /// <summary>
        /// Translate the unit from int data type to string data type.
        /// </summary>
        /// <param name="unitNumber">The input integer of the user.</param>
        /// <returns>The respresentation of the integer in String type.</returns>
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
