using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace AdventOfCode.Services
{
    public static class DockingData
    {
        private record Operation
        {
            public static Operation Parse(string x)
            {
                var op = new Operation();
                var splitted = x.Split(" = ");

                if (x.StartsWith("mask"))
                {
                    op.IsMask = true;
                    op.Mask = splitted[1];
                    return op;
                }

                op.Location = int.Parse(splitted[0].Replace("]", "").Replace("mem[", ""));
                op.Value = splitted[1];
                return op;

            }

            public string Mask { get; set; }

            public int Location { get; set; }

            public string Value { get; set; }

            public bool IsMask { get; set; }
        }
        
        public static ulong Part2(IEnumerable<string> input)
        {
            var ops = input.Select(Operation.Parse).ToList();
            var currentMask = "";
            var memory = new Dictionary<long, int>();

            foreach (var op in ops)
            {
                if (op.IsMask)
                {
                    currentMask = op.Mask;
                }
                else
                {
                    var ix = Convert.ToString(op.Location, 2).PadLeft(36, '0').ToCharArray();
                    for (var i = 0; i < currentMask.Length; i++)
                    {
                        if (currentMask[i] != '0')
                        {
                            ix[i] = currentMask[i];
                        }
                    }

                    var addresses = GetAddresses(string.Join("", ix));
                    foreach (var addr in addresses.Select(x => Convert.ToInt64(x, 2)).ToArray())
                    {
                        if (!memory.ContainsKey(addr))
                        {
                            memory.Add(addr, int.Parse(op.Value));
                        }

                        memory[addr] = int.Parse(op.Value);
                    }
                }
            }

            var v = 0ul;
            foreach (var item in memory.Values)
            {
                v += (ulong)item;
            }

            return v;
        }

        private static IEnumerable<string> GetAddresses(string v)
        {
            var results = new List<string>();
            if (!v.Contains('X'))
            {
                results.Add(v);
            }
            else
            {
                for (var i = 0; i < 2; i++)
                {
                    var vTemp = v;
                    results.AddRange(GetAddresses(ReplaceFirst(vTemp, "X", i.ToString())));
                }

            }

            return results;
        }
        private static string ReplaceFirst(string text, string search, string replace)
        {
            var pos = text.IndexOf(search, StringComparison.Ordinal);
            if (pos < 0)
            {
                return text;
            }
            return $"{text.Substring(0, pos)}{replace}{text.Substring(pos + search.Length)}";
        }

        public static long Part1(IEnumerable<string> input)
        {
            var ops = input.Select(Operation.Parse).ToList();
            var currentMask = "";
            var memory = new Dictionary<int, string>();
            foreach (var op in ops)
            {
                if (op.IsMask)
                {
                    currentMask = op.Mask;
                }
                else
                {
                    var ix = Convert.ToString(int.Parse(op.Value), 2).PadLeft(36, '0').ToCharArray();
                    for (var i = 0; i < currentMask.Length; i++)
                    {
                        if (currentMask[i] != 'X')
                        {
                            ix[i] = currentMask[i];
                        }
                    }

                    if (!memory.ContainsKey(op.Location))
                    {
                        memory.Add(op.Location, "");
                    }

                    memory[op.Location] = string.Join("", ix).TrimStart('0', ' ');
                }
            }

            var memoryAsConverted = memory
                .ToDictionary(x => x.Key, y => Convert.ToInt64(y.Value, 2));

            return memoryAsConverted.Sum(x => x.Value);
        }
    }
}