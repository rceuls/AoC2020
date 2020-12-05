using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.UnitTests
{
    public class Day05
    {
        [Test]
        public void PartOneTest()
        {
            Assert.AreEqual(357, BoardingPassScanner.CalculateSeatNumber("FBFBBFFRLR"));
            Assert.AreEqual(567, BoardingPassScanner.CalculateSeatNumber("BFFFBBFRRR"));
            Assert.AreEqual(119, BoardingPassScanner.CalculateSeatNumber("FFFBBBFRRR"));
            Assert.AreEqual(820, BoardingPassScanner.CalculateSeatNumber("BBFFBBFRLL"));
        }
    }
}