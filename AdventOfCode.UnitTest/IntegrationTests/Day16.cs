using System;
using System.Linq;
using AdventOfCode.Services;
using NUnit.Framework;

namespace AdventOfCode.UnitTest.IntegrationTests
{
    public class Day16
    {
        [Test]
        public void TestExample01()
        {
            var data = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";
            Assert.AreEqual(71, TicketTranslation.GetTicketScanningErrorRate(data.Split(Environment.NewLine + Environment.NewLine).Select(x => x.Split(Environment.NewLine).ToList()).ToList()));
        }
        
        [Test]
        public void TestPart01()
        {
            var data = TestUtil.GetFileContentsAsString("Day16.txt");
            Assert.AreEqual(18227, TicketTranslation.GetTicketScanningErrorRate(data.Split(Environment.NewLine + Environment.NewLine).Select(x => x.Split(Environment.NewLine).ToList()).ToList()));
        }
        
        [Test]
        public void TestPart02()
        {
            var data = TestUtil.GetFileContentsAsString("Day16.txt");
            Assert.AreEqual(2355350878831, TicketTranslation.GetTicketDepartureFieldCount(data.Split(Environment.NewLine + Environment.NewLine).Select(x => x.Split(Environment.NewLine).ToList()).ToList()));
        }
    }
}