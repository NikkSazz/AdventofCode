using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventsOfCodes._2015
{
    public class TwentyOne
    {
        public static void Solution(string[] input)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("\nDay 21 of 2015\n");

            /*
             * Simulate test battle
            
            var player = (8, 5, 5);
            var boss = (12, 7, 2);
            var simulated = SimulateBattle(player, boss);
            Console.WriteLine($"Simulated Battle: {simulated}");
            */

            // ---------|
            // Shop     | 
            // ---------|
            (int cost, int dmg)[] weapons =
            {
                (8, 4),
                (10, 5),
                (25, 6),
                (40, 7),
                (74, 8)
            };

            (int cost, int arm)[] armor =
            {
                (13, 1),
                (31, 2),
                (53, 3),
                (75, 4),
                (102, 5)
            };

            (int cost, int dmg, int arm)[] rings=
            {
                (25, 1, 0),
                (50, 2, 0),
                (100, 3, 0),
                (20, 0, 1),
                (40, 0, 2),
                (80, 0, 3)
            };
            // ---------|
            // Shop     | 
            // ---------|

            var b = getBossFromInput(input);
            // Player starts with stats hp: 100, dmg: 0, arm: 0
            (int hp, int dmg, int arm) p = (100, 0, 0);
            int leastGold = int.MaxValue;

            // just sword
            // sword and armor
            p = (100, 0, 0);
            // sword and one ring
            p = (100, 0, 0);
            // sword and two ring
            p = (100, 0, 0);
            // sword and armor and one ring
            p = (100, 0, 0);
            // sword and armor and two ring
            p = (100, 0, 0);



            int partOne = leastGold;
            Console.WriteLine($"\nDay Twenty One Part One Solution: {partOne}");
            Console.WriteLine($"\nDay Twenty One Part Two Solution: ");

            sw.Stop();
            Console.WriteLine("\nElapsed Time: " + sw.Elapsed);
        }

        private static int PartOne((int hp, int dmg, int arm) b)
        {
            /*
             * Brute Force, go through each possibility
             * 660 Possibilities
             */
            return -1;
        }

        private static (int hp, int dmg, int arm) getBossFromInput(string[] s)
        {
            int index;
            index = s[0].IndexOf(": ");
            int hp = int.Parse(s[0].Substring(index + 2));

            index = s[1].IndexOf(": ");
            int dmg = int.Parse(s[1].Substring(index + 2));

            index = s[2].IndexOf(": ");
            int arm = int.Parse(s[2].Substring(index + 2));

            return (hp, dmg, arm);
        }

        private static bool SimulateBattle((int hp, int dmg, int arm) player, (int hp, int dmg, int arm) boss)
        {
            while(player.hp > 0)
            {
                //Console.WriteLine($"Player:\thp: {player.hp}\tdmg: {player.dmg}\tarm: {player.arm}");
                //Console.WriteLine($"Boss:\thp: {boss.hp}\tdmg: {boss.dmg}\tarm: {boss.arm}");

                boss.hp -= Math.Max(1, player.dmg - boss.arm);
                if (boss.hp <= 0) return true;

                player.hp -= Math.Max(1, boss.dmg - player.arm);
            }
            return false;
        }
    }
}
