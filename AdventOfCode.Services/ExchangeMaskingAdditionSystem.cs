using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public static class ExchangeMaskingAdditionSystem
    {
        private static long GetFirstInvalidNumber(int preambleSize, long[] data)
        {
            for (var x = 0; x < data.Length; x++)
            {
                var targetResult = data[preambleSize + x];
                var subset = data.Skip(x).Take(preambleSize).ToArray();
                if (subset.Any(v => subset.Contains(targetResult - v)))
                {
                    continue;
                }

                return targetResult;
            }

            return -1;
        }
        
        public static (long WeakNumber, long Weakness) GetEncryptionWeakness(int preambleSize, long[] data)
        {
            var weakNumber = GetFirstInvalidNumber(preambleSize, data);
            while (data.Length > 0)
            {
                var toCheck = new List<long>();
                foreach (var number in data)
                {
                    toCheck.Add(number);
                    var sum = toCheck.Sum();
                    if (sum == weakNumber)
                    {
                        return (weakNumber, toCheck.Min() + toCheck.Max());
                    }
                    if (sum > weakNumber)
                    {
                        break;
                    }
                }

                data = data.Skip(1).ToArray();
            }

            throw new Exception("Did not converge.");
        }
    }
}