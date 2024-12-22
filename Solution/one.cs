using System;

public class One
{
    static void Solution(string[] input)
    {
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        foreach (string s in input)
        {
            left.Add(int.Parse(s.Substring(0, 5)));
            right.Add(int.Parse(s.Substring(8, 5)));
        }
        left.Sort();
        right.Sort();
        int sum = 0;
        for (int i = 0; i < left.Count(); i++)
        {
            sum += Math.Abs(left[i] - right[i]);
        }
        Console.WriteLine("\nDay One Part One solution: " + sum);

        int product = 0;
        int occurences;
        foreach (int i in left)
        {
            occurences = 0;
            for (int j = 0; j < right.Count(); j++)
            {
                if (i == right[j]) { occurences++; }
                else if (right[j] > i) break;
            }
            product += i * occurences;
        }
        Console.WriteLine("Day One Part Two solution: " + product);
    }
}