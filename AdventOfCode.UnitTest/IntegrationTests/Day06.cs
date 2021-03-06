using System;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day06
    {
        private string _items;

        [OneTimeSetUp]
        public void Setup()
        {
            _items = TestUtil
                .GetFileContentsAsString("Day6.txt");
        }

        [Test(Description = "Day06_PartOneTest")]
        public void Day06_Full()
        {
            var answersFulls=
                _items.Split(Environment.NewLine + Environment.NewLine)
                    .Select(QuestionCounter.CountYes).ToArray();
            Assert.AreEqual(6782, answersFulls.Sum());
        }
        
        [Test(Description = "Day06_PartTwoTest")]
        public void Day06_Full_02()
        {
            var answersFulls=
                _items.Split(Environment.NewLine + Environment.NewLine)
                    .Select(QuestionCounter.CountUniqueYes).ToArray();
            Assert.AreEqual(3596, answersFulls.Sum());
        }

        [Test(Description = "Day06_PartValeskaTest")]
        public void Day06_Valeska()
        {
            var input = @"abcdefgh
a
aaaa
a

abc
bca
bbc

a

ab
abamkqbsfsidhf

cccc
ccccc
cccc

c
c
cccc
a";
            var answersFulls=
                input.Split(Environment.NewLine + Environment.NewLine)
                    .Select(QuestionCounter.CountUniqueYes).ToArray();
            Assert.AreEqual(7, answersFulls.Sum());
        }
    }
}