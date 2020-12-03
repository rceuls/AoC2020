using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Services.Model
{
    public class PasswordPolicy
    {
        private static readonly Regex PwRegex = new Regex(@"(\d+)-(\d+)\s(\w):\s(\w+)");
        public static PasswordPolicy Parse(string input)
        {
            var regexMatches = PwRegex.Match(input);
            return new PasswordPolicy(regexMatches.Groups[4].Value,
                Convert.ToChar(regexMatches.Groups[3].Value),
                int.Parse(regexMatches.Groups[1].Value),
                int.Parse(regexMatches.Groups[2].Value));
        }

        public PasswordPolicy(string password, char targetChar, int min, int max)
        {
            Password = password;
            TargetChar = targetChar;
            Min = min;
            Max = max;
            MinAsIndex = min - 1;
            MaxAsIndex = max - 1;
        }

        public int Min { get; }
        public int Max { get; }
        public char TargetChar { get; }
        public string Password { get; }
        private int MaxAsIndex { get; }
        private int MinAsIndex { get; }

        public bool IsValidForOldRentalPlace()
        {
            var charCount = Password.Count(x => x == TargetChar);
            return charCount >= Min && charCount <= Max;
        }

        public bool IsValidForNewRentalPlace()
        {
            if (MinAsIndex < 0 || Max > Password.Length)
            {
                return false;
            }

            var char1 = Password[MinAsIndex];
            var char2 = Password[MaxAsIndex];
            return char1 == TargetChar ^ char2 == TargetChar;
        }
    }
}
