using System.Runtime.Serialization;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day11
    {
        [Test]
        public void Part11Example()
        {
            var input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";
            Assert.AreEqual(37, new SeatCalculator().CalculateTakenSeats(input));
            Assert.AreEqual(26, new SeatCalculator().CalculateTakenSeats(input, true));

        }

        [Test]
        public void Part1()
        {
            var data = TestUtil.GetFileContentsAsString("Day11.txt");
            Assert.AreEqual(2438, new SeatCalculator().CalculateTakenSeats(data));
            Assert.AreEqual(2174, new SeatCalculator().CalculateTakenSeats(data, true));
        }
    }
}