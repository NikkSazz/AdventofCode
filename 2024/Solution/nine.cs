using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSazonov._2024.Solution
{
    internal class Nine
    {
        public static void Solution(string input)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.Write("Expanding...\t");
            string expanded = Expand(input);
            Console.WriteLine(sw.Elapsed.ToString());

            Console.Write("Moving...\t");
            string moved = MoveFileBlocks(expanded);
            Console.WriteLine(sw.Elapsed.ToString());

            Console.Write("Checking Sum...\t");
            long pOne = FileCheckSum(moved);
            Console.WriteLine(sw.Elapsed.ToString());

            Console.WriteLine($"\nDay Nine Part One: {pOne}");

            Console.WriteLine("\nElapsed Time: " + sw.Elapsed);
        }

        static long FileCheckSum(string file)
        {
            long sum = 0;
            for (int i = 1; i < file.Length; i++)
            {
                sum += int.Parse(file[i].ToString()) * i;
            }
            return sum;
        }

        static string MoveFileBlocks(string file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                file = file.TrimEnd('.');
                if (file[i] == '.')
                {
                    string newFile = file.Substring(0, i);
                    newFile += file[file.Length - 1];
                    newFile += file.Substring(i + 1);
                    newFile = newFile.Substring(0, file.Length - 1);
                    file = newFile;
                }
            }
            return file;
        }

        static string Expand(string input)  //  For Day Nine
        {
            string expanded = "";
            int id = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < int.Parse(input[i].ToString()); j++)
                    {
                        expanded += id;
                    }
                }
                if (i % 2 == 1)
                {
                    for (int j = 0; j < int.Parse(input[i].ToString()); j++)
                    {
                        expanded += ".";
                    }
                    id++;
                }
            }
            return expanded;
        }

    }
}
