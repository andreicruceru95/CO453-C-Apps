using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
        public Dictionary<UnitsEnum, double> Values = new Dictionary<UnitsEnum, double>();
        public string[] Units = new string[]
        {
        "Feet", "Meter", "Kilometer", "Mile", "Micrometer", "Milimeter",
        "Nautical Mile", "Centimeter", "Nanometer", "Yard", "Inch"
        };
        public double[] ConvertedUnits = new double[]
        {
            0.000189394, 0.000621371, 0.621371, 1, 6.2137e-10, 6.2137e-7,
            1.15078, 6.2137e-6, 6.2137e-13, 0.000568182, 1.5783e-5
        };
        [BindProperty]
        public double Amount { get; set; }
        [BindProperty]
        public UnitsEnum FromValue { get; set; } = UnitsEnum.MILE;
        [BindProperty]
        public UnitsEnum ToValue { get; set; } = UnitsEnum.MILE;
        [BindProperty]
        public double Result { get; set; } = 0;

        public int FromValueInt { get; set; }
        public int ToValueInt { get; set; }
        
        public DistanceConverter()
        {
            Values.Add(UnitsEnum.FEET, 0.000189394);
            Values.Add(UnitsEnum.METER, 0.000621371);
            Values.Add(UnitsEnum.KILOMETRE, 0.621371);
            Values.Add(UnitsEnum.CENTIMETER, 6.2137e-6);
            Values.Add(UnitsEnum.MILIMETRE, 6.2137e-7);
            Values.Add(UnitsEnum.MICROMETRES, 6.2137e-10);
            Values.Add(UnitsEnum.NANOMETRE, 6.2137e-13);
            Values.Add(UnitsEnum.YARD, 0.000568182);
            Values.Add(UnitsEnum.INCH, 1.5783e-5);
            Values.Add(UnitsEnum.NAUTICAL_MILE, 1.15078);
            Values.Add(UnitsEnum.MILE, 1);
        }
        /// <summary>
        /// On form submit this method will be called.
        /// The method does not return anything, but in exchange will calculate the result,
        /// that is displayed on the screen.
        /// </summary>
        public void OnPost()
        {
           
        }

        public double GetResult()
        {
            return Math.Round((ConvertUnit(FromValue) / ConvertUnit(ToValue) * Amount), NUMBER_OF_DECIMALS);
        }

        /// <summary>
        /// Return the covnversion in miles of an input value.
        /// </summary>
        /// <param name="choice">The value to be converted.</param>
        /// <returns>Return a value converted</returns>
        public double ConvertUnit(UnitsEnum choice)
        {
           return Values[choice];
        }

        /// <summary>
        /// Run the program in steps.
        /// </summary>
        public void RunDistanceConverter()
        {
            GetValues();
            CalculateResult();

            Console.WriteLine("\t" + Amount + " " + TranslateUnit(FromValueInt) +
                            " translates to " + Math.Round(Result, NUMBER_OF_DECIMALS) + " " + TranslateUnit(ToValueInt));
        }

        /// <summary>
        /// Get input value from the user
        /// </summary>
        public void GetValues()
        {
            FromValueInt = ConsoleHelper.SelectChoice("Select your unit from the list:", Units);
            ToValueInt = ConsoleHelper.SelectChoice("Select your unit from the list:", Units);
            Amount = ConsoleHelper.InputNumber("Please enter an amount > ");
        }

        /// <summary>
        /// Calculate the result
        /// </summary>
        public void CalculateResult()
        {
            Result = (ConvertUnit(FromValueInt) / ConvertUnit(ToValueInt)) * Amount;
        }

        /// <summary>
        /// Return the value of each unit in miles.
        /// </summary>
        /// <param name="choice">Represents the user's input.</param>
        /// <returns>Return the value of the input in miles.</returns>
        public double ConvertUnit(int choice)
        {
            return Convert.ToDouble(ConvertedUnits.GetValue(choice - 1));
        }

        /// <summary>
        /// Translate the unit from int data type to string data type.
        /// </summary>
        /// <param name="unitNumber">The input integer of the user.</param>
        /// <returns>The respresentation of the integer in String type.</returns>
        public string TranslateUnit(int unitNumber)
        {
            return Units.GetValue(unitNumber - 1).ToString();
        }
   }
}
