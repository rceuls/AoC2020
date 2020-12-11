using System;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day01
    {
        private int[] _input;

        [OneTimeSetUp]
        public void Setup()
        {
            _input = TestUtil
                .GetFileContentsAsString("Day1.txt")
                .Split(Environment.NewLine)
                .Select(int.Parse)
                .ToArray();
        }
        
        [Test(Description = "Day01_PartOneTest")]
        public void Day01_PartOneTest()
        {
            Assert.AreEqual(712075, 
                ExpenseReportCalculator.CreateExpenseReport(_input, ExpenseReportCalculator.ExpenseNumberCount.Two));
        }
        
        [Test(Description = "Day01_PartTwoTest")]
        public void Day01_PartTwoTest()
        {
            Assert.AreEqual(145245270,
                ExpenseReportCalculator.CreateExpenseReport(_input, ExpenseReportCalculator.ExpenseNumberCount.Three));
        }
    }
}