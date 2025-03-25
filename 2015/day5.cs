using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AdventsOfCodes._2015
{
    public class Five
    {
        public static void Solution(string[] input)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("\nDay 5 of 2015\n");

            int niceCount = 0;

            // Testing
            /*
            input  = new string[] {
                "ugknbfddgicrmopn",
                "aaa",
                "jchzalrnumimnmhp",
                "haegwjzuvuyypxyu",
                "dvszwmarrgswjxmb"

            };
            */

            foreach(string s in input)
            {
                if(IsNice(s))
                {
                    //Console.WriteLine(s + "\tIs nice\n");
                    niceCount++;
                }
                // else
                    //Console.WriteLine($"{s}\t is not nice\n");
            }

            Console.WriteLine($"\nDay Five Part One Solution: {niceCount}");
            Console.WriteLine($"\nDay Five Part Two Solution: ");

            sw.Stop();
            Console.WriteLine("\nElapsed Time: " + sw.Elapsed);
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
