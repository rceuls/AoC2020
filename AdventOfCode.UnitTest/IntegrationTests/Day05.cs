using System;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day05
    {
        private string[] _items;

        [OneTimeSetUp]
        public void Setup()
        {
            _items = TestUtil
                .GetFileContents("Day5.txt")
                .Split(Environment.NewLine);
        }

        [Test]
        public void PartOneTest()
        {
            var max = _items.Select(BoardingPassScanner.CalculateSeatNumber).Max();
            Assert.AreEqual(835, max);
        }
        
        [Test]
        public void PartTwoTest()
        {
            var seats = _items.Select(BoardingPassScanner.CalculateSeatNumber).ToHashSet();
            var max = seats.Max();
            var min = seats.Min();

            var yourSeat = Enumerable.Range(min, max - min + 1).FirstOrDefault(x => !seats.Contains(x));
            Assert.AreEqual(649, yourSeat);
        }
    }
}