using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Services;

namespace AdventOfCode.Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Input", "Input.txt"));

            Console.WriteLine(PassportValidator.ValidPassportCount(items, PassportValidator.DefaultNeededFields));
        }
    }
}
