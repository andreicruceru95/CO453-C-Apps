using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using ConsoleAppProject.App03;

namespace AppTests
{
    [TestClass]
    public class StudentApp
    {
        StudentMarks students = new StudentMarks();

        [TestMethod]
        public void CheckIDValid()
        {
            students.CheckID(1);
        }

        [TestMethod]
        public void CheckIDInvalid()
        {
            Assert.AreSame(null, students.CheckID(999));
        }

        [TestMethod]
        public void CheckGradeProfile()
        {
            Assert.AreEqual(students.GetGradeProfile().Item1, 36);
            Assert.AreEqual(students.GetGradeProfile().Item2, 45);
            Assert.AreEqual(students.GetGradeProfile().Item3, 9);
            Assert.AreEqual(students.GetGradeProfile().Item4, 9);
            Assert.AreEqual(students.GetGradeProfile().Item5, 0);
        }
        [TestMethod]
        public void CheckMediumMark()
        {
            Assert.AreEqual(students.GetStatistics().Item1, 69);
        }

        [TestMethod]
        public void CheckMinAndMax()
        {
            Student StudentMin;
            Student StudentMax;
            students.GetMinMax(out StudentMin, out StudentMax);
            Assert.AreEqual(StudentMin.Mark, 45);
            Assert.AreEqual(StudentMax.Mark, 97);

        }
    }
}
