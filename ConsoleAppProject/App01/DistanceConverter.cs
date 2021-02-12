using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.FEET),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.METER),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.KILOMETRE),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.MILE),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.MICROMETRES),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.MILIMETRE),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.NAUTICAL_MILE),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.CENTIMETER),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.NANOMETRE),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.YARD),
            EnumHelper<UnitsEnum>.GetName(UnitsEnum.INCH)
        };
        
        [BindProperty]
        public double Amount { get; set; }
        [BindProperty]
        public UnitsEnum FromValue { get; set; }
        [BindProperty]
        public UnitsEnum ToValue { get; set; }
        [BindProperty]
        public double Result { get; set; } = 0;
        
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

        //Calculate and return the result.
        public double GetResult()
        {
            return Math.Round((Values[FromValue] / Values[ToValue] * Amount), NUMBER_OF_DECIMALS);
        }

        /// <summary>
        /// Run the program in steps.
        /// </summary>
        public void RunDistanceConverter()
        {
            GetValues();
            Console.WriteLine($"\t{Amount} {EnumHelper<UnitsEnum>.GetName(FromValue)} " +
                $"translates to {GetResult()} {EnumHelper<UnitsEnum>.GetName(ToValue)}");
        }

        /// <summary>
        /// Values.ElementAt(index).key returns the key associated to the index number that the
        /// user will chose.
        /// </summary>
        public void GetValues()
        {
            FromValue= Values.ElementAt(ConsoleHelper.SelectChoice("Select your FROM unit from the list:", Units) - 1).Key;
            ToValue = Values.ElementAt(ConsoleHelper.SelectChoice("Select your TO unit from the list:", Units) - 1).Key;
            Amount = ConsoleHelper.InputNumber("Please enter an amount > ");
        }
   }
}
