using System;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
using AdventOfCode.Services.Model;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day02
    {
        private PasswordPolicy[] _input;

        [OneTimeSetUp]
        public void Setup()
        {
            _input = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "IntegrationTests", "Input", "Day2.txt"))
                .Select(PasswordPolicy.Parse).ToArray();
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