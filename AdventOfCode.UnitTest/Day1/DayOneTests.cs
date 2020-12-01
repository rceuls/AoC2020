using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.Day1
{
    public class DayOneTests
    {
        [Test]
        public void PartOneTest()
        {
            var data = new [] { 1721, 979, 366,  299, 675,1456 };
            var result = ExpenseReportCalculator.CreateExpenseReport(data, ExpenseReportCalculator.ExpenseNumberCount.Two);
            Assert.AreEqual(514579, result);
        }

        [Test]
        public void PartTwoTest()
        {
            var data = new [] { 1721, 979, 366,  299, 675,1456 };
            var result = ExpenseReportCalculator.CreateExpenseReport(data, ExpenseReportCalculator.ExpenseNumberCount.Three);
            Assert.AreEqual(241861950, result);
        }
    }
}