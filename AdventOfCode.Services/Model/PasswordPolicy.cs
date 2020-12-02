using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Services.Model
{
    public class PasswordPolicy
    {
        public static PasswordPolicy Parse(string input)
        {
            var splittedBySpace = input.Split(' ');
            return new PasswordPolicy(splittedBySpace.Last(),
                splittedBySpace[1].First(),
                int.Parse(splittedBySpace[0].Split('-')[0]),
                int.Parse(splittedBySpace[0].Split('-')[1]));
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

        private int MinAsIndex { get;  }

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
            return char1 != char2 && (char1 == TargetChar || char2 == TargetChar);
        }
    }
}
