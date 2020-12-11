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
                .GetFileContentsAsString("Day5.txt")
                .Split(Environment.NewLine);
        }

        [Test(Description = "Day05_PartOneTest")]
        public void Day05_Part01()
        {
            var max = _items.Select(BoardingPassScanner.CalculateSeatNumber).Max();
            Assert.AreEqual(835, max);
        }
        
        [Test(Description = "Day05_PartTwoTest")]
        public void Day05_Part02()
        {
            var seats = _items.Select(BoardingPassScanner.CalculateSeatNumber).ToHashSet();
            var max = seats.Max();
            var min = seats.Min();

            var yourSeat = Enumerable.Range(min, max - min + 1).FirstOrDefault(x => !seats.Contains(x));
            Assert.AreEqual(649, yourSeat);
        }
    }
}