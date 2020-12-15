using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day15
    {
        [Test]
        public void TestExample01()
        {
            var data = "0,3,6".Split(",").Select(int.Parse).ToArray();
            Assert.AreEqual(436, NumbersGame.GetLastNumber(data));
        }
        
        [Test]
        public void TestExample02()
        {
            var data = "1,3,2".Split(",").Select(int.Parse).ToArray();
            Assert.AreEqual(1, NumbersGame.GetLastNumber(data));
        }
        
        [Test]
        public void TestExample03()
        {
            var data = "2,1,3".Split(",").Select(int.Parse).ToArray();
            Assert.AreEqual(10, NumbersGame.GetLastNumber(data));
        }
        
        [Test]
        public void TestExample04()
        {
            var data = "1,2,3".Split(",").Select(int.Parse).ToArray();
            Assert.AreEqual(27, NumbersGame.GetLastNumber(data));
        }

        [Test]
        public void TestFullPart01()
        {
            var data = "0,20,7,16,1,18,15".Split(",").Select(int.Parse).ToArray();
            Assert.AreEqual(1025, NumbersGame.GetLastNumber(data));
        }
        
        
        [Test]
        public void TestFullPart02()
        {
            var data = "0,20,7,16,1,18,15".Split(",").Select(int.Parse).ToArray();
            Assert.AreEqual(129262, NumbersGame.GetLastNumber(data, 30_000_000));
        }
    }
}