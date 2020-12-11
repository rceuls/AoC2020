using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public class SeatCalculator
    {
        private const char OCCUPIED = '#';
        private const char EMPTY = 'L';
        private const char FLOOR = '.';
        private readonly Dictionary<int, Dictionary<int, HashSet<(int Row, int Col)>>> _xyNeededPositions;

        public SeatCalculator()
        {
            _xyNeededPositions = new Dictionary<int, Dictionary<int, HashSet<(int X, int Y)>>>();
        }
        
        public int CalculateTakenSeats(string input, bool skipEmpty = false)
        {
            var parsed = input.Split(Environment.NewLine);
            var plan = new char[parsed.Length, parsed[0].Length];
            var allIndex = new HashSet<(int Row,int Col)>();
            for (var row = 0; row < parsed.Length; row++)
            {
                for (var col = 0; col < parsed[0].Length; col++)
                {
                    plan[row, col] = parsed[row][col];
                    allIndex.Add((row, col));
                }
            }

            while (true)
            {
                var toChange = allIndex
                    .Where(ix => ShouldChange(ix.Row, ix.Col, plan, skipEmpty))
                    .ToHashSet();
                if (toChange.Count == 0)
                {
                    break;
                }

                foreach (var (row, col) in toChange)
                {
                    plan[row, col] = plan[row, col] switch
                    {
                        EMPTY => OCCUPIED,
                        OCCUPIED => EMPTY,
                        _ => plan[row, col]
                    };
                }
            }

            return allIndex.Sum(ix => plan[ix.Row, ix.Col] == OCCUPIED ? 1 : 0);
        }

        private bool ShouldChange(int row, int col, char[,] plan, bool skipEmpty)
        {
            var toCheck = GetCachedValue(row, col) ?? GetIndexToCheck(row, col, plan, skipEmpty);
            var occupiedPanicCount = skipEmpty ? 5 : 4;
            return plan[row, col] switch
            {
                FLOOR => false,
                EMPTY => toCheck.Count(x => plan[x.Row, x.Col] != OCCUPIED) == toCheck.Count,
                OCCUPIED => toCheck.Count(x => plan[x.Row, x.Col] == OCCUPIED) >= occupiedPanicCount,
                _ => throw new ArgumentException(plan[row, col].ToString())
            };
        }

        private HashSet<(int Row, int Col)> GetIndexToCheck(int row, int column, char[,] plan, bool skipEmpty)
        {
            var bndRow = plan.GetLength(0);
            var bndCol = plan.GetLength(1);

            var toCheck = GetIndexesToCheck(row, column, skipEmpty, bndRow, bndCol, plan);
            _xyNeededPositions.TryAdd(row, new Dictionary<int, HashSet<(int, int)>>());
            _xyNeededPositions[row].Add(column, toCheck);
            return toCheck;
        }

        private static HashSet<(int Row, int Col)> GetIndexesToCheck(int row, int column, bool skipEmpty, int bndRow, int bndCol, char[,] plan)
        {
            var toCheckCalc = new List<(int RowInc, int ColInc)>
            {
                (-1, -1),
                (-1, 0),
                (-1, +1),
                (0, -1),
                (0, +1),
                (1, -1),
                (1, 0),
                (1, +1)
            };
            var toCheck = new HashSet<(int Row, int Col)>();
            foreach (var (rowAdd, colAdd) in toCheckCalc)
            {
                var rowToCheck = row;
                var columnToCheck = column;
                do
                {
                    rowToCheck += rowAdd;
                    columnToCheck += colAdd;
                    if (rowToCheck >= bndRow || rowToCheck < 0 || columnToCheck >= bndCol || columnToCheck < 0)
                    {
                        break;
                    }

                    if (plan[rowToCheck, columnToCheck] != FLOOR)
                    {
                        toCheck.Add((rowToCheck, columnToCheck));
                        break;
                    }
                    // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                } while (skipEmpty);
            }

            return toCheck;
        }

        private HashSet<(int Row, int Col)> GetCachedValue(int x, int y)
        {
            if (!_xyNeededPositions.ContainsKey(x)) return null;
            return !_xyNeededPositions[x].ContainsKey(y) ? null : _xyNeededPositions[x][y];
        }
    }
}