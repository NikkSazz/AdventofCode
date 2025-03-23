using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventsOfCodes._2015
{
    public class Six
    {
        public static void Solution(string[] input)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("\nDay 6 of 2015\n");

            // Testing
            // input = new string[] { "toggle 0,0 through 999,999" };
            //input = new string[] { "turn on 0,0 through 0,0" };
            /*input = new string[]
            {
                "turn on 0,0 through 999,999",
                "turn off 500,500 through 500,500",
                "toggle 999,999 through 999,999"

            };*/

            bool[,] lights = new bool[1000, 1000];
            int[,] brightness = new int[1000, 1000];

            foreach (var inpt in input)
            {
                var cmd = Command(inpt);
                for (int r = cmd.startY; r <= cmd.endY; r++)
                {
                    for (int c = cmd.startX; c <= cmd.endX; c++)
                    {
                        // pt 1
                        lights[r, c] = cmd.turnOn ?? !lights[r, c] ? true : false;

                        // pt 2
                        if (cmd.turnOn == false)
                        {
                            brightness[r, c] = brightness[r, c] == 0 ? 0 : brightness[r, c] - 1;
                        }
                        else if (cmd.turnOn == null) { brightness[r, c] += 2; }
                        else { brightness[r, c]++; }
                    }
                }
               
            }

            int partOne = 0;
            int partTwo = 0;
            for (int i = 0; i < lights.GetLength(0); i++)
            {
                for (int j = 0; j < lights.GetLength(1); j++)
                {
                    partOne += lights[i, j] ? 1 : 0;
                    partTwo += brightness[i, j];
                }
            }

            Console.WriteLine($"\nDay Six Part One Solution: {partOne}");
            Console.WriteLine($"\nDay Six Part Two Solution: {partTwo}");

            sw.Stop();
            Console.WriteLine("\nElapsed Time: " + sw.Elapsed);
        }
        /*
         * Old Code For part two
            int shined = (cmd.endX + 1 - cmd.startX) * (cmd.endY + 1 - cmd.startY);
            // Console.WriteLine(cmd.endX + 1 - cmd.startX);
            // Console.WriteLine(cmd.endY + 1 - cmd.startY);
            if (cmd.turnOn == null) { shined *= 2; }
            else if (cmd.turnOn == false) { shined *= -1; }
            partTwo += shined;
            Console.WriteLine($"{shined}\t{partTwo}");
         * 
         */

        private static (bool? turnOn, int startX, int startY, int endX, int endY) Command(string cmd)
        {
            (bool? turnOn, int startX, int startY, int endX, int endY) ans;

            bool? tO;
            if(cmd.Contains("toggle")) { tO = null; }
            else if(cmd.Contains("on")) { tO = true; }
            else { tO =  false; }
            ans.turnOn = tO;

            string pattern = @"(\d+),(\d+) through (\d+),(\d+)";
            Regex regx = new Regex(pattern);
            Match match = regx.Match(cmd);
            ans.startX = int.Parse(match.Groups[1].Value);
            ans.startY = int.Parse(match.Groups[2].Value);
            ans.endX   = int.Parse(match.Groups[3].Value);
            ans.endY   = int.Parse(match.Groups[4].Value);

            // Console.WriteLine(ans);
            return ans;
        }
    }
}
