using System;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day09
    {
        [Test]
        public void PartsExample()
        {
            var input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576".Split(Environment.NewLine).Select(long.Parse).ToArray();
            Assert.AreEqual(127, ExchangeMaskingAdditionSystem.GetFirstInvalidNumber(5, input));
            Assert.AreEqual(62, ExchangeMaskingAdditionSystem.GetEncryptionWeakness(5, input));

        }
        
        [Test]
        public void TestPart1()
        {
            var input = TestUtil
                .GetFileContents("Day9.txt")
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToArray();
            var output = ExchangeMaskingAdditionSystem.GetFirstInvalidNumber(25, input);
            Assert.AreEqual(675280050, output);
        }
        
        [Test]
        public void TestPart2()
        {
            var input = TestUtil
                .GetFileContents("Day9.txt")
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToArray();
            var output = ExchangeMaskingAdditionSystem.GetEncryptionWeakness(25, input);
            Assert.AreEqual(96081673, output);
        }
    }
}