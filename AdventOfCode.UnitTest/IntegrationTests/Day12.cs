using System;
using System.IO;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day12
    {
        [Test]
        public void Day12_Example01()
        {
            var input = @"F10
N3
F7
R90
F11";
            Assert.AreEqual(25, RainRisk.CalculateDistance(input.Split(Environment.NewLine)));
        }
        
        [Test]
        public void Day12_Example02()
        {
            var input = @"F10
N3
F7
R90
F11";
            Assert.AreEqual(286, RainRisk.CalculateDistanceWithWaypoint(input.Split(Environment.NewLine)));
        }

        [Test]
        public void Day12_CompassPositions()
        {
            Assert.AreEqual('S', RainRisk.GetCompassPosition('S', 0, true));
            Assert.AreEqual('W', RainRisk.GetCompassPosition('S', 90, true));
            Assert.AreEqual('N', RainRisk.GetCompassPosition('S', 180, true));
            Assert.AreEqual('E', RainRisk.GetCompassPosition('S', 270, true));
            Assert.AreEqual('S', RainRisk.GetCompassPosition('S', 360, true));
            
            Assert.AreEqual('S', RainRisk.GetCompassPosition('S', 0, false));
            Assert.AreEqual('E', RainRisk.GetCompassPosition('S', 90, false));
            Assert.AreEqual('N', RainRisk.GetCompassPosition('S', 180, false));
            Assert.AreEqual('W', RainRisk.GetCompassPosition('S', 270, false));
            Assert.AreEqual('S', RainRisk.GetCompassPosition('S', 360, false));
        }
        
        [Test]
        public void Day12_FullTest01()
        {
            var data = TestUtil.GetFileContentsAsString("Day12.txt").Split(Environment.NewLine);
            Assert.AreEqual(938, RainRisk.CalculateDistance(data));
            Assert.AreEqual(54404, RainRisk.CalculateDistanceWithWaypoint(data));
        }
    }
}