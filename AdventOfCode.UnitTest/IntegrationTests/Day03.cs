using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day03
    {
        private string[] _items;

        [OneTimeSetUp]
        public void Setup()
        {
            _items = TestUtil
                .GetFileContentsAsString("Day3.txt")
                .Split(Environment.NewLine);
        }
        
        [Test(Description = "Day03_PartOneTest")]
        public void Day03_PartOneTest()
        {
            Assert.AreEqual(156, SlopeTreeCounter.DescendAndCountTrees(_items, 1, 3));
        }
        
        [Test(Description = "Day03_PartTwoTest")]
        public void Day03_PartTwoTest()
        {
            var combos = new List<(int, int)> { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) };
            Assert.AreEqual(3521829480,SlopeTreeCounter.DescendAndCountTreesMultipleSlopes(_items, combos));
        }
    }
}