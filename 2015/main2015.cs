using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventsOfCodes._2015
{
    internal class main2015
    {
        public static void askDay()
        {
            Console.WriteLine("2015 Advent of Code :)");
            int dayRequest = 21;
            switch (dayRequest)
            {
                case 3:
                    string[] threeInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\nsazo\source\repos\Advent2024Desktop\Advent2024Desktop\2015\3.txt"));
                    Three.Solution(threeInput[0]);
                    break;
                case 21:
                    string[] twentyOneInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\nsazo\source\repos\AdventsOfCodes\AdventsOfCodes\2015\21.txt"));
                    TwentyOne.Solution(twentyOneInput);
                    break;
                default:
                    Console.WriteLine("Incorrect Day Request");
                    break;
            }
            Console.ReadKey();
        }
    }
}
