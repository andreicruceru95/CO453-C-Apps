using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
namespace AppTests
{
    [TestClass]
    public class UnitTesting
    {
        
        BMI BmiTest = new BMI();
        [TestMethod]
        public void TestDistanceConverter()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.Amount = 12;
            converter.FromValue = UnitsEnum.KILOMETRE;
            converter.ToValue = UnitsEnum.METER;
            var correctResult = 12000;

            Assert.AreEqual(correctResult, converter.GetResult());
        }
       
    }
}
