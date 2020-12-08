using System;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day02
    {
        private PasswordPolicy[] _input;

        [OneTimeSetUp]
        public void Setup()
        {
            _input = TestUtil
                .GetFileContents("Day2.txt")
                .Split(Environment.NewLine)
                .Select(PasswordPolicy.Parse)
                .ToArray();
        }
        
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(416, PasswordPhilosophy.GetValidPasswords(_input, PasswordPhilosophy.RentalPlace.Sleds).Length);
        }
        
        [Test]
        public void PartTwoTest()
        {
            Assert.AreEqual(688,PasswordPhilosophy.GetValidPasswords(_input, PasswordPhilosophy.RentalPlace.Tobogan).Length);
        }
    }
}