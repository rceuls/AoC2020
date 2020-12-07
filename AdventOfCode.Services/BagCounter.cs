using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public class BagRecord
    {
        public BagRecord(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public int Count { get; set; }

        public string Name { get; set; }
    }
    public static class BagCounter
    {
        public static (int part1, int part2) GetOuterBagCount(string[] split, string target)
        {
            var bags = new Dictionary<string, List<BagRecord>>();
            ParseInput(split, bags);

            var targetBags = bags.Where(x => x.Value
                .Any(br => br.Name == target))
                .Select(x => x.Key)
                .ToArray();
            var allBags = targetBags;
            while (targetBags.Any())
            {
                var parents = bags
                        .Where(x => x.Value
                            .Select(kvp => kvp.Name)
                            .Intersect(targetBags).Any())
                        .ToArray();
                targetBags = parents.Select(x => x.Key).ToArray();
                allBags = allBags.Concat(targetBags).ToArray();
            }

            var part1 = allBags.Distinct().Count();
            var part2 = CalculateContentsCount(bags[target], bags);
            return (part1, part2);
        }

        private static void ParseInput(string[] split, Dictionary<string, List<BagRecord>> bags)
        {
            foreach (var line in split)
            {
                var parentAndChild = line.Split(" contain ");
                var children = parentAndChild[1].Split(", ");
                var parent = parentAndChild[0]
                    .Replace("bags", "bag")
                    .Replace("bag", string.Empty).Trim();
                bags.Add(parent, new List<BagRecord>());
                foreach (var child in children)
                {
                    var childParts = child
                        .Replace(".", string.Empty)
                        .Replace("bags", "bag")
                        .Replace("bag", string.Empty)
                        .Replace(", ", string.Empty)
                        .Split(" ");
                    var childColor = string.Join(" ", childParts.Skip(1)).Trim();
                    if (childColor != "other")
                    {
                        bags[parent].Add(new BagRecord(childColor, int.Parse(childParts[0])));
                    }
                }
            }
        }

        private static int CalculateContentsCount(IReadOnlyCollection<BagRecord> contents, IReadOnlyDictionary<string, List<BagRecord>> bags)
        {
            return contents.Sum(x => x.Count) + contents.Sum(x => CalculateContentsCount(bags[x.Name], bags) * x.Count);
        }
    }
}