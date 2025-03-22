using System;
using System.Diagnostics;

namespace AdventsOfCodes._2015
{
    public class TwentyOne
    {

        // ---------|
        // Shop     | 
        // ---------|
        static (int cost, int dmg)[] weapons =
        {
                (8, 4),
                (10, 5),
                (25, 6),
                (40, 7),
                (74, 8)
        };

        static (int cost, int arm)[] armors =
        {
                (13, 1),
                (31, 2),
                (53, 3),
                (75, 4),
                (102, 5)
        };

        static (int cost, int dmg, int arm)[] rings =
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

            

            /// puzzle input, in boss tuple format
            var b = getBossFromInput(input);

            int partOne = PartOne(b);
            Console.WriteLine($"\nDay Twenty One Part One Solution: {partOne}\n");
            int partTwo = PartTwo(b);
            Console.WriteLine($"\nDay Twenty One Part Two Solution: {partTwo}");

            sw.Stop();
            Console.WriteLine("\nElapsed Time: " + sw.Elapsed);
        }

        private static int PartTwo((int hp, int dmg, int arm) b)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            /*
             * Brute Force, go through each possibility
             * 660 Possibilities
             */
            /// Player starts with stats hp: 100, dmg: 0, arm: 0
            (int hp, int dmg, int arm) p = (100, 0, 0);

            /// compare gold, amount if battle is won
            int cmpGold;
            /// part one solution, skips the battle if the cmp price > leastGold
            int mostGold = -1;

            // just sword
            foreach (var w in weapons)
            {
                cmpGold = w.cost;
                // No reason to check anyway
                if (cmpGold <= mostGold) { continue; }

                p.dmg = w.dmg;

                if (!SimulateBattle(p, b))
                {
                    Console.WriteLine("New way to lose found!" +
                        $"\twith {w.cost} cost weapon");
                    mostGold = cmpGold;
                }

            }

            // sword and armor
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    cmpGold = w.cost + a.cost;

                    if (cmpGold <= mostGold) { continue; }

                    p = (100, w.dmg, a.arm);

                    if (!SimulateBattle(p, b))
                    {
                        Console.WriteLine("New way to lose found!" +
                            $"\twith {w.cost} cost weapon" +
                            $"\tand {a.cost} cost armor" +
                            $"\t\t\t\tat price {cmpGold}");
                        mostGold = cmpGold;
                    }

                }
            }

            // sword and one ring
            foreach (var w in weapons)
            {
                foreach (var r in rings)
                {
                    cmpGold = w.cost + r.cost;
                    if (cmpGold <= mostGold) { continue; }

                    p = (100, w.dmg + r.dmg, r.arm);

                    if (!SimulateBattle(p, b))
                    {
                        Console.WriteLine("New way to lose found!" +
                            $"\twith {w.cost} cost weapon" +
                            $"\tand {r.cost} cost ring" +
                            $"\t\t\t\tat price {cmpGold}");
                        mostGold = cmpGold;
                    }

                }
            }
            // sword and two ring
            foreach (var w in weapons)
            {
                foreach (var r1 in rings)
                {
                    foreach (var r2 in rings)
                    {
                        if (r1.cost == r2.cost) { continue; }

                        cmpGold = w.cost + r1.cost + r2.cost;
                        if (cmpGold <= mostGold) { continue; }

                        p = (100, w.dmg + r1.dmg + r2.dmg, r1.arm + r2.arm);
                        if (!SimulateBattle(p, b))
                        {
                            Console.WriteLine("New way to lose found!" +
                                $"\twith {w.cost} cost weapon" +
                                $"\tand {r1.cost} cost ring" +
                                $"\tand {r2.cost} cost ring" +
                                $"\tat price {cmpGold}");
                            mostGold = cmpGold;
                        }
                    }
                }
            }
            // sword and armor and one ring
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    foreach (var r in rings)
                    {
                        cmpGold = w.cost + a.cost + r.cost;
                        if (cmpGold <= mostGold) { continue; }

                        p = (100, w.dmg + r.dmg, a.arm + r.arm);
                        if (!SimulateBattle(p, b))
                        {
                            Console.WriteLine("New way to lose found!" +
                                $"\twith {w.cost} cost weapon" +
                                $"\tand {a.cost} cost armor" +
                                $"\tand {r.cost} cost ring" +
                                $"\tat price {cmpGold}");
                            mostGold = cmpGold;
                        }
                    }
                }
            }
            // sword and armor and two ring
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    foreach (var r1 in rings)
                    {
                        foreach (var r2 in rings)
                        {
                            if (r1.cost == r2.cost) { continue; }

                            cmpGold = w.cost + a.cost + r1.cost + r2.cost;
                            if (cmpGold <= mostGold) { continue; }

                            p = (100, w.dmg + r1.dmg + r2.dmg, a.arm + r1.arm + r2.arm);
                            if (!SimulateBattle(p, b))
                            {
                                Console.WriteLine("New way to lose found!" +
                                    $"\twith {w.cost} cost weapon" +
                                    $"\tand {a.cost} cost armor" +
                                    $"\tand {r1.cost} cost ring" +
                                    $" and {r2.cost}" +
                                    $"\tat price {cmpGold}");
                                mostGold = cmpGold;
                            }
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            return mostGold;
        }


        private static int PartOne((int hp, int dmg, int arm) b)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            /*
             * Brute Force, go through each possibility
             * 660 Possibilities
             */
            /// Player starts with stats hp: 100, dmg: 0, arm: 0
            (int hp, int dmg, int arm) p = (100, 0, 0);

            /// compare gold, amount if battle is won
            int cmpGold;
            /// part one solution, skips the battle if the cmp price > leastGold
            int leastGold = int.MaxValue;

            // just sword
            foreach (var w in weapons)
            {
                cmpGold = w.cost;
                // No reason to check anyway
                if (cmpGold >= leastGold) { continue; }

                p.dmg = w.dmg;

                if (SimulateBattle(p, b))
                {
                    Console.WriteLine("New way to beat boss found!" +
                        $"\nwith {w.cost} cost weapon");
                    leastGold = cmpGold;
                }

            }

            // sword and armor
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    cmpGold = w.cost + a.cost;

                    if (cmpGold >= leastGold) { continue; }

                    p = (100, w.dmg, a.arm);

                    if (SimulateBattle(p, b))
                    {
                        Console.WriteLine("New way to beat boss found!" +
                            $"\twith {w.cost} cost weapon" +
                            $"\tand {a.cost} cost armor" +
                            $"\t\t\t\tat price {cmpGold}");
                        leastGold = cmpGold;
                    }

                }
            }

            // sword and one ring
            foreach (var w in weapons)
            {
                foreach (var r in rings)
                {
                    cmpGold = w.cost + r.cost;
                    if (cmpGold >= leastGold) { continue; }

                    p = (100, w.dmg + r.dmg, r.arm);

                    if (SimulateBattle(p, b))
                    {
                        Console.WriteLine("New way to beat boss found!" +
                            $"\twith {w.cost} cost weapon" +
                            $"\tand {r.cost} cost ring" +
                            $"\t\t\t\tat price {cmpGold}");
                        leastGold = cmpGold;
                    }

                }
            }
            // sword and two ring
            foreach (var w in weapons)
            {
                foreach (var r1 in rings)
                {
                    foreach (var r2 in rings)
                    {
                        if (r1.cost == r2.cost) { continue; }

                        cmpGold = w.cost + r1.cost + r2.cost;
                        if (cmpGold >= leastGold) { continue; }

                        p = (100, w.dmg + r1.dmg + r2.dmg, r1.arm + r2.arm);
                        if (SimulateBattle(p, b))
                        {
                            Console.WriteLine("New way to beat boss found!" +
                                $"\twith {w.cost} cost weapon" +
                                $"\tand {r1.cost} cost ring" +
                                $"\tand {r2.cost} cost ring" +
                                $"\tat price {cmpGold}");
                            leastGold = cmpGold;
                        }
                    }
                }
            }
            // sword and armor and one ring
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    foreach (var r in rings)
                    {
                        cmpGold = w.cost + a.cost + r.cost;
                        if (cmpGold >= leastGold) { continue; }

                        p = (100, w.dmg + r.dmg, a.arm + r.arm);
                        if (SimulateBattle(p, b))
                        {
                            Console.WriteLine("New way to beat boss found!" +
                                $"\twith {w.cost} cost weapon" +
                                $"\tand {a.cost} cost armor" +
                                $"\tand {r.cost} cost ring" +
                                $"\tat price {cmpGold}");
                            leastGold = cmpGold;
                        }
                    }
                }
            }
            // sword and armor and two ring
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    foreach (var r1 in rings)
                    {
                        foreach (var r2 in rings)
                        {
                            if (r1.cost == r2.cost) { continue; }

                            cmpGold = w.cost + a.cost + r1.cost + r2.cost;
                            if (cmpGold >= leastGold) { continue; }

                            p = (100, w.dmg + r1.dmg + r2.dmg, a.arm + r1.arm + r2.arm);
                            if (SimulateBattle(p, b))
                            {
                                Console.WriteLine("New way to beat boss found!" +
                                    $"\twith {w.cost} cost weapon" +
                                    $"\tand {a.cost} cost armor" +
                                    $"\tand {r1.cost} cost ring" +
                                    $" and {r2.cost}" +
                                    $"\tat price {cmpGold}");
                                leastGold = cmpGold;
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            return leastGold;
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

        /**
         * Simulates a battle between player and boss
         * @return true if player wins
         *  false if player loses
         */
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
