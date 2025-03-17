using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventsOfCodes._2015
{
    public class Three
    {
        public static void Solution(string input)
        {
            // test input = "^v";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("Day 3 of 2015\n");

            Dictionary<(int x, int y), int> d = new Dictionary<(int x, int y), int> ();
            (int x, int y) t = (0, 0);

            // part two 
            Dictionary<(int x, int y), int> santa = new Dictionary<(int x, int y), int>();
            (int x, int y) ts = (0, 0);
            Dictionary<(int x, int y), int> robot = new Dictionary<(int x, int y), int>();
            (int x, int y) tr = (0, 0);
            bool turn = true;

            d[t] = 1; // starting position
            santa[ts] = 1;
            robot[tr] = 1;

            foreach (var c in input)
            {
                switch(c)
                {
                    case '^':
                        t.y++;
                        if(turn) ts.y++;
                        else tr.y++;
                        break;
                    case 'v':
                        t.y--;
                        if (turn) ts.y--;
                        else tr.y--;
                        break;
                    case '>':
                        t.x++;
                        if (turn) ts.x++;
                        else tr.x++;
                        break;
                    case '<':
                        t.x--;
                        if (turn) ts.x--;
                        else tr.x--;
                        break;
                }

                d[t] = d.ContainsKey(t) ? d[t]++ : 1;

                if (turn)
                {
                    santa[ts] = santa.ContainsKey(ts) ? santa[ts]++ : 1;
                }
                else
                {
                    robot[tr] = robot.ContainsKey(tr) ? robot[tr] : 1;
                }
                turn = !turn;
            }

            int havePresent = d.Count(kvp => kvp.Value >= 1);

            // left join to not duplicate counts
            var outerJoin = santa
                .Union(robot)
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(kvp => kvp.Value)
                 );

            int partTwo = outerJoin.Count(kvp => kvp.Value >= 1);

            Console.WriteLine($"\nDay Three Part One Solution: {havePresent}");
            Console.WriteLine($"\nDay Three Part Two Solution: {partTwo}");

            sw.Stop();
            Console.WriteLine("\nElapsed Time: " + sw.Elapsed);
        }
    }
}
