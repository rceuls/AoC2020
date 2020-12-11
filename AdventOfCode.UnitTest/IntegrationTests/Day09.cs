using System;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day09
    {
        [Test(Description = "Day09_ExampleUnitTest")]
        public void Day09_Example()
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
            var (weakNumber, weakness) = ExchangeMaskingAdditionSystem.GetEncryptionWeakness(5, input);
            Assert.AreEqual(127, weakNumber);
            Assert.AreEqual(62, weakness);

        }
        
        [Test(Description = "Day09_PartFullTest")]
        public void Day09_Full()
        {
            var input = TestUtil.GetFileContentsAsLongs("Day9.txt");
            var (weakNumber, weakness) = ExchangeMaskingAdditionSystem.GetEncryptionWeakness(25, input);
            Assert.AreEqual(675280050, weakNumber);
            Assert.AreEqual(96081673, weakness);
        }
    }
}