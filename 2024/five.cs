using System;

public class Five
{
    public static void Solution(string[] rules, string[] updates)
    {
        int midSum = 0; int pTwoAns = 0;
        bool partTwo = false;
        for (int i = 0; i < updates.Length; i++)
        {
            var tuple = IsCorrectOrder(updates[i], rules);
            if (tuple.Item1)
            {
                if (partTwo)
                {
                    pTwoAns += int.Parse(updates[i].Substring(updates[i].Length / 2 - 1, 2));
                    partTwo = false;
                }
                else { midSum += int.Parse(updates[i].Substring(updates[i].Length / 2 - 1, 2)); }
            }
            else // Part Two
            {
                updates[i] = updates[i].Replace(tuple.Item2, tuple.Item3);
                updates[i] = updates[i].Substring(0, tuple.Item4) + tuple.Item2 + updates[i].Substring(tuple.Item4 + 2);
                i--; partTwo = true;
            }
        }
        Console.WriteLine("\nDay Five Part One Solution: " + midSum);
        Console.WriteLine("\nDay Five Part Two Solution: " + pTwoAns);
    }

    static (bool, string, string, int) IsCorrectOrder(string u, string[] rules) // For day Five
    {
        foreach (string r in rules)
        {
            if (u.Contains(r.Substring(3)) && u.Contains(r.Substring(0, 2)) && u.IndexOf(r.Substring(0, 2)) > u.IndexOf(r.Substring(3)))
            {

                return (false, r.Substring(3), r.Substring(0, 2), u.IndexOf(r.Substring(0, 2)));
            }
        }
        return (true, "", "", -1);
    }
}