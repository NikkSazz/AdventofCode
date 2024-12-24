
using System;
using System.Collections.Generic;
using System.Linq;
internal class Two
{
    public static void Solution(string[] input)
    {
        int safe = 0;
        int safer = 0;
        foreach (string s in input)
        {
            if (IsSafe(s))
            {
                safe++;
                safer++;
            }
            else
            {
                string test;
                var chopped = s.Split(' '); // to take out seperate numbers
                for (int i = 0; chopped.Length > i; i++) { chopped[i] += ' '; } //add space for the IsSafe function

                for (int i = 0; i < chopped.Length; i++)
                {
                    test = "";
                    for (int j = 0; j < chopped.Length; j++) // gives every part of s, exept for the i'th number
                    {
                        if (j != i) { test += chopped[j]; }
                    }
                    test = test.Substring(0, test.Length - 1);
                    if (IsSafe(test)) { safer++; break; }
                }

            }
        }
        Console.WriteLine("\nDay Two Part One Solution: " + safe);
        Console.WriteLine("\nDay Two Part Two Solution: " + safer);
    }
    static bool IsSafe(string s) // For day Two
    {
        List<int> check = new List<int>();
        List<int> cmp = new List<int>();
        bool skip;
        var stringList = s.Split(' ');
        foreach (string k in stringList)
        {
            check.Add(Int32.Parse(k));
            cmp.Add(Int32.Parse(k));
        }
        cmp.Sort();
        if (!Enumerable.SequenceEqual(check, cmp)) // check is not all increasing or all decreasing
        {
            cmp.Reverse();
            if (!Enumerable.SequenceEqual(check, cmp)) { return false; }
        }
        // check if difference is atmost 3 and atleast 1
        skip = false;
        for (int i = 1; i < check.Count; i++)
        {
            bool atMostThree = Math.Abs(check[i] - check[i - 1]) > 3;
            bool atLeastOne = Math.Abs(check[i] - check[i - 1]) < 1;
            if (atMostThree || atLeastOne) { skip = true; break; }
        }
        if (skip) { return false; }

        return true;
    }

}