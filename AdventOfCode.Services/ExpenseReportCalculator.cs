using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    /// <summary>
    /// Code related to the day 1 problem. Use an enumerable of integers to calculate expenses.
    /// </summary>
    public static class ExpenseReportCalculator
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

        private static long CreateExpenseReportTwo(IEnumerable<int> input)
        {
            var inputAsArray = input.OrderBy(x => x).ToArray();

            var validResults = new HashSet<long>();

            for (var i = 0; i < inputAsArray.Length; i++)
            {
                for (var j = i + 1; j < inputAsArray.Length; j++)
                {
                    var sum = inputAsArray[i] + inputAsArray[j];
                    if (sum == TARGET_NUMBER)
                    {
                        validResults.Add(inputAsArray[i] * inputAsArray[j]);
                    }
                    else if (sum > TARGET_NUMBER)
                    {
                        break;
                    }
                }
            }

            return validResults.Max();
        }

        private static long CreateExpenseReportThree(IEnumerable<int> input)
        {
            var inputAsArray = input.OrderBy(x => x).ToArray();

            var validResults = new HashSet<long>();

            for (var i = 0; i < inputAsArray.Length; i++)
            {
                for (var j = i + 1; j < inputAsArray.Length; j++)
                {
                    for (var k = j + 1; k < inputAsArray.Length; k++)
                    {
                        var sum = inputAsArray[i] + inputAsArray[j] + inputAsArray[k];
                        if (sum == TARGET_NUMBER)
                        {
                            validResults.Add(inputAsArray[i] * inputAsArray[j] * inputAsArray[k]);
                        }
                        else if (sum > TARGET_NUMBER)
                        {
                            break;
                        }
                    }

                }
            }

            return validResults.Max();
        }
    }
}
