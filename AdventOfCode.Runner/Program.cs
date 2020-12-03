using System;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
using AdventOfCode.Services.Model;
using CommandLine;

namespace AdventOfCode.Runner
{
    class Program
    {
        public class Options
        {
            [Option('d', "day", Required = true, HelpText = "Day number to execute.")]
            public ushort TargetDay { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    switch (o.TargetDay)
                    {
                        case 1:
                            DayOne();
                            break;
                        case 2:
                            DayTwo();
                            break;
                        case 3:
                            DayThree();
                            break;
                        default:
                            throw new NotImplementedException("Not available yet");

                    }
                });
        }

        private static void DayOne()
        {
            // Day 1 - expense report calculation
            var numbers = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input", "Day1.txt")).Select(int.Parse)
                .ToArray();

            // 712075
            Console.WriteLine(
                ExpenseReportCalculator.CreateExpenseReport(numbers, ExpenseReportCalculator.ExpenseNumberCount.Two));
            // 145245270
            Console.WriteLine(
                ExpenseReportCalculator.CreateExpenseReport(numbers, ExpenseReportCalculator.ExpenseNumberCount.Three));
        }

        private static void DayTwo()
        {
            // Day 2 - pwd validity

            var items = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input", "Day2.txt"))
                .Select(PasswordPolicy.Parse).ToArray();

            // 416
            Console.WriteLine(PasswordPhilosophy.GetValidPasswords(items, PasswordPhilosophy.RentalPlace.Sleds).Length);
            // 688
            Console.WriteLine(PasswordPhilosophy.GetValidPasswords(items, PasswordPhilosophy.RentalPlace.Tobogan).Length);
        }

        private static void DayThree()
        {
            var items = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Input", "Day3.txt"));

            Console.WriteLine(SlopeTreeCounter.DescendAndCountTrees(items, 1, 3));
            Console.WriteLine(SlopeTreeCounter.DescendAndCountTreesMultipleSlopes(items));

        }
    }
}
