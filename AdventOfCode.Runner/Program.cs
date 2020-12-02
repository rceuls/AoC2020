using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Services;
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
    }
}
