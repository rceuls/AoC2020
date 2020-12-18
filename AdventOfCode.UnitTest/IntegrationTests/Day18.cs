using System;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day18
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(71, OperationOrder.CalculateLineForPartOne("1 + 2 * 3 + 4 * 5 + 6"));
            Assert.AreEqual(51, OperationOrder.CalculateLineForPartOne("1 + (2 * 3) + (4 * (5 + 6))"));
            Assert.AreEqual(26, OperationOrder.CalculateLineForPartOne("2 * 3 + (4 * 5)"));
            Assert.AreEqual(437, OperationOrder.CalculateLineForPartOne("5 + (8 * 3 + 9 + 3 * 4 * 3)"));
            Assert.AreEqual(12240, OperationOrder.CalculateLineForPartOne("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))"));
            Assert.AreEqual(13632, OperationOrder.CalculateLineForPartOne("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2"));
        }
        
        [Test]
        public void TestPart1_Full()
        {
            var data = TestUtil.GetFileContentsAsString("Day18.txt").Split(Environment.NewLine);
            var sum = data.Select(OperationOrder.CalculateLineForPartOne).Sum();
            Assert.AreEqual(8929569623593, sum);
        }
        
        [Test]
        public void TestPart2_Full()
        {
            var data = TestUtil.GetFileContentsAsString("Day18.txt").Split(Environment.NewLine);
            var sum = data.Select(OperationOrder.CalculateLineForPartTwo).Sum();
            Assert.AreEqual(231235959382961, sum);
        }
    }
}