using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Services
{
    public record Validator
    {
        private static readonly HashSet<string> ValidHairColors =
            new(new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"});

        private static readonly Regex ValidPassportId = new("^\\d{9}$");
        private static readonly Regex ValidColor = new("^\\#[a-f0-9]{6}$");

        public Validator(string name) => (Name) = (name);
        public string Name { get; }

        public bool IsValid(string input)
        {
            var relevantPart = input.Substring(Name.Length + 1);
            switch (Name)
            {
                case "byr" when int.TryParse(relevantPart, out var asInt):
                    return asInt >= 1920 && asInt <= 2002;
                case "iyr" when int.TryParse(relevantPart, out var asInt):
                    return asInt >= 2010 && asInt <= 2020;
                case "eyr" when int.TryParse(relevantPart, out var asInt):
                    return asInt >= 2020 && asInt <= 2030;
                case "hgt":
                {
                    var start = relevantPart.Substring(0, relevantPart.Length - 2);
                    if (!int.TryParse(start, out var asInt)) return false;
                    var ending = relevantPart.Substring(relevantPart.Length - 2);
                    return ending switch
                    {
                        "cm" => asInt >= 150 && asInt <= 193,
                        "in" => asInt >= 59 && asInt <= 76,
                        _ => false
                    };
                }
                case "hcl":
                    return ValidColor.IsMatch(relevantPart);
                case "ecl":
                    return ValidHairColors.Contains(relevantPart);
                case "pid":
                    return ValidPassportId.IsMatch(relevantPart);
            }

            return true;
        }
    }

    public static class PassportValidator
    {
        private static readonly Validator[] DefaultNeededFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"}
            .Select(x => new Validator(x)).ToArray();

        public static int ValidPassportCountSimple(string input) => ValidPassport(input, false);

        public static int ValidPassportCountComplex(string input) => ValidPassport(input, true);
        
        private static int ValidPassport(string input, bool deepCheck) =>
            input.Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(ppl => ppl.Split(Environment.NewLine).SelectMany(x => x.Split(" ")).ToArray())
                .Select(pl => IsLineValid(pl, DefaultNeededFields, deepCheck) ? 1 : 0)
                .Sum();
        
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