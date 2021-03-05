using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This enumeration will provide information about each category.
    /// </summary>
    public enum Categories
    {
        [Description("\t\tThis is not a good sign, no matter what ethnic group or age group you are part of. \n" +
            "There are several ways you can tackle obesity, including diet, excercise, medication or surgery.\n")]
        [Display(Name ="Extremely Obese")]
        E_OBESE,
        [Description("\t\tThe best way to lose weight if you're obese is through a\n" +
            " combination of diet and exercise, and, in some cases, \n" +
            "medicines. See a GP for help and advice. If you are a black, asian or from\n" +
            "any other minority ethnic group(BAME) adult with a BMI of 27.5 or more, you are at increased risk \n" +
            "of developing sole long-term (chronic) conditions, such as type 2 diabetes.\n")]
        [Display(Name = "Obese")]
        OBESE,
        [Description("\t\tThe best way to lose weight if you're overweight \n" +
            "is through a combination of diet and exercise. If you are a black, asian or from\n" +
            "any other minority ethnic group(BAME) adult with a BMI of 23 or more, you are at increased risk \n" +
            "of developing sole long-term (chronic) conditions, such as type 2 diabetes.\n")]
        [Display(Name = "Overweight")]
        OVERWEIGHT,
        [Description("\t\tKeep up the good work!\n")]
        [Display(Name = "Healthy")]
        HEALTHY,
        [Description("\t\tBeing underweight could be a sign you're not eating enough \n" +
            "or you may be ill. If you're underweight, a GP can help.\n")]
        [Display(Name = "Underweight")]
        UNDERWEIGHT
    }
}
