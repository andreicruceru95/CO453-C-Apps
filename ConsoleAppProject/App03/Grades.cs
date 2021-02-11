using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// Grade A is First Class   : 70 - 100
    /// Grade B is Upper Second  : 60 - 69
    /// Grade C is Lower Second  : 50 - 59
    /// Grade D is Third Class   : 40 - 49
    /// Grade F is Fail          :  0 - 39
    /// </summary>
    public enum Grades
    {
        [Description("No grade has been assigned yet")]
        [Display(Name ="No Grade has been awarded.")]
        NULL,
        [Description("Not Passed")]
        [Display(Name = "Failed")]
        F, 
        [Description("Third Class")]
        [Display(Name = "Third Class")]
        D, 
        [Description("Lower Second")]
        [Display(Name = "Lower Second")]
        C,
        [Display(Name = "Upper Second")]
        [Description("Upper Second")]
        B, 
        [Description("First Class")]
        [Display(Name = "First Class")]
        A
    }
}
