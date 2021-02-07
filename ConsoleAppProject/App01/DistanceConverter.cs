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
        public double ConvertUnit(UnitsEnum choice)
        {
            switch (choice)
            {
                case UnitsEnum.FEET:
                    return FEET_IN_MILES;

                case UnitsEnum.METER:
                    return METER_IN_MILES;

                case UnitsEnum.KILOMETRE:
                    return KILOMETRE_IN_MILES;

                case UnitsEnum.MILE:
                    return 1;

                case UnitsEnum.CENTIMETER:
                    return CENTIMETER_IN_MILES;

                case UnitsEnum.MILIMETRE:
                    return MILIMETRE_IN_MILES;

                case UnitsEnum.NANOMETRE:
                    return NANOMETRE_IN_MILES;

                case UnitsEnum.YARD:
                    return YARD_IN_MILES;

                case UnitsEnum.INCH:
                    return INCH_IN_MILES;

                case UnitsEnum.NAUTICAL_MILE:
                    return NAUTICAL_MILE_IN_MILES;

                default:
                    return 1;
            }
        }

        /// <summary>
        /// Run the program in steps.
        /// </summary>
        public void RunDistanceConverter()
        {
            int valueToBeConverted = Math.Abs(SelectMainUnit());
            int valueToConvertTo = Math.Abs(SelectConversionUnit());
            double amount = Math.Abs(ReadAmount());

            double result =(ConvertUnit(valueToBeConverted) / ConvertUnit(valueToConvertTo)) * amount;

            Console.Clear();
            
            Console.Beep();

            Console.WriteLine("\t" + amount + " " + TranslateUnit(valueToBeConverted)  +
                            " translates to " + Math.Round(result, NUMBER_OF_DECIMALS) + " " + TranslateUnit(valueToConvertTo));

        }        
        /// <summary>
        /// Ask the user for an unit input.
        /// </summary>        
        private int SelectMainUnit()
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
                    return METER_IN_MILES;
                case 3:
                    return KILOMETRE_IN_MILES;
                case 4:
                    return 1;
                case 5:
                    return MICROMETRE_IN_MILES;
                case 6:
                    return MILIMETRE_IN_MILES;
                case 7:
                    return NAUTICAL_MILE_IN_MILES;
                case 8:
                    return CENTIMETER_IN_MILES;
                case 9:
                    return NANOMETRE_IN_MILES;
                case 10:
                    return YARD_IN_MILES;
                case 11:
                    return INCH_IN_MILES;
                default:
                    return 1;
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
                case 5:
                    return "micrometers";
                case 6:
                    return "milimitres";
                case 7:
                    return "nautical miles";
                case 8:
                    return "centimeters";
                case 9:
                    return "nanometers";
                case 10:
                    return "yards";
                case 11:
                    return "inches";
                default:
                    return "no value";
            }
        }

        
   }
}
