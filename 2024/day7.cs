using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventSazonov._2024
{
    internal class Seven
    {
        public static void Solution(string[] input)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long partOne = 0;
            long partTwo = 0;

            foreach (string s in input)
            {
                long compare = long.Parse(s.Substring(0, s.IndexOf(':')));
                string evaluateValues = s.Substring(s.IndexOf(' ') + 1);
                List<int> values = evaluateValues.Split(' ').Select(int.Parse).ToList();
                if (Calibrated(compare, values[0], values.Skip(1).ToList()))
                {
                    partOne += compare;
                }
                // Yes I KNOW SUPER UNOPTIMIZED LIKE DAMN CHILL
                if (NewCalibrated(compare, values[0], values.Skip(1).ToList()))
                {
                    partTwo += compare;
                }
            }

            Console.WriteLine("\nDay Seven Part One Solution: " + partOne);
            Console.WriteLine("\nDay Seven Part Two Solution: " + partTwo);
            sw.Stop();
            Console.WriteLine("Elapsed Time: " + sw.Elapsed);
        }

        static bool Calibrated(long compare, long leftOp, List<int> list)
        {
            if (list.Count == 0)
                return leftOp == compare;

            int next = list[0];
            var remainingList = list.Skip(1).ToList();

            return Calibrated(compare, leftOp * next, remainingList) ||
                   Calibrated(compare, leftOp + next, remainingList);
        }
        static bool NewCalibrated(long compare, long leftOp, List<int> list)
        {
            if (list.Count == 0)
                return leftOp == compare;

            int next = list[0];
            var remainingList = list.Skip(1).ToList();

            return NewCalibrated(compare, leftOp * next, remainingList) ||
                   NewCalibrated(compare, leftOp + next, remainingList) ||
                   NewCalibrated(compare, Concat(leftOp, next), remainingList);
        }

        static long Concat(long firstValue, int secondValue)
        {   //  Ex: 13 || 22 = 1322
            string concat = firstValue.ToString() + secondValue.ToString();
            return long.Parse(concat);
        }
    }
}