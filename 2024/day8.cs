using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventSazonov._2024
{
    internal class Eight
    {
        public static void Solution(string[] input)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var frequencyOccurences = GetFrequencyDictionary(input);

            var partOne = new HashSet<(int, int)>();
            var partTwo = new HashSet<(int, int)>();
            foreach (char key in frequencyOccurences.Keys)
            {
                var countTuple = GetAntinodeCount(input, key, frequencyOccurences[key]);
                partOne.UnionWith(countTuple.Item1);
                partTwo.UnionWith(countTuple.Item2);
            }
            Console.WriteLine("\nDay Eight Part One Solution: " + partOne.Count);
            Console.WriteLine($"\nDay Eight Part Two Solution: {partTwo.Count}\n");
            sw.Stop();
            Console.WriteLine("Elapsed Time: " + sw.Elapsed);
        }

        static (HashSet<(int, int)>, HashSet<(int, int)>) GetAntinodeCount(string[] input, char key, int occurence)
        {   //  Gets the amount of antennas avaliable for each
            var uniqueAntinodes = new HashSet<(int, int)>();
            List<(int yPos, int xPos)> antenna = PositionList(input, key);
            int inputRowLen = input.Length;
            int inputColLen = input[0].Length;
            int count = antenna.Count;
            var hashSetTwo = new HashSet<(int, int)>();
            for (int sourceAntenna = 0; sourceAntenna < count; sourceAntenna++)
            {
                //  For each antenna of the same frequency
                //  Compare with every other antenna,
                //  If a ricochet fits in the picture, +1 antinode
                for (int targetAntenna = 0; targetAntenna < count; targetAntenna++)
                {
                    if (targetAntenna == sourceAntenna) { continue; }
                    var tuple = IsAntinodeInBouds(antenna[sourceAntenna], antenna[targetAntenna], inputColLen, inputRowLen);
                    if (tuple.Item1)
                    {
                        uniqueAntinodes.Add((tuple.Item2, tuple.Item3));
                        hashSetTwo.UnionWith(GetMkTwoAntenna(antenna[sourceAntenna], antenna[targetAntenna], inputRowLen, inputColLen));
                    }
                }
            }
            hashSetTwo.UnionWith(uniqueAntinodes);
            // Add Each char to the part two hashset, to include those antennas who dont have an antinode
            hashSetTwo.UnionWith(antenna.ToHashSet());
            return (uniqueAntinodes, hashSetTwo);
        }

        static HashSet<(int, int)> GetMkTwoAntenna((int yPos, int xPos) source, (int yPos, int xPos) target, int inputRowLen, int inputColLen)
        {
            var hash = new HashSet<(int, int)>();
            var tuple = IsAntinodeInBouds(source, target, inputRowLen, inputColLen);
            if (tuple.Item1)
            {
                hash.Add((tuple.Item2, tuple.Item3));
                hash.UnionWith(GetMkTwoAntenna(target, (tuple.Item2, tuple.Item3), inputRowLen, inputColLen));
            }
            return hash;
        }

        static Dictionary<char, int> GetFrequencyDictionary(string[] input)
        {
            var dictionary = new Dictionary<char, int>();
            foreach (string row in input)
            {
                foreach (char c in row)
                {
                    if (c == '.') { continue; }
                    if (dictionary.ContainsKey(c)) { dictionary[c]++; }
                    else { dictionary[c] = 1; }
                }
            }
            return dictionary;
        }

        static List<(int, int)> PositionList(string[] input, char c)
        {
            var list = new List<(int, int)>();
            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[row].Length; col++)
                {
                    if (input[row][col] == c) { list.Add((row, col)); }
                }
            }
            return list;
        }

        static (bool, int, int) IsAntinodeInBouds((int row, int col) source, (int row, int col) destination, int colLength, int rowLength)
        {
            if (source.row == destination.row && source.col == destination.col)
                return (false, -1, -1);

            var antinode = ComputeAntinodePosition(source, destination);
            // Check bounds 
            bool inBounds = antinode.row >= 0 && antinode.row < rowLength && antinode.col >= 0 && antinode.col < colLength;
            return (inBounds, antinode.row, antinode.col);
        }

        static (int row, int col) ComputeAntinodePosition((int row, int col) source, (int row, int col) destination)
        {
            int rowDistance = Math.Abs(source.row - destination.row);
            int colDistance = Math.Abs(source.col - destination.col);

            // Determine direction and calculate position
            int targetRow = source.row + (destination.row - source.row) * 2;
            int targetCol = source.col + (destination.col - source.col) * 2;

            return (targetRow, targetCol);
        }
    }
}