using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public class NumbersGame
    {
        public static ulong GetLastNumber(int[] input, int requestedIndex = 2020)
        {
            var data = input.Select(x => (ulong) x).ToList();
            var counter = input.Length;
            var lastNumber = (ulong)input.LastOrDefault();
            while (counter < requestedIndex)
            {
                var firstIndex = (ulong)data.SkipLast(1).ToList().LastIndexOf(lastNumber) + 1;
                var secondIndex = (ulong)0;
                if (firstIndex != 0)
                {
                    secondIndex = (ulong)data.LastIndexOf(lastNumber) + 1;
                }
                data.Add(secondIndex - firstIndex);
                counter++;
                lastNumber = data.LastOrDefault();
            }

            return data.Last();
        }
        
    }
}