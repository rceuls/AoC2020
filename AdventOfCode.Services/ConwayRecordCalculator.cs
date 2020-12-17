using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public record CubePosition
    {
        public CubePosition(int row, int column, int depth, bool isActive)
        {
            Row = row;
            Column = column;
            Depth = depth;
            IsActive = isActive;
        }
        
        public int Row { get; }
        public int Column { get; }
        public int Depth { get; }
        public bool IsActive { get; set; }
    }
    
    public static class ConwayRecordCalculator
    {
        public static int GetActiveCubes(int activeCycles, string input)
        {
            var plane = CreatePlane(input);
            for (; activeCycles > 0; activeCycles--)
            {
                var positionsToChange = new HashSet<string>();
                var allNeededPositions = new HashSet<string>();

                foreach (var (_, value) in plane)
                {
                    var subPos  = GetPositionsSurrounding(value);
                    foreach (var sp in subPos)
                    {
                        allNeededPositions.Add(sp);
                    }
                }
                
                foreach(var missing in allNeededPositions.Where(x =>!plane.ContainsKey(x)))
                {
                    var pos = missing.Split(";").Select(int.Parse).ToArray();
                    plane.Add(missing, new CubePosition(pos[0], pos[1], pos[2], false));
                }

                foreach (var (key, value) in plane)
                {
                    var positionsToCheck = GetPositionsSurrounding(value);
                    var totalActive = plane.Where(x => positionsToCheck.Contains(x.Key)).Count(x => x.Value.IsActive);
                    SetShouldBeSwitched(value.IsActive, totalActive, positionsToChange, key);
                }

                foreach (var kvp in plane.Where(x => positionsToChange.Contains(x.Key)).ToArray())
                {
                    kvp.Value.IsActive = !kvp.Value.IsActive;
                }
            }
            return plane.Select(x => x.Value).Count(x => x.IsActive);
        }

        private static HashSet<string> GetPositionsSurrounding( CubePosition value)
        {
            var allNeededPositions = new HashSet<string>();
            for (var row = -1; row <= 1; row++)
            {
                for (var column = -1; column <= 1; column++)
                {
                    for (var depth = -1; depth <= 1; depth++)
                    {
                        if (row == 0 && column == 0 && depth == 0) continue;
                        allNeededPositions.Add($"{value.Row + row};{value.Column + column};{value.Depth + depth}");
                    }
                }
            }

            return allNeededPositions;
        }

        private static void SetShouldBeSwitched(bool isActive, int totalActive, ISet<string> positionsToChange, string key)
        {
            switch (isActive)
            {
                case true:
                {
                    if (totalActive != 3 && totalActive != 2)
                    {
                        positionsToChange.Add(key);
                    }

                    break;
                }
                default:
                {
                    if (totalActive == 3)
                    {
                        positionsToChange.Add(key);
                    }

                    break;
                }
            }
        }

        private static Dictionary<string, CubePosition> CreatePlane(string input)
        {
            var split = input.Split(Environment.NewLine);
            var items = new Dictionary<string, CubePosition>();
            for (var row = 0; row < split.Length; row++)
            {
                for (var column = 0; column < split[row].Length; column++)
                {
                    items.Add($"{row};{column};0",
                        new CubePosition(row, column, 0, split[row][column] == '#'));
                }
            }

            return items;
        }
    }
}