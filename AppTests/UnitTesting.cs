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
        public void MetricUnderweightLow()
        {
            BmiTest.Weight = 46;
            BmiTest.Height = 157;
            var correctResult = 18;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricUnderweightHigh()
        {
            BmiTest.Weight = 68;
            BmiTest.Height = 193;
            var correctResult = 18;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricNormalLow()
        {
            BmiTest.Weight = 45;
            BmiTest.Height = 152;
            var correctResult = 19;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricNormalHigh()
        {
            BmiTest.Weight = 57;
            BmiTest.Height = 155;
            var correctResult = 23;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricOverweightLow()
        {
            BmiTest.Weight = 57;
            BmiTest.Height = 152;
            var correctResult = 24;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricOverweightHigh()
        {
            BmiTest.Weight = 70;
            BmiTest.Height = 152;
            var correctResult = 30;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricObeseLow()
        {
            BmiTest.Weight = 73;
            BmiTest.Height = 152;
            var correctResult = 31;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricObeseHigh()
        {
            BmiTest.Weight = 91;
            BmiTest.Height = 152;
            var correctResult = 39;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricExtremelyObeseLow()
        {
            BmiTest.Weight = 93;
            BmiTest.Height = 152;
            var correctResult = 40;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void MetricExtremelyObeseHigh()
        {
            BmiTest.Weight = 98;
            BmiTest.Height = 152;
            var correctResult = 42;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(true));
        }
        [TestMethod]
        public void ImperialUnderweightLow()
        {
            BmiTest.WeightInPounds = 100;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 2;
            var correctResult = 18;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialUnderweightHigh()
        {
            BmiTest.WeightInPounds = 150;
            BmiTest.HeightInFeet = 6;
            BmiTest.HeightInInches = 4;
            var correctResult = 18;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialNormalLow()
        {
            BmiTest.WeightInPounds = 100;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 19;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialNormalHigh()
        {
            BmiTest.WeightInPounds = 120;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 23;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialOverweightLow()
        {
            BmiTest.WeightInPounds = 125;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 24;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialOverweightHigh()
        {
            BmiTest.WeightInPounds = 155;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 30;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialObeseLow()
        {
            BmiTest.WeightInPounds = 160;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 31;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialObeseHigh()
        {
            BmiTest.WeightInPounds = 200;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 39;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialExtremelyObeseLow()
        {
            BmiTest.WeightInPounds = 205;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 40;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }
        [TestMethod]
        public void ImperialExtremelyObeseHigh()
        {
            BmiTest.WeightInPounds = 215;
            BmiTest.HeightInFeet = 5;
            BmiTest.HeightInInches = 0;
            var correctResult = 42;
            Assert.AreEqual(correctResult, BmiTest.CalculateBmi(false));
        }


    }
}
