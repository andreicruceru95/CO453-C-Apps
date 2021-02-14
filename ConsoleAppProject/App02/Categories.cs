using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace ConsoleAppProject.App02
{
    public enum Categories
    {
        [Description("This is not a good sign, no matter what ethnic group or age group you are part of. " +
            "There are several ways you can tackle obesity, including diet, excercise, medication or surgery.")]
        [Display(Name ="Extremely Obese")]
        E_OBESE,
        [Description("The best way to lose weight if you're obese is through a" +
            " combination of diet and exercise, and, in some cases, " +
            "medicines. See a GP for help and advice. If you are a black, asian or from" +
            "any other minority ethnic group(BAME) adult with a BMI of 27.5 or more, you are at increased risk " +
            "of developing sole long-term (chronic) conditions, such as type 2 diabetes.")]
        [Display(Name = "Obese")]
        OBESE,
        [Description("The best way to lose weight if you're overweight " +
            "is through a combination of diet and exercise. If you are a black, asian or from" +
            "any other minority ethnic group(BAME) adult with a BMI of 23 or more, you are at increased risk " +
            "of developing sole long-term (chronic) conditions, such as type 2 diabetes.")]
        [Display(Name = "Overweight")]
        OVERWEIGHT,
        [Description("Keep up the good work!")]
        [Display(Name = "Healthy")]
        HEALTHY,
        [Description("Being underweight could be a sign you're not eating enough " +
            "or you may be ill. If you're underweight, a GP can help.")]
        [Display(Name = "Underweight")]
        UNDERWEIGHT
    }
}
