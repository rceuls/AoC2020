using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.UnitTests
{
    public class Day01
    {
        [Test]
        public void Day01_PartOneTest()
        {
            var data = new[] { 1721, 979, 366, 299, 675, 1456 };
            var result = ExpenseReportCalculator.CreateExpenseReport(data, ExpenseReportCalculator.ExpenseNumberCount.Two);
            Assert.AreEqual(514579, result);
        }

        [Test]
        public void Day01_PartTwoTest()
        {
            var data = new[] { 1721, 979, 366, 299, 675, 1456 };
            var result = ExpenseReportCalculator.CreateExpenseReport(data, ExpenseReportCalculator.ExpenseNumberCount.Three);
            Assert.AreEqual(241861950, result);
        }
    }
}