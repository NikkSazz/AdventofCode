using System;
using System.Collections.Generic;
using System.Diagnostics;

internal class TwentyFive
{
    public static void Solution(string[] input)
    {
        Stopwatch sw = Stopwatch.StartNew();
        //  How many unique lock/key pairs fit together without overlapping in any column?
        int unique = 0;

        (List<string> keys, List<string> locks) = GetTupleList(input);
        // "05343" example string, of length 5 for 5-pin tumbler locks
        foreach (string l in locks)
        {
            // Compare each lock to each key
            foreach (string k in keys)
            {
                if (Fits(l, k))
                    unique++;
            }
        }

        Console.WriteLine($"\nDay Twenty Five Solution: {unique}\tElapsed: {sw.Elapsed}");
        sw.Stop();
    }

    static bool Fits(string l, string k)
    {
        for (int c = 0; c < l.Length; c++)
        {
            if (int.Parse(l[c].ToString()) + int.Parse(k[c].ToString()) > 5)
            {   //  5 is the space because 7 - 2, excluding the top and bottom which indicate wether its a key or a lock
                return false;
            }
        }
        return true;
    }

    static (List<string>, List<string>) GetTupleList(string[] input)
    {
        List<string> keys = new List<string>();
        List<string> locks = new List<string>();
        string[] subject = new string[7];
        int subjectIndex = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != "")
            {
                subject[subjectIndex++] = input[i];
                if (subjectIndex != 7)
                    continue;
            }
            i++; //So the final key/lock is included
            subjectIndex = subjectIndex % 7;

            bool isLock = subject[0] == "#####";
            if (isLock)
            {
                locks.Add(GetLockPin(subject));
            }
            else // isKey
            {
                keys.Add(GetKeyPin(subject));
            }
        }
        return (keys, locks);
    }

    static string GetLockPin(string[] subject)
    {
        string pin = "";
        for (int col = 0; col < subject[0].Length; col++)
        {
            int pinVal = -1;
            foreach (string s in subject)
            {
                if (s[col] == '#')
                {
                    pinVal++;
                }
            }
            pin += pinVal.ToString();
        }
        return pin;
    }

    static string GetKeyPin(string[] subject)
    {
        string pin = "";
        for (int col = 0; col < subject[0].Length; col++)
        {
            int pinVal = -1;
            for (int r = subject.Length - 1; r >= 0; r--)
            {
                if (subject[r][col] == '#')
                {
                    pinVal++;
                }
            }
            pin += pinVal.ToString();
        }
        return pin;
    }
}