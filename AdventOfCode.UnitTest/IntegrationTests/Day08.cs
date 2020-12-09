using System;
using System.IO;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day08
    {
        [Test]
        public void Part1Example()
        {
            var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
            Assert.AreEqual(5, GameConsole.GetLastValueBeforeInfiniteLoop(input.Split(Environment.NewLine)));          
        }
        
        [Test]
        public void Part2Example()
        {
            var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
            Assert.AreEqual(8, GameConsole.GetValue(input.Split(Environment.NewLine)));          
        }
        
        [Test]
        public void TestPart1()
        {
            var input = TestUtil
                .GetFileContentsAsString("Day8.txt")
                .Split(Environment.NewLine);
            var output = GameConsole.GetLastValueBeforeInfiniteLoop(input);
            Assert.AreEqual(1563, output);
        }
        
        [Test]
        public void TestPart2()
        {
            var input = TestUtil
                .GetFileContentsAsString("Day8.txt")
                .Split(Environment.NewLine);
            var output = GameConsole.GetValue(input);
            // 2604 == too high
            Assert.AreEqual(767, output);
        }
    }
}