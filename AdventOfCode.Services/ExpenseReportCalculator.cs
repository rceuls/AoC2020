using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public class ExpenseReportCalculator
    {
        public enum ExpenseNumberCount
        {
            Two,
            Three
        }

        public static long CreateExpenseReport(HashSet<int> input, ExpenseNumberCount calculator)
        {
            return calculator switch
            {
                ExpenseNumberCount.Three => CreateExpenseReportThree(input),
                ExpenseNumberCount.Two => CreateExpenseReportTwo(input),
                _ => throw new NotImplementedException()
            };
        }

        public static long CreateExpenseReportTwo(HashSet<int> input)
        {
            var inputAsArray = input.ToArray();

            var validResults = new HashSet<long>();

            for (var i = 0; i < inputAsArray.Length; i++)
            {
                for (var j = i + 1; j < inputAsArray.Length; j++)
                {
                    if (inputAsArray[i] + inputAsArray[j] == 2020)
                    {
                        validResults.Add(inputAsArray[i] * inputAsArray[j]);
                    }
                }
            }

            return validResults.Max();
        }

        public static long CreateExpenseReportThree(HashSet<int> input)
        {
            var inputAsArray = input.ToArray();

            var validResults = new HashSet<long>();

            for (var i = 0; i < inputAsArray.Length; i++)
            {
                for (var j = i + 1; j < inputAsArray.Length; j++)
                {
                    for (var k = j + 1; k < inputAsArray.Length; k++)
                    {
                        if (inputAsArray[i] + inputAsArray[j] + inputAsArray[k] == 2020)
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
