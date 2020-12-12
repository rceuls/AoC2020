using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public class RainRisk
    {
        private static readonly List<char> CompassClockwise = new() {'N', 'E', 'S', 'W'};
        private static readonly List<char> CompassCounterClockwise = new() {'N', 'W', 'S', 'E'};

        private record MoveAction
        {
            public MoveAction(char action, int count)
            {
                Action = action;
                Count = count;
            }
            
            public int Count { get; set; }
            public char Action { get; }

            public static MoveAction Parse(string input)
            {
                return new (input[0], Convert.ToInt32(input.Substring(1)));
            }
        }

        public static long CalculateDistanceWithWaypoint(IEnumerable<string> input)
        {
            var allParsed = input.Select(MoveAction.Parse).ToImmutableArray();
            var shipPositions = new List<(long X, long Y)> {(0, 0 )}; // X ( W <> E) Y (N <> S)
            var beaconPositions = new List<(long X, long Y, char Dir)> {(10, 1, 'E')}; // X ( W <> E) Y (N <> S)
            foreach (var move in allParsed)
            {
                var prevShipPosition = shipPositions.LastOrDefault();
                var prevBeaconPosition = beaconPositions.LastOrDefault();
                if (CompassClockwise.Contains(move.Action))
                {
                    beaconPositions.Add(AddPosition(move, prevBeaconPosition.X, prevBeaconPosition.Y, prevBeaconPosition.Dir));
                }
                else switch (move.Action)
                {
                    case 'F':
                    {
                        var newX = prevShipPosition.X + prevBeaconPosition.X * move.Count;
                        var newY = prevShipPosition.Y + prevBeaconPosition.Y * move.Count;
                        shipPositions.Add((newX, newY));
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

            var (x, y) = shipPositions.LastOrDefault();
            return CalculateManhattanDistance(x, y);
        }
        
        public static long CalculateDistance(IEnumerable<string> input)
        {
            var allParsed = input.Select(MoveAction.Parse).ToImmutableArray();
            var positions = new List<(long X, long Y, char Dir)> {(0, 0, 'E')}; // X ( W <> E) Y (N <> S)
            var ix = 0;
            foreach (var move in allParsed)
            {
                var (x, y, dir) = positions[ix];
                if (CompassClockwise.Contains(move.Action))
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

            var pos = positions.LastOrDefault();
            return CalculateManhattanDistance(pos.X, pos.Y);
        }

        private static long CalculateManhattanDistance(long X, long Y)
        {
            return Math.Abs(X) + Math.Abs(Y);
        }

        public static char GetCompassPosition(char currCompassPosition, int adjustment, bool clockwise)
        {
            adjustment /= 90;
            if (clockwise)
            {
                var newPos = CompassClockwise.IndexOf(currCompassPosition);
                newPos += adjustment;
                newPos %= 4;
                return CompassClockwise[newPos];
            }
            else
            {
                var newPos = CompassCounterClockwise.IndexOf(currCompassPosition);
                newPos += adjustment;
                newPos %= 4;
                return CompassCounterClockwise[newPos];
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