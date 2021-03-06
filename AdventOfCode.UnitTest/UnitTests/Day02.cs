﻿using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.UnitTests
{
    public class Day02
    {
        [Test]
        public void Day02_PartOneTest()
        {
            var lines = new[]
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };
            Assert.AreEqual(2, PasswordPhilosophy.GetValidPasswords(lines.Select(PasswordPolicy.Parse).ToList(), PasswordPhilosophy.RentalPlace.Sleds).Length);
        }

        [Test]
        public void Day02_PartTwoTest()
        {
            var lines = new[]
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };
            Assert.AreEqual(1, PasswordPhilosophy.GetValidPasswords(lines.Select(PasswordPolicy.Parse).ToList(), PasswordPhilosophy.RentalPlace.Tobogan).Length);
        }
    }
}
