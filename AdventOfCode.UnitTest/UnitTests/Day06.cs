using System;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.UnitTests
{
    public class Day06
    {
        private string _answers = @"abc

a
b
c

ab
ac

a
a
a
a

b";
        [Test]
        public void PartOneTest()
        {
            var answersFulls=
                _answers.Split(Environment.NewLine + Environment.NewLine)
                    .Select(QuestionCounter.CountYes).ToArray();
            Assert.AreEqual(11, answersFulls.Sum());
        }
        
        [Test]
        public void PartTwoTest()
        {
            var answersFulls=
                _answers.Split(Environment.NewLine + Environment.NewLine)
                    .Select(QuestionCounter.CountUniqueYes).ToArray();
            Assert.AreEqual(6, answersFulls.Sum());
        }
    }
}