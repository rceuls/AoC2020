using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    /// <summary>
    /// Code related to the day 1 problem. Use a list of integers to calculate expenses.
    /// </summary>
    public class ExpenseReportCalculator
    {
        private static int TARGET_NUMBER = 2020;
        public enum ExpenseNumberCount
        {
            Two,
            Three
        }

        public static long CreateExpenseReport(IEnumerable<int> input, ExpenseNumberCount calculator)
        {
            return calculator switch
            {
                ExpenseNumberCount.Three => CreateExpenseReportThree(input),
                ExpenseNumberCount.Two => CreateExpenseReportTwo(input),
                _ => throw new NotImplementedException()
            };
        }

        public static long CreateExpenseReportTwo(IEnumerable<int> input)
        {
            var inputAsArray = input.ToArray();

            var validResults = new HashSet<long>();

            for (var i = 0; i < inputAsArray.Length; i++)
            {
                for (var j = i + 1; j < inputAsArray.Length; j++)
                {
                    if (inputAsArray[i] + inputAsArray[j] == TARGET_NUMBER)
                    {
                        validResults.Add(inputAsArray[i] * inputAsArray[j]);
                    }
                }
            }

            return validResults.Max();
        }

        public static long CreateExpenseReportThree(IEnumerable<int> input)
        {
            var inputAsArray = input.ToArray();

            var validResults = new HashSet<long>();

            for (var i = 0; i < inputAsArray.Length; i++)
            {
                for (var j = i + 1; j < inputAsArray.Length; j++)
                {
                    for (var k = j + 1; k < inputAsArray.Length; k++)
                    {
                        if (inputAsArray[i] + inputAsArray[j] + inputAsArray[k] == TARGET_NUMBER)
                        {
                            validResults.Add(inputAsArray[i] * inputAsArray[j] * inputAsArray[k]);
                        }
                    }

                }
            }

            return validResults.Max();
        }
    }
}
