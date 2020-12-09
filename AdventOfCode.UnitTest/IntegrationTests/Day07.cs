using System;
using System.IO;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day07
    {
        [Test(Description = "Day01_SampleData")]
        public void Part1Example()
        {
            var input = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

            Assert.AreEqual(4, BagCounter.GetOuterBagCount(input.Split(Environment.NewLine), "shiny gold").Part1);
        }

        [Test(Description = "Day07_PartOneAndTwoTests")]
        public void TestPart1And2()
        {
            var input = TestUtil
                .GetFileContentsAsString("Day7.txt")
                .Split(Environment.NewLine);
            var output = BagCounter.GetOuterBagCount(input, "shiny gold");
            Assert.AreEqual(259, output.Part1);
            Assert.AreEqual(45018, output.Part2);

        }
    }
}