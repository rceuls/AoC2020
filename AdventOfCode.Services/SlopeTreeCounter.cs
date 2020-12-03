using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public class SlopeTreeCounter
    {
        private static char TREE = '#';
        public static long DescendAndCountTrees(string input, int down, int right)
        {
            var lines = input.Split(Environment.NewLine);
            var treeCount = 0;
            for (int x = 0, y = 0; y < lines.Length; y += down, x += right)
            {
                x %= lines[y].Length;
                treeCount += lines[y][x] == TREE ? 1 : 0;
            }
            return treeCount;
        }

        public static long DescendAndCountTreesMultipleSlopes(string input)
        {
            var combos = new List<(int, int)> { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) };
            return combos.Select(x => DescendAndCountTrees(input, x.Item1, x.Item2)).Aggregate((acc, x) => acc * x);
        }
    }
}