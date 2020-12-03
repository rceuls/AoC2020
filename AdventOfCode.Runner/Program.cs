using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Services;

namespace AdventOfCode.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Input", "Input.txt"));

            Console.WriteLine(SlopeTreeCounter.DescendAndCountTrees(items, 1, 3));
            var combos = new List<(int, int)> { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) };
            Console.WriteLine(SlopeTreeCounter.DescendAndCountTreesMultipleSlopes(items, combos));
        }
    }
}
