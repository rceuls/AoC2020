using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Services
{
    /// <summary>
    /// Code related to the day 2 problem. Calculate the validity of a password database.
    /// </summary>
    public static class PasswordPhilosophy
    {
        public enum RentalPlace
        {
            Sleds,
            Tobogan
        }

        public static PasswordPolicy[] GetValidPasswords(IEnumerable<PasswordPolicy> input, RentalPlace rentalPlace)
        {
            return rentalPlace switch
            {
                RentalPlace.Sleds => GetValidPasswordsOldRentalPlace(input),
                RentalPlace.Tobogan => GetValidPasswordsRentalPlace(input),
                _ => throw new NotImplementedException()
            };
        }

        private static PasswordPolicy[] GetValidPasswordsOldRentalPlace(IEnumerable<PasswordPolicy> policies)
        {
            return policies.Where(p => p.IsValidForOldRentalPlace()).ToArray();
        }

        private static PasswordPolicy[] GetValidPasswordsRentalPlace(IEnumerable<PasswordPolicy> policies)
        {
            return policies.Where(p => p.IsValidForNewRentalPlace()).ToArray();

        }
    }
    
    public class PasswordPolicy
    {
        private static readonly Regex PwRegex = new Regex(@"(\d+)-(\d+)\s(\w):\s(\w+)");
        private readonly char _targetChar;
        private readonly string _password;
        private readonly int _min;
        private readonly int _max;
        private readonly int _minAsIndex;
        private readonly int _maxAsIndex;

        public static PasswordPolicy Parse(string input)
        {
            var regexMatches = PwRegex.Match(input);
            return new PasswordPolicy(regexMatches.Groups[4].Value,
                Convert.ToChar(regexMatches.Groups[3].Value),
                int.Parse(regexMatches.Groups[1].Value),
                int.Parse(regexMatches.Groups[2].Value));
        }

        private PasswordPolicy(string password, char targetChar, int min, int max)
        {
            _password = password;
            _targetChar = targetChar;
            _min = min;
            _max = max;
            _minAsIndex = min - 1;
            _maxAsIndex = max - 1;
        }
        
        public bool IsValidForOldRentalPlace()
        {
            var charCount = _password.Count(x => x == _targetChar);
            return charCount >= _min && charCount <= _max;
        }

        public bool IsValidForNewRentalPlace()
        {
            if (_minAsIndex < 0 || _max > _password.Length)
            {
                return false;
            }

            var char1 = _password[_minAsIndex];
            var char2 = _password[_maxAsIndex];
            return char1 == _targetChar ^ char2 == _targetChar;
        }
    }
}