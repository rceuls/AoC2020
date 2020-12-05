using System;

namespace AdventOfCode.Services
{
    public static class BoardingPassScanner
    {
        public static int CalculateSeatNumber(string boardingPass)
        {
            var asBin = boardingPass.Replace('F', '0')
                .Replace('L', '0')
                .Replace('B', '1')
                .Replace('R', '1');

            return Convert.ToInt32(asBin, 2);
        }
    }
}