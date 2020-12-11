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
                .GetFileContentsAsString("Day2.txt")
                .Split(Environment.NewLine)
                .Select(PasswordPolicy.Parse)
                .ToArray();
        }
        
        [Test(Description = "Day02_PartOneTest")]
        public void Day02_PartOneTest()
        {
            Assert.AreEqual(416, PasswordPhilosophy.GetValidPasswords(_input, PasswordPhilosophy.RentalPlace.Sleds).Length);
        }
        
        [Test(Description = "Day02_PartTwoTest")]
        public void Day02_PartTwoTest()
        {
            Assert.AreEqual(688,PasswordPhilosophy.GetValidPasswords(_input, PasswordPhilosophy.RentalPlace.Tobogan).Length);
        }
    }
}