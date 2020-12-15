using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace AdventOfCode.Services
{
    public class NumbersGame
    {
        public static int GetLastNumber(int[] input, int requestedIndex = 2020)
        {
            var next = 0;
            var memory = new Dictionary<int, int>();
            for (var counter = 1; counter < requestedIndex; counter++)
            {
                var current = input.Length >= counter ? input[counter - 1] : next;
                next = memory.ContainsKey(current) ? counter - memory[current] : 0;
                if (!memory.ContainsKey(current))
                { 
                    memory.Add(current, counter);
                }
                else
                {
                    memory[current] = counter;
                }
            }

            return next;
        }
        
    }
}