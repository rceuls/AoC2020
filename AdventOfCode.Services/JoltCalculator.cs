using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public static class JoltCalculator
    {
        public static long UniqueCombinations(IEnumerable<int> input)
        {
            var jolts = input.OrderBy(x => x).ToList();
            jolts.Insert(0, 0); // first element
            jolts.Insert(jolts.Count, jolts.Max() + 3); // last element
            var counters = new Dictionary<int, long> {[jolts.Count - 2] = 1, [jolts.Count - 1] = 0};
            return DoCount(0, counters, jolts);
        }

        private static long DoCount(int key, IDictionary<int, long> counters, IReadOnlyList<int> input)
        {
            if (counters.ContainsKey(key)) return counters[key];
            var counter = 0L;
            for (var i = 1; i <= 3; i++) 
            {
                if (key + i < input.Count && input[key + i] - input[key] <= 3)
                {
                    counter += DoCount(key + i, counters, input);
                }
            }

            counters[key] = counter;
            return counter;
        }
        
        public static long DifferenceCount(IEnumerable<int> input)
        {
            var sorted = input.OrderBy(x => x).ToList();
            var differences = new Dictionary<int, long>();
            var curr = 0; // first element
            foreach (var nxt in sorted)
            {
                var diff = nxt - curr;
                if (!differences.ContainsKey(diff))
                {
                    differences.Add(diff, 0);
                }
                differences[diff] += 1;
                curr = nxt;
            }

            // built in adapter
            differences[3] += 1;

            return differences[1] * differences[3];
        }    
    }
}