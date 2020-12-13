using System;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day13
    {
        [Test]
        public void Day13_Example01()
        {
            var input = @"939
7,13,x,x,59,x,31,19";
            Assert.AreEqual(295, ShuttleSearch.GetEarliestCalculatedTimestamp(input.Split(Environment.NewLine)));
        }
        
        [Test]
        public void Day13_Example02()
        {
            var input = @"7,13,x,x,59,x,31,19";
            Assert.AreEqual(1068781, ShuttleSearch.GetLastPart(input));
        }
        
        [Test]
        public void Day13_FullTest01()
        {
            var data = TestUtil.GetFileContentsAsString("Day13.txt").Split(Environment.NewLine);
            Assert.AreEqual(3385, ShuttleSearch.GetEarliestCalculatedTimestamp(data));
            Assert.AreEqual(600689120448303, ShuttleSearch.GetLastPart(data[1]));
        }
    }
}