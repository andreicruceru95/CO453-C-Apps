using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Enumeration of distance units that the app can convert.
    /// </summary>
    public enum UnitsEnum
    {
        [Display(Name = "Meter")]
        METER,
        [Display(Name = "Feet")]
        FEET,
        [Display(Name = "Kilometre")]
        KILOMETRE,
        [Display(Name = "Mile")]
        MILE,
        [Display(Name = "Centimeter")]
        CENTIMETER,
        [Display(Name = "Milimetre")]
        MILIMETRE,
        [Display(Name = "Micrometre")]
        MICROMETRES,
        [Display(Name = "Nanometre")]
        NANOMETRE,
        [Display(Name = "Yard")]
        YARD,
        [Display(Name = "Inch")]
        INCH,
        [Display(Name = "Nautical Mile")]
        NAUTICAL_MILE
    }
}
