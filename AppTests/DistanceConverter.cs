using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;
namespace AppTests
{
    [TestClass]
    public class DistanceConverterTest
    {
        DistanceConverter converter = new DistanceConverter();

        [TestMethod]
        public void EnumToDouble()
        {
            converter.ConvertUnit(UnitsEnum.CENTIMETER);
            converter.ConvertUnit(UnitsEnum.METER);
            converter.ConvertUnit(UnitsEnum.KILOMETRE);
            converter.ConvertUnit(UnitsEnum.MILE);
            converter.ConvertUnit(UnitsEnum.MICROMETRES);
            converter.ConvertUnit(UnitsEnum.MILIMETRE);
            converter.ConvertUnit(UnitsEnum.YARD);
            converter.ConvertUnit(UnitsEnum.FEET);
        }
        [TestMethod]
        public void IntToDouble()
        {
            converter.ConvertUnit(1);
            converter.ConvertUnit(2);
            converter.ConvertUnit(3);
            converter.ConvertUnit(4);
            converter.ConvertUnit(5);
            converter.ConvertUnit(6);
            converter.ConvertUnit(7);
            converter.ConvertUnit(8);
            converter.ConvertUnit(9);
        }
        [TestMethod]
        public void IntToString()
        {
            converter.TranslateUnit(1);
            converter.TranslateUnit(2);
            converter.TranslateUnit(3);
            converter.TranslateUnit(4);
            converter.TranslateUnit(5);
            converter.TranslateUnit(6);
            converter.TranslateUnit(7);
            converter.TranslateUnit(8);

        }
        [TestMethod]
        public void GetResult()
        {
            converter.FromValueInt = 2;
            converter.ToValueInt = 5;
            converter.Amount = 12;
            converter.CalculateResult();
            converter.FromValueInt = 5;
            converter.ToValueInt = 3;
            converter.Amount = 15;
            converter.CalculateResult();
            converter.FromValueInt = 9;
            converter.ToValueInt = 2;
            converter.Amount = 7;
            converter.CalculateResult();
        }
    }
}
