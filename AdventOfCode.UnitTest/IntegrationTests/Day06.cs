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

        [Test]
        public void PartOneTest()
        {
            var answersFulls=
                _items.Split(Environment.NewLine + Environment.NewLine)
                    .Select(QuestionCounter.CountYes).ToArray();
            Assert.AreEqual(6782, answersFulls.Sum());
        }
        
        [Test]
        public void PartTwoTest()
        {
            var answersFulls=
                _items.Split(Environment.NewLine + Environment.NewLine)
                    .Select(QuestionCounter.CountUniqueYes).ToArray();
            Assert.AreEqual(3596, answersFulls.Sum());
        }

        [Test]
        public void PartValeska()
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