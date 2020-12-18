using System.Text.RegularExpressions;

namespace AdventOfCode.Services
{
    public class OperationOrder
    {
        private static Regex PMatcher = new(@"\(([^()]+)\)");
        private static Regex CMatcher = new(@"(\d+) (\+|\*) (\d+)");
        private static Regex PlusMatcher = new(@"(\d+) \+ (\d+)");
        private static Regex MultiMatcher = new(@"(\d+) \* (\d+)");

        public static long CalculateLineForPartTwo(string line)
        {
            while (PMatcher.IsMatch(line))
            {
                line = PMatcher.Replace(line, m => PartTwo(m.Groups[1].Value));
            }

            return long.Parse(PartTwo(line));
        }
        
        
        private static string PartTwo(string input)
        {
            while (PlusMatcher.IsMatch(input))
            {
                input = PlusMatcher.Replace(input, m => (long.Parse(m.Groups[1].Value) + long.Parse(m.Groups[2].Value)).ToString(), 1);
            }

            while (MultiMatcher.IsMatch(input))
            {
                input = MultiMatcher.Replace(input, m => (long.Parse(m.Groups[1].Value) * long.Parse(m.Groups[2].Value)).ToString(), 1);
            }

            return input;
        }
        
        public static long CalculateLineForPartOne(string line)
        {
            while (PMatcher.IsMatch(line))
            {
                line = PMatcher.Replace(line, m => PartOne(m.Groups[1].Value));
            }

            return long.Parse(PartOne(line));
        }

        private static string PartOne(string input)
        {
            while (CMatcher.IsMatch(input))
            {
                input = CMatcher.Replace(
                    input,
                    m => m.Groups[2].Value == "+"
                        ? (long.Parse((string) m.Groups[1].Value) + long.Parse((string) m.Groups[3].Value)).ToString()
                        : (long.Parse((string) m.Groups[1].Value) * long.Parse((string) m.Groups[3].Value)).ToString(),
                    1);
            }


            return input;
        }
    }
}