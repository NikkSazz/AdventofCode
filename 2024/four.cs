using System;

namespace AdventSazonov.Solution
{
    public class Four
    {
        public static void Solution(string[] input)
        {
            int occurences = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i].IndexOf("SAMX", j) == j) { occurences++; }
                    if (input[i][j] != 'X') { continue; }
                    if (input[i].IndexOf("XMAS", j) == j) { occurences++; }
                    bool north = i > 2;
                    bool south = 137 > i;
                    bool west = j > 2;
                    bool east = 137 > j;
                    if (south && east && input[i][j] == 'X' && input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' && input[i + 3][j + 3] == 'S') { occurences++; }
                    if (south && west && input[i][j] == 'X' && input[i + 1][j - 1] == 'M' && input[i + 2][j - 2] == 'A' && input[i + 3][j - 3] == 'S') { occurences++; }
                    if (north && east && input[i][j] == 'X' && input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' && input[i - 3][j + 3] == 'S') { occurences++; }
                    if (north && west && input[i][j] == 'X' && input[i - 1][j - 1] == 'M' && input[i - 2][j - 2] == 'A' && input[i - 3][j - 3] == 'S') { occurences++; }
                    if (south && input[i][j] == 'X' && input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i + 3][j] == 'S') { occurences++; }
                    if (north && input[i][j] == 'X' && input[i - 1][j] == 'M' && input[i - 2][j] == 'A' && input[i - 3][j] == 'S') { occurences++; }
                }
            }
            Console.WriteLine("\nDay Four Part One Solution: " + occurences);
            //Parte 2
            int cross = 0;
            for (int i = 1; i < input.Length - 1; i++)
            {
                for (int j = 1; j < input[i].Length - 1; j++)
                {
                    if (input[i][j] != 'A') { continue; }
                    if (input[i - 1][j - 1] == 'M' && input[i - 1][j + 1] == 'S' && input[i + 1][j - 1] == 'M' && input[i + 1][j + 1] == 'S') { cross++; } // M   S
                    if (input[i - 1][j - 1] == 'M' && input[i - 1][j + 1] == 'M' && input[i + 1][j - 1] == 'S' && input[i + 1][j + 1] == 'S') { cross++; } // M   M
                    if (input[i - 1][j - 1] == 'S' && input[i - 1][j + 1] == 'M' && input[i + 1][j - 1] == 'S' && input[i + 1][j + 1] == 'M') { cross++; } // S   M 
                    if (input[i - 1][j - 1] == 'S' && input[i - 1][j + 1] == 'S' && input[i + 1][j - 1] == 'M' && input[i + 1][j + 1] == 'M') { cross++; } // S   S
                }
            }
            Console.WriteLine("\nDay Four Part Two Solution: " + cross);
        }
    }
}