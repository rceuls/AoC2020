using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public static class TicketTranslation
    {
        private static bool IsValidLine(IReadOnlySet<int> indexesCovered, IEnumerable<int> row)
        {
            return row.All(indexesCovered.Contains);
        }
        
        public static ulong GetTicketDepartureFieldCount(List<List<string>> input)
        {
            var fields = input[0];
            var myLine = input[1][1].Split(",").Select(int.Parse).ToList();
            var otherTickets = input[2].Skip(1).ToList();
            
            var allIndexesCovered = new HashSet<int>();
            var labels = GetLabelsAndValidIndexes(fields, allIndexesCovered);
            
            var validLines = otherTickets
                .Select(line => line.Split(",").Select(int.Parse).ToList())
                .Where(x =>  IsValidLine(allIndexesCovered, x))
                .ToList();
            
            validLines.Add(myLine);

            var potentialPositions = labels.ToDictionary(x => x.Key,y => new List<int>());
            for (var column = 0; column < validLines[0].Count; column++)
            {
                var colValues = validLines.Select(x => x[column]).ToList();
                foreach (var (label, validIndexes) in labels)
                {
                    var allRowsMatch = colValues.All(colValue => validIndexes.Contains(colValue));
                    if (allRowsMatch)
                    {
                        potentialPositions[label].Add(column);
                    }
                }
            }

            // order by possible positions.
            potentialPositions = potentialPositions.OrderBy(x => x.Value.Count).ToDictionary(x => x.Key, y => y.Value);
            var passedIndexes = new HashSet<int>();
            foreach (var (_, value) in potentialPositions)
            {
                // filter out all used positions if we have more than one position.
                if (value.Count > 1)
                {
                    value.RemoveAll(x => passedIndexes.Contains(x));
                }

                passedIndexes.Add(value.FirstOrDefault());
            }

            var depData = potentialPositions
                .Where(kvp => kvp.Key.StartsWith("departure"))
                .Select(kvp => (ulong)myLine[kvp.Value[0]]).ToList();

            return depData.Aggregate(1ul, (x, y) => x * y);
        }

        private static Dictionary<string, HashSet<int>> GetLabelsAndValidIndexes(List<string> fields, HashSet<int> allIndexesCovered)
        {
            var labels = new Dictionary<string, HashSet<int>>();
            foreach (var field in fields)
            {
                var subFields = field.Split(":");
                var label = subFields[0];
                var positions = subFields[1].Split("or");
                labels.Add(label, new HashSet<int>());
                foreach (var pos in positions)
                {
                    var indexes = pos.Split('-').Select(int.Parse).ToArray();
                    var start = indexes[0];
                    var end = indexes[1];
                    var rng = Enumerable.Range(start, end - start + 1).ToArray();
                    foreach (var r in rng)
                    {
                        labels[label].Add(r);
                        allIndexesCovered.Add(r);
                    }
                }
            }

            return labels;
        }

        public static int GetTicketScanningErrorRate(List<List<string>> input)
        {
            var fields = input[0];
            var otherTickets = input[2].Skip(1);
            var allIndexesCovered = new HashSet<int>();
            GetLabelsAndValidIndexes(fields, allIndexesCovered);

            return otherTickets.Sum(line => line.Split(",")
                .Select(int.Parse)
                .ToList()
                .Where(item => !allIndexesCovered.Contains(item))
                .Sum());
        }
    }
}