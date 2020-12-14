using System;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day14
    {
        [Test]
        public void Day14_Example01()
        {
            var input = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";
            Assert.AreEqual(165, DockingData.Part1(input.Split(Environment.NewLine)));
        }
        
        [Test]
        public void Day14_Example02()
        {
            var input = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";
            Assert.AreEqual(208, DockingData.Part2(input.Split(Environment.NewLine)));
        }
        
        [Test]
        public void Day13_FullTest01()
        {
            var data = TestUtil.GetFileContentsAsString("Day14.txt").Split(Environment.NewLine);
            Assert.AreEqual(14862056079561, DockingData.Part1(data));
        }
        
        [Test]
        public void Day13_FullTest02()
        {
            var data = TestUtil.GetFileContentsAsString("Day14.txt").Split(Environment.NewLine);
            Assert.AreEqual(3296185383161, DockingData.Part2(data));
        }
    }
}