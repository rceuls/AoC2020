using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Services
{
    public class Validator
    {
        private static readonly HashSet<string> ValidHairColors =
            new HashSet<string>(new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"});

        private static readonly Regex ValidPassportId = new Regex("\\d{9}");
        private static readonly Regex ValidColor = new Regex("#[a-f0-9]{6}");

        public Validator(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public bool IsValid(string input)
        {
            var relevantPart = input.Substring(Name.Length + 1);
            switch (Name)
            {
                case "byr" when int.TryParse(relevantPart, out var asInt):
                {
                    return asInt >= 1920 && asInt <= 2002;
                }
                case "iyr" when int.TryParse(relevantPart, out var asInt):
                {
                    return asInt >= 2010 && asInt <= 2020;
                }
                case "eyr" when int.TryParse(relevantPart, out var asInt):
                {
                    return asInt >= 2020 && asInt <= 2030;
                }
                case "hgt":
                {
                    var ending = relevantPart.Substring(relevantPart.Length - 2);
                    var start = relevantPart.Substring(0, relevantPart.Length - 2);
                    if (!int.TryParse(start, out var asInt)) return false;
                    if (ending == "cm")
                    {
                        return asInt >= 150 && asInt <= 193;
                    }

                    return asInt >= 59 && asInt <= 76;

                }
                case "hcl":
                {
                    return ValidColor.IsMatch(relevantPart);
                }
                case "ecl":
                {
                    return ValidHairColors.Contains(relevantPart);
                }
                case "pid":
                {
                    return relevantPart.Length == 9 && ValidPassportId.IsMatch(relevantPart);
                }
            }

            return true;
        }
    }

    public static class PassportValidator
    {
        public static Validator[] DefaultNeededFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"}
            .Select(x => new Validator(x)).ToArray();

        public static int ValidPassports(string input, Validator[] keys)
        {
            var validCount = 0;
            foreach (var ppl in input.Split($"{Environment.NewLine}{Environment.NewLine}"))
            {
                var pl =  ppl.Split(Environment.NewLine).SelectMany(x => x.Split(" ")).ToArray();
                validCount += IsLineValid(pl, keys, false) ? 1 : 0;
            }

            return validCount;
        }

        public static int ValidPassportCountDeepCheck(string input, Validator[] keys)
        {
            var validCount = 0;
            foreach (var ppl in input.Split($"{Environment.NewLine}{Environment.NewLine}"))
            {
                var pl =  ppl.Split(Environment.NewLine).SelectMany(x => x.Split(" ")).ToArray();
                var isValid = IsLineValid(pl, keys, true);
                validCount += isValid ? 1 : 0;
            }

            return validCount;
        }
        
        private static bool IsLineValid(string[] passportLines, IEnumerable<Validator> validators, bool deepCheck)
        {
            foreach (var validator in validators)
            {
                var relevantLine = passportLines.FirstOrDefault(x => x.StartsWith(validator.Name));
                if (relevantLine == null)
                {
                    return false;
                }

                if (deepCheck && !validator.IsValid(relevantLine))
                {
                    return false;
                }
            }

            return true;
        }
    }
}