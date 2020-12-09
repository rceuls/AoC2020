using System;
using System.IO;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day04
    {
        private string _items;

        [OneTimeSetUp]
        public void Setup()
        {
            _items = TestUtil
                .GetFileContentsAsString("Day4.txt");
        }
        
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(250, PassportValidator.ValidPassportCountSimple(_items));
        }
        
        [Test]
        public void PartTwoTest()
        {
            Assert.AreEqual(158, PassportValidator.ValidPassportCountComplex(_items));
        }
    }
}