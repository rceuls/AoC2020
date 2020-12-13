using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public static class ShuttleSearch
    {
        public static long GetLastPart(string input)
        {
            var times = input
                .Replace("x", "0")
                .Split(",")
                .Select((x, xi) => (Index: xi, Val: int.Parse(x)))
                .Where(x => x.Val != 0)
                .ToList();

            var i = 0L;
            var baseIndex = 1L;

            foreach (var time in times)
            {
                while (true)
                {
                    if ((i + time.Index) % time.Val == 0)
                    {
                        baseIndex *= time.Val;
                        break;
                    }
                    i += baseIndex;
                }
            }

            return i;
        }
        
        public static long GetEarliestCalculatedTimestamp(ICollection<string> input)
        {
            var tgt = int.Parse(input.First());
            var times = input
                .Last()
                .Split(",")
                .Where(x => x != "x")
                .Select(int.Parse)
                .Distinct()
                .OrderBy(x => x);

            var timeWithNextLeave = new Dictionary<int, int>();
            foreach (var time in times)
            {
                var rem = tgt % time;
                rem = -rem + time; 
                timeWithNextLeave.Add(time, rem);
            }

            var ordered = timeWithNextLeave.OrderBy(x => x.Value);
            var (key, value) = ordered.First();
            return key * value;
        }
    }
}