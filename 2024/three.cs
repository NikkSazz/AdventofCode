using System;

public class Three
{
    public static void Solution(string[] input)
    {
        int uno, duo, parse; bool enable = true; int dont, doo;
        int sum = 0; int partTwo = 0;
        for (int i = 0; i < input.Length; i++)
        {
            for (int mul = input[i].IndexOf("mul("); mul != -1; mul = input[i].IndexOf("mul("))
            {
                dont = input[i].IndexOf("don't()");
                doo = input[i].IndexOf("do()");
                if (doo == -1) { doo = int.MaxValue; }
                if (dont == -1) { dont = int.MaxValue; }
                //Console.WriteLine("next mul: {0}, do: {1}, dont; {2}, {3}", mul, doo, dont, input[i]);
                if (dont < mul && dont < doo) { enable = false; }
                if (doo < mul && doo < dont) { enable = true; }
                uno = 0; duo = 0;
                input[i] = input[i].Substring(mul + 4);
                while (int.TryParse(input[i].Substring(0, 1), out parse))
                {
                    uno *= 10;
                    uno += parse;
                    input[i] = input[i].Substring(1);
                }
                if (input[i][0] == ',')
                {
                    input[i] = input[i].Substring(1);
                    while (int.TryParse(input[i].Substring(0, 1), out parse))
                    {
                        duo *= 10;
                        duo += parse;
                        input[i] = input[i].Substring(1);
                    }
                }
                else { uno = 0; duo = 0; continue; }
                if (input[i][0] == ')')
                {
                    if (enable) { partTwo += uno * duo; }
                    //Console.WriteLine("Sum: {0}, Uno: {1}, Duo: {2}, en: {3}", sum, uno, duo, enable);
                    sum += uno * duo;
                }
                else { uno = 0; duo = 0; continue; }
            }
        }
        Console.WriteLine("\nDay Three Part One Solution: " + sum);
        Console.WriteLine("\nDay Three Part Two Solution: " + partTwo);
    }

}