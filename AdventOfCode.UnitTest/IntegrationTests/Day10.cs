using System;
using System.Linq;
using AdventOfCode.Services;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day10
    {
        [Test(Description = "Day10_PartOneExampleTest")]
        public void Day10_Example01()
        {
            var input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
            var calculated = JoltCalculator.DifferenceCount(input.Split(Environment.NewLine).Select(int.Parse));
            Assert.AreEqual(calculated, 22 * 10);
        }
        
        [Test(Description = "Day10_PartOneExampleTestTwo")]
        public void Day10_Example02()
        {
            var raw = @"16
10
15
5
1
11
7
19
6
12
4";
            var input = raw.Split(Environment.NewLine).Select(int.Parse).ToArray();
            var calculated = JoltCalculator.DifferenceCount(input);
            Assert.AreEqual(calculated, 7 * 5);
            Assert.AreEqual(8L, JoltCalculator.UniqueCombinations(input));
        }
        
        [Test(Description = "Day10_PartOne")]
        public void Day10_Part1()
        {
            var input = TestUtil.GetFileContentsAsInts("Day10.txt");
            Assert.AreEqual(2760, JoltCalculator.DifferenceCount(input));
        }
        
        [Test(Description = "Day10_PartTwo")]
        public void Day10_Part2()
        {
            var input = TestUtil.GetFileContentsAsInts("Day10.txt");
            Assert.AreEqual(13816758796288, JoltCalculator.UniqueCombinations(input));
        }
    }
}