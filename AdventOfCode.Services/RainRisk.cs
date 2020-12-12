using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public class RainRisk
    {
        private static List<char> compassClockwise = new() {'N', 'E', 'S', 'W'};
        private static List<char> compassCounterClockwise = new() {'N', 'W', 'S', 'E'};

        private static string FilePath = "/home/raf/dev/AoC2020/AdventOfCode.Services/RainRisk.csv";
        private record MoveAction
        {
            public MoveAction(char action, int count)
            {
                Action = action;
                Count = count;
            }
            
            public int Count { get; set; }
            public char Action { get; set; }

            public static MoveAction Parse(string input)
            {
                return new (input[0], Convert.ToInt32(input.Substring(1)));
            }
        }

        public static long CalculateDistanceWithWaypoint(IEnumerable<string> input)
        {
            var allParsed = input.Select(MoveAction.Parse).ToImmutableArray();
            var shipPositions = new List<(long X, long Y, char Dir)> {(0, 0, 'E')}; // X ( W <> E) Y (N <> S)
            var beaconPositions = new List<(long X, long Y, char Dir)> {(10, 1, 'E')}; // X ( W <> E) Y (N <> S)
            foreach (var move in allParsed)
            {
                var prevShipPosition = shipPositions.LastOrDefault();
                var prevBeaconPosition = beaconPositions.LastOrDefault();
                if (compassClockwise.Contains(move.Action))
                {
                    beaconPositions.Add(AddPosition(move, prevBeaconPosition.X, prevBeaconPosition.Y, prevBeaconPosition.Dir));
                }
                else switch (move.Action)
                {
                    case 'F':
                    {
                        var newX = prevShipPosition.X + prevBeaconPosition.X * move.Count;
                        var newY = prevShipPosition.Y + prevBeaconPosition.Y * move.Count;
                        var newDir = prevShipPosition.Dir;
                        shipPositions.Add((newX, newY, newDir));
                        break;
                    }
                    case 'R':
                    case 'L':
                    {
                        if (move.Count == 180)
                        {
                            beaconPositions.Add((prevBeaconPosition.X *= -1, prevBeaconPosition.Y *= -1, prevBeaconPosition.Dir));
                        }
                        else if(move.Action == 'R' && move.Count == 90 || move.Action == 'L' && move.Count == 270) 
                        {
                            beaconPositions.Add((prevBeaconPosition.Y, prevBeaconPosition.X *= -1, prevBeaconPosition.Dir));
                        }
                        else
                        {
                            beaconPositions.Add((prevBeaconPosition.Y *= -1, prevBeaconPosition.X, prevBeaconPosition.Dir));
                        }
                    }
                    break;
                }
            }
            return CalculateManhattanDistance(shipPositions.LastOrDefault());
        }
        
        public static long CalculateDistance(IEnumerable<string> input)
        {
            var allParsed = input.Select(MoveAction.Parse).ToImmutableArray();
            var positions = new List<(long X, long Y, char Dir)> {(0, 0, 'E')}; // X ( W <> E) Y (N <> S)
            var ix = 0;
            foreach (var move in allParsed)
            {
                var (x, y, dir) = positions[ix];
                if (compassClockwise.Contains(move.Action))
                {
                    positions.Add(AddPosition(move, x, y, dir));
                }
                else
                {
                    var mvAction = new MoveAction(dir, 0);
                    switch (move.Action)
                    {
                        case 'L':
                        case 'R':
                            positions.Add((x, y, GetCompassPosition(dir, move.Count, move.Action == 'R')));
                            break;
                        default:
                            mvAction.Count = move.Count;
                            positions.Add(AddPosition(mvAction, x, y, dir));
                            break;
                    }
                }

                ix++;
            }

            return CalculateManhattanDistance(positions.LastOrDefault());
        }

        private static long CalculateManhattanDistance((long X, long Y, char Dir) lastPosition)
        {
            return Math.Abs(lastPosition.X) + Math.Abs(lastPosition.Y);
        }

        public static char GetCompassPosition(char currCompassPosition, int adjustment, bool clockwise)
        {
            adjustment /= 90;
            if (clockwise)
            {
                var newPos = compassClockwise.IndexOf(currCompassPosition);
                newPos += adjustment;
                newPos %= 4;
                return compassClockwise[newPos];
            }
            else
            {
                var newPos = compassCounterClockwise.IndexOf(currCompassPosition);
                newPos += adjustment;
                newPos %= 4;
                return compassCounterClockwise[newPos];
            }
        }

        private static (long X, long Y, char Dir) AddPosition(MoveAction move, long currX, long currY, char currDir)
        {
            return move.Action switch
            {
                'E' => (currX + move.Count, currY, currDir),
                'W' => (currX - move.Count, currY, currDir),
                'N' => (currX, currY + move.Count, currDir),
                'S' => (currX, currY - move.Count, currDir),
                _ => throw new ArgumentException()
            };
        }
    }
}