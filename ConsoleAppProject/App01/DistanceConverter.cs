using System;
using System.ComponentModel.DataAnnotations;
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
    /// Andrei Cruceru version 0.6
    /// </author>
    public class DistanceConverter
    {
        public const int NUMBER_OF_DECIMALS = 3;
        public const double FEET_IN_MILES = 0.000189394;
        public const double METER_IN_MILES = 0.000621371;
        public const double KILOMETRE_IN_MILES = 0.621371;
        public const double CENTIMETER_IN_MILES = 6.2137e-6;
        public const double MILIMETRE_IN_MILES = 6.2137e-7;
        public const double MICROMETRE_IN_MILES = 6.2137e-10;
        public const double NANOMETRE_IN_MILES = 6.2137e-13;
        public const double YARD_IN_MILES = 0.000568182;
        public const double INCH_IN_MILES = 1.5783e-5;
        public const double NAUTICAL_MILE_IN_MILES = 1.15078;

        //[BindProperty]
        public double Amount { get; set; }
        //[BindProperty]
       public UnitsEnum Converted { get; set; }
        //[BindProperty]
        public UnitsEnum ToConvert { get; set; }
        public double Result { get; set; }

        /// <summary>
        /// On form submit this method will be called.
        /// The method does not return anything, but in exchange will calculate the result,
        /// that is displayed on the screen.
        /// </summary>
        public void OnPost()
        {
            Result = Math.Round((ConvertUnit(Converted) / ConvertUnit(ToConvert) * Amount), NUMBER_OF_DECIMALS);
        }
        /// <summary>
        /// Return the covnversion in miles of an input value.
        /// </summary>
        /// <param name="choice">The value to be converted.</param>
        /// <returns>Return a value converted, or return 1 for miles (1 mile = 1 mile)</returns>
        public static double ConvertUnit(UnitsEnum choice)
        {
            return choice switch
            {
                UnitsEnum.FEET => FEET_IN_MILES,
                UnitsEnum.METER => METER_IN_MILES,
                UnitsEnum.KILOMETRE => KILOMETRE_IN_MILES,
                UnitsEnum.MILE => 1,
                UnitsEnum.CENTIMETER => CENTIMETER_IN_MILES,
                UnitsEnum.MILIMETRE => MILIMETRE_IN_MILES,
                UnitsEnum.NANOMETRE => NANOMETRE_IN_MILES,
                UnitsEnum.YARD => YARD_IN_MILES,
                UnitsEnum.INCH => INCH_IN_MILES,
                UnitsEnum.NAUTICAL_MILE => NAUTICAL_MILE_IN_MILES,
                _ => 1,
            };
        }

        /// <summary>
        /// Run the program in steps.
        /// </summary>
        public static void RunDistanceConverter()
        {
            var valueToBeConverted = Math.Abs(SelectMainUnit());
            var valueToConvertTo = Math.Abs(SelectConversionUnit());
            var amount = Math.Abs(ReadAmount());

            var result =(ConvertUnit(valueToBeConverted) / ConvertUnit(valueToConvertTo)) * amount;

            Console.Clear();

            Console.Beep();

            Console.WriteLine("\t" + amount + " " + TranslateUnit(valueToBeConverted)  +
                            " translates to " + Math.Round(result, NUMBER_OF_DECIMALS) + " " + TranslateUnit(valueToConvertTo));

        }
        /// <summary>
        /// Ask the user for an unit input.
        /// </summary>
        private static int SelectMainUnit()
        {
            Console.WriteLine("\tPlease enter the number associated with the distance unit you want to convert: \n");

            PrintUnitList();

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Ask the user to input a conversion unit.
        /// </summary>
        private static int SelectConversionUnit()
        {
            Console.WriteLine("\tPlease enter the number asociated with the distance unit to convert to: \n");

            PrintUnitList();

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Print a list of distance unit options.
        /// </summary>
        private static void PrintUnitList()
        {
            Console.WriteLine("\t1." + UnitsEnum.FEET + "\n");
            Console.WriteLine("\t2." + UnitsEnum.METER + "\n");
            Console.WriteLine("\t3." + UnitsEnum.KILOMETRE + "\n");
            Console.WriteLine("\t4." + UnitsEnum.MILE + "\n");
            Console.WriteLine("\t5." + UnitsEnum.MICROMETRES + "\n");
            Console.WriteLine("\t6." + UnitsEnum.MILIMETRE + "\n");
            Console.WriteLine("\t7." + UnitsEnum.NAUTICAL_MILE + "\n");
            Console.WriteLine("\t8." + UnitsEnum.CENTIMETER + "\n");
            Console.WriteLine("\t9." + UnitsEnum.NANOMETRE + "\n");
            Console.WriteLine("\t10." + UnitsEnum.YARD + "\n");
            Console.WriteLine("\t11." + UnitsEnum.INCH + "\n");
        }

        /// <summary>
        /// Ask the user for an amount that need to be converted.
        /// </summary>
        /// <returns></returns>
        private static double ReadAmount()
        {
            Console.WriteLine("\n\tPlease select amount!");

            return double.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Return the value of each unit in miles.
        /// </summary>
        /// <param name="choice">Represents the user's input.</param>
        /// <returns>Return the value of the input in miles.</returns>
        private static double ConvertUnit(int choice)
        {
            return choice switch
            {
                1 => FEET_IN_MILES,
                2 => METER_IN_MILES,
                3 => KILOMETRE_IN_MILES,
                4 => 1,
                5 => MICROMETRE_IN_MILES,
                6 => MILIMETRE_IN_MILES,
                7 => NAUTICAL_MILE_IN_MILES,
                8 => CENTIMETER_IN_MILES,
                9 => NANOMETRE_IN_MILES,
                10 => YARD_IN_MILES,
                11 => INCH_IN_MILES,
                _ => 1,
            };
        }

        /// <summary>
        /// Translate the unit from int data type to string data type.
        /// </summary>
        /// <param name="unitNumber">The input integer of the user.</param>
        /// <returns>The respresentation of the integer in String type.</returns>
        private static String TranslateUnit(int unitNumber)
        {
            return unitNumber switch
            {
                1 => "feet",
                2 => "meters",
                3 => "kilometers",
                4 => "miles",
                5 => "micrometers",
                6 => "milimitres",
                7 => "nautical miles",
                8 => "centimeters",
                9 => "nanometers",
                10 => "yards",
                11 => "inches",
                _ => "no value",
            };
        }
   }
}
