using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
namespace AppTests
{
    [TestClass]
    public class UnitTesting
    {
        
        BMI BmiTest = new BMI(); 
        DistanceConverter converter = new DistanceConverter();
        
        [TestMethod]
        public void KmToMeters()
        {
            //converter.Amount = 12;
            //converter.FromValue = UnitsEnum.KILOMETRE;
            //converter.ToValue = UnitsEnum.METER;
            //var correctResult = 12000;

            //Assert.AreEqual(correctResult, converter.GetResult());
        }

        [TestMethod]
        public void KmToMiles()
        {
            //converter.Amount = 19.3121;
            //converter.FromValue = UnitsEnum.KILOMETRE;
            //converter.ToValue = UnitsEnum.MILE;
            //var correctResult = 12;

            //Assert.AreEqual(correctResult, converter.GetResult());
        }     

    }
}
