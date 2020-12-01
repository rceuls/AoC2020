using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Services;

namespace AdventOfCode.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 1 - expense report calculation
            var numbers = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Input", "Day1.txt")).Select(int.Parse).ToArray();
         
            // 712075
            Console.WriteLine(ExpenseReportCalculator.CreateExpenseReport(numbers, ExpenseReportCalculator.ExpenseNumberCount.Two)); 
            // 145245270
            Console.WriteLine(ExpenseReportCalculator.CreateExpenseReport(numbers, ExpenseReportCalculator.ExpenseNumberCount.Three));
        }
    }
}
