using System;
using System.Collections.Generic;

namespace AdventOfCode.Services
{
    public enum GameConsoleOpAction
    {
        Nop,
        Acc,
        Jmp
    }
    
    public class GameConsoleOperation
    {
        public GameConsoleOperation(GameConsoleOpAction operation, int opCount)
        {
            Op = operation;
            OpCount = opCount;
        }
        
        public GameConsoleOpAction Op { get; set; }
        public int OpCount { get; set; }
    }
    
    public static class GameConsole
    {
        public static long GetLastValueBeforeInfiniteLoop(IEnumerable<string> input)
        {
            var gameOps = ParseInput(input);
            
            var passedIndexes = new HashSet<int>();
            var currentAccumulator = 0L;
            var currentIndex = 0;
            while (true)
            {
                if (!passedIndexes.Add(currentIndex))
                {
                    return currentAccumulator;
                }

                var targetOp = gameOps[currentIndex];
                (currentAccumulator, currentIndex) = DoOp(targetOp, currentAccumulator, currentIndex);
            }
        }

        public static long GetValue(IEnumerable<string> input)
        {
            var gameOps = ParseInput(input);
            var passedIndexes = new HashSet<int>();
            var lastChangedIndex = -1;
            
            while (true)
            {
                var currentIndex = 0;
                var currentAccumulator = 0L;
                while (true)
                {
                    if (!passedIndexes.Add(currentIndex))
                    {
                        ChangeOp(gameOps, lastChangedIndex);
                        for (var i = lastChangedIndex + 1; i < gameOps.Count; i++)
                        {
                            if (!ChangeOp(gameOps, i)) continue;
                            lastChangedIndex = i;
                            break;
                        }
                        passedIndexes.Clear();
                        break;
                    }

                    if (!gameOps.ContainsKey(currentIndex)) 
                    {
                        return currentAccumulator;
                    }
                    var targetOp = gameOps[currentIndex];
                    (currentAccumulator, currentIndex) = DoOp(targetOp, currentAccumulator, currentIndex);
                }
            }
        }

        private static bool ChangeOp(IReadOnlyDictionary<int, GameConsoleOperation> gameOps, int i)
        {
            if (i < 0) return false;
            switch (gameOps[i].Op)
            {
                case GameConsoleOpAction.Jmp:
                    gameOps[i].Op = GameConsoleOpAction.Nop;
                    return true;
                case GameConsoleOpAction.Nop:
                    gameOps[i].Op = GameConsoleOpAction.Jmp;
                    return true;
                case GameConsoleOpAction.Acc:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Dictionary<int, GameConsoleOperation> ParseInput(IEnumerable<string> input)
        {
            var gameOps = new Dictionary<int, GameConsoleOperation>();
            var currentIndex = 0;
            foreach (var line in input)
            {
                var splitted = line.Split(" ");
                var opCount = int.Parse(splitted[1].Trim());
                if (splitted[0] == "nop")
                {
                    gameOps.Add(currentIndex, new GameConsoleOperation(GameConsoleOpAction.Nop, opCount));
                }

                if (splitted[0] == "acc")
                {
                    gameOps.Add(currentIndex, new GameConsoleOperation(GameConsoleOpAction.Acc, opCount));
                }

                if (splitted[0] == "jmp")
                {
                    gameOps.Add(currentIndex, new GameConsoleOperation(GameConsoleOpAction.Jmp, opCount));
                }

                currentIndex += 1;
            }

            return gameOps;
        }
        
        
        private static (long accumelator, int currentIndex) DoOp(GameConsoleOperation targetOp, long currentAccumelator, int currentIndex)
        {
            switch (targetOp.Op)
            {
                case GameConsoleOpAction.Acc:
                    currentAccumelator += targetOp.OpCount;
                    currentIndex += 1;
                    break;
                case GameConsoleOpAction.Nop:
                    currentIndex += 1;
                    break;
                case GameConsoleOpAction.Jmp:
                    currentIndex += targetOp.OpCount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return (currentAccumelator, currentIndex);
        }
    }
}