using System;
using System.Diagnostics;

public class Ten
{
    static string[] map;
    public static void Solution(string[] input)
    {
        map = new string[input.Length];
        DuplicateInputToMap(input);

        Stopwatch sw = Stopwatch.StartNew();
        int score = 0;
        int rating = 0;
        for (int row = 0; row < map.Length; row++)
        {
            for (int col = 0; col < map[row].Length; col++)
            {
                if (map[row][col] == '0')
                {
                    var t = ScanNeighbors(row, col, '0');
                    score += t.score;
                    rating += t.rating;
                    //Reset map, to see other trailheads' scores
                    DuplicateInputToMap(input);
                }
            }
        }

        Console.WriteLine($"\nDay Ten Part One Solution: {score}\tElapsed: {sw.Elapsed}");
        Console.WriteLine($"\nDay Ten Part Two Solution: {rating}\tElapsed: {sw.Elapsed}");
        sw.Stop();
    }

    static void DuplicateInputToMap(string[] input)
    {
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = input[i];
        }
    }

    static (int score, int rating) ScanNeighbors(int y, int x, char desiredChar)
    {
        char thisChar = map[y][x];
        if (thisChar == '^')
        {   // Peak has been rached with this trailhead, but has another path
            return (0, 1);
        }
        if (desiredChar == thisChar)
        {
            if (thisChar == '9')
            {
                //Must mark as reached, by changing value from '9' to something else
                string markedPeak = map[y].Substring(0, x) + '^' + map[y].Substring(x + 1);
                map[y] = markedPeak;
                return (1, 1);
            }

            int score = 0;
            int rating = 0;
            (int score, int rating) t;
            int nextDesiredInt = int.Parse(desiredChar.ToString()) + 1;
            char nextDesired = (char)('0' + nextDesiredInt);

            // The for loops check if inbounds, then check if its the next desired, 
            //  * or * if the next desired is 9 and the next char is ^
            if (y > 0 && ((map[y - 1][x] == nextDesired)
                || (map[y - 1][x] == '^' && nextDesiredInt == 9)))
            {
                t = ScanNeighbors(y - 1, x, nextDesired);
                score += t.score;
                rating += t.rating;
            }
            if (y < map.Length - 1 && ((map[y + 1][x] == nextDesired)
                || (map[y + 1][x] == '^' && nextDesiredInt == 9)))

            {
                t = ScanNeighbors(y + 1, x, nextDesired);
                score += t.score;
                rating += t.rating;
            }
            if (x > 0 && ((map[y][x - 1] == nextDesired)
                || (map[y][x - 1] == '^' && nextDesiredInt == 9)))
            {
                t = ScanNeighbors(y, x - 1, nextDesired);
                score += t.score;
                rating += t.rating;
            }
            if (x < map[y].Length - 1 && ((map[y][x + 1] == nextDesired)
                || (map[y][x + 1] == '^' && nextDesiredInt == 9)))
            {
                t = ScanNeighbors(y, x + 1, nextDesired);
                score += t.score;
                rating += t.rating;
            }
            return (score, rating);
        }
        return (0, 0);
    }
}

/*
89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732
*/