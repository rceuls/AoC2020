using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day17
    {
        [Test]
        public void Part1Example()
        {
            var input = @".#.
..#
###";
            Assert.AreEqual(112, ConwayRecordCalculator.GetActiveCubes(6, input));
        }
        
        [Test]
        [Ignore("Takes three minutes")]
        public void Part2Example()
        {
            var input = @".#.
..#
###";
            Assert.AreEqual(848, new ConwayRecordHyperCubeCalculator().GetActiveCubes(6, input));
        }

        
        [Test]
        public void Part1()
        {
            var input = TestUtil.GetFileContentsAsString("Day17.txt");
            Assert.AreEqual(298, ConwayRecordCalculator.GetActiveCubes(6, input));
        }
        
        [Test]
        [Ignore("Takes ten minutes")]
        public void Part2()
        {
            var input = TestUtil.GetFileContentsAsString("Day17.txt");
            Assert.AreEqual(1792, new ConwayRecordHyperCubeCalculator().GetActiveCubes(6, input));
        }
    }
}