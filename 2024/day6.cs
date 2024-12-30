using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventSazonov._2024
{
    internal class Six
    {
        public static void Solution(string[] input)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            (int, int) strt = FindStartPos(input);
            (bool escaped, int xMarks) tuple = EscapesOrInfiniteLoop(input, strt);
            if (tuple.escaped)
            {
                Console.WriteLine("\nDay Six Part One Solution: " + tuple.xMarks);
            }

            // Part Two BRUTE FORCE YAAYAA
            int pTwoAns = 0;
            List<char> cArr;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '#') { continue; }
                    if (i == strt.Item1 && j == strt.Item2) { continue; }
                    cArr = input[i].ToCharArray().ToList();
                    cArr[j] = '#';
                    input[i] = new string(cArr.ToArray());

                    tuple = EscapesOrInfiniteLoop(input, strt);
                    if (!tuple.escaped) { pTwoAns++; }

                    cArr.Clear();
                    cArr = input[i].ToCharArray().ToList();
                    cArr[j] = '.';
                    input[i] = new string(cArr.ToArray());
                }
            }
            Console.WriteLine("\nDay Six Part Two Solution: " + pTwoAns);
            sw.Stop();
            Console.WriteLine("\nElapsed time: " + sw.Elapsed);
        }

        static (int, int) FindStartPos(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '^') return (i, j);
                }
            }
            throw new Exception("Did Not find '^' value");
        }

        static (bool, int) EscapesOrInfiniteLoop(string[] input, (int y, int x) pos)
        {
            int direction = 1; // 1: North, 2: East, 3: South, 4: West
            var X = new Dictionary<(int, int), bool>();

            //Replaces ^ with .
            var e = input[pos.y].ToCharArray();
            e[pos.x] = '.';
            input[pos.y] = new string(e);

            // part Two
            int directionOnlyXCount = 0; // How many turns did the guard only step on X
                                         // part Two

            for (int tries = 0; tries < 1000000000; tries++)
            {
                if (direction == 1) // Going North
                {
                    if (pos.y == 0)
                    {   // Very top going north, ESCAPED
                        return (true, X.Count + 1);
                    }
                    if (input[pos.y - 1][pos.x] == '#')
                    {   // Rotate 90 clockwise to East
                        direction = 2;
                        directionOnlyXCount++;
                        if (directionOnlyXCount == 4) { return (false, X.Count + 1); }
                        continue;
                    }

                    if (!X.ContainsKey((pos.y, pos.x)))
                    {   // Unstepped land
                        directionOnlyXCount = 0;
                    }
                    X[(pos.y, pos.x)] = true;
                    pos.y--;
                    continue;
                }
                if (direction == 2) // Going East
                {
                    if (pos.x + 1 == input[0].Length)
                    {   // Very right going East, ESCAPED
                        return (true, X.Count + 1);
                    }
                    if (input[pos.y][pos.x + 1] == '#')
                    {   // Rotate 90 clockwise to South
                        direction = 3;
                        directionOnlyXCount++;
                        if (directionOnlyXCount == 4) { return (false, X.Count + 1); }
                        continue;
                    }

                    if (!X.ContainsKey((pos.y, pos.x)))
                    {   // Unstepped land
                        directionOnlyXCount = 0;
                    }
                    X[(pos.y, pos.x)] = true;
                    pos.x++;
                    continue; ;
                }
                if (direction == 3) // Going South
                {
                    if (pos.y + 1 == input.Length)
                    {   // Very bottom going South, ESCAPED
                        return (true, X.Count + 1);
                    }
                    if (input[pos.y + 1][pos.x] == '#')
                    {   // Rotate 90 clockwise to West
                        direction = 4;
                        directionOnlyXCount++;
                        if (directionOnlyXCount == 4) { return (false, X.Count + 1); }

                        continue;
                    }

                    if (!X.ContainsKey((pos.y, pos.x)))
                    {   // Unstepped land
                        directionOnlyXCount = 0;
                    }
                    X[(pos.y, pos.x)] = true;
                    pos.y++;
                    continue;
                }
                if (direction == 4) // Going West
                {
                    if (pos.x - 1 < 0) //Supposed to be 0 not input[0].Length
                    {   // Very left going West, ESCAPED
                        return (true, X.Count + 1);
                    }
                    if (input[pos.y][pos.x - 1] == '#')
                    {   // Rotate 90 clockwise to North
                        direction = 1;
                        directionOnlyXCount++;
                        if (directionOnlyXCount == 4) { return (false, X.Count + 1); }
                        continue;
                    }

                    if (!X.ContainsKey((pos.y, pos.x)))
                    {   // Unstepped land
                        directionOnlyXCount = 0;
                    }
                    X[(pos.y, pos.x)] = true;
                    pos.x--;
                    continue;
                }
            }
            throw new Exception("Did not compute for 100 million attempts");
        }
    }
}
