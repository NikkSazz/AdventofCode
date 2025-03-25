using System;
using System.Diagnostics;
using System.Linq;

namespace AdventsOfCodes._2015
{
    public class Five
    {
        public static void Solution(string[] input)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("\nDay 5 of 2015\n");

            int niceCount = 0;
            int partTwo = 0;

            // Testing
            /*
             * part One
            input  = new string[] {
                "ugknbfddgicrmopn",
                "aaa",
                "jchzalrnumimnmhp",
                "haegwjzuvuyypxyu",
                "dvszwmarrgswjxmb"

            };
            * part Two
            input = new string[]
            {
                "qjhvhtzxzqqjkmpb",
                "xxyxx",
                "uurcxstgmygtbstg",
                "ieodomkazucvgmuy"
            };
            */


            foreach (string s in input)
            {
                if(IsNice(s))
                {
                    //Console.WriteLine(s + "\tIs nice\n");
                    niceCount++;
                }

                if (PairContainsTwice(s) && RepeatWithLetterInbetween(s))
                {
                    Console.WriteLine(s + "\tIs nice\n");
                    partTwo++;
                }
                else
                Console.WriteLine($"{s}\t is not nice\n");
            }

            Console.WriteLine($"\nDay Five Part One Solution: {niceCount}");
            Console.WriteLine($"\nDay Five Part Two Solution: {partTwo}");

            sw.Stop();
            Console.WriteLine("\nElapsed Time: " + sw.Elapsed);
        }

        private static bool RepeatWithLetterInbetween(string s)
        {
            for(int i = 0; i < s.Length - 2; i++)
            {
                // Console.WriteLine($"{s[i]} {s[i + 1]} {s[i + 2]}");
                if(s[i] == s[i + 2]) { return true; }
            }
            Console.WriteLine("no repeat with letter inbetween");
            return false;
        }

        private static bool PairContainsTwice(string s)
        {
            string tst = "", cmp;
            for (int i = 0; i <= s.Length - 4; i++)
            {
                cmp = s.Substring(i, 2);
                for (int j = i + 2; j <= s.Length - 2; j++)
                {
                    tst = s.Substring(j, 2);
                    if (cmp == tst) { return true; }
                }

            } 
            Console.WriteLine("no pair that appears twice");
            return false;
        }

        private static bool IsNice(string str)
        {
            if(str.Contains("ab") || str.Contains("cd") || str.Contains("pq") || str.Contains("xy"))
            {
                //Console.WriteLine("Contains naughty substring");
                return false;
            }
            char previous = str[0];
            bool twiceRow = false;
            bool skipfirst = true;
            string vowels = "aeiou";
            int vowelCount = 0;
            foreach (var c in str)
            {
                //Console.WriteLine($"{c}\t{vowels.Contains(c)}");
                if(vowels.Contains(c))
                {
                    vowelCount++;
                }

                if (skipfirst)
                {
                    skipfirst = false;
                    continue;
                }

                if (c == previous)
                {
                    twiceRow = true; 
                }

                previous = c;
            }

            /*
            if(vowelCount < 3)
            {
                Console.WriteLine("not enough vowels");
            }
            */

            return twiceRow && vowelCount >= 3;
        }
    }
}
