using AdventSazonov._2024.Solution;
using AdventSazonov.Solution;
using System;
using System.IO;

public class main
{
    static void Main()
    {
        /*
        Console.Write("Which day would you like to see: ");
        var request = Console.ReadLine();
        int dayRequest = int.Parse(request);
        */
        int dayRequest = 10;
        switch (dayRequest - 1)
        {
            case 0:
                string[] oneInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\one.txt"));
                One.Solution(oneInput);
                break;
            case 1:
                string[] twoInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\two.txt"));
                Two.Solution(twoInput);
                break;
            case 2:
                string[] threeInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\three.txt"));
                Three.Solution(threeInput);
                break;
            case 3:
                string[] fourInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\four.txt"));
                Four.Solution(fourInput);
                break;
            case 4:
                string[] fiveRules = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\fiveRules.txt"));
                string[] fiveUpdates = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\fiveUpdates.txt"));
                Five.Solution(fiveRules, fiveUpdates);
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                string[] nineInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\nine.txt"));
                string[] nineTest = { "2333133121414131402" };
                Nine.Solution(nineInput[0]);
                break;
            case 9:
                string[] tenInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\10.txt"));
                Ten.Solution(tenInput);
                break;
            case 10:
                string elevenInput = "1750884 193 866395 7 1158 31 35216 0";
                Eleven.Solution(elevenInput);
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                break;
            case 18:
                break;
            case 19:
                break;
            case 20:
                break;
            case 21:
                string[] twentytwoInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\twentytwo.txt"));
                string[] ttwotest =
                {
                        "1",
                        "10",
                        "100",
                        "2024"
                    };
                TwentyTwo.Solution(twentytwoInput);
                break;
            case 22:
                break;
            case 23:
                string[] twentyfourInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\24.txt"));
                TwentyFour.Solution(twentyfourInput);
                break;
            case 24:
                string[] twentyfiveInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\25.txt"));
                TwentyFive.Solution(twentyfiveInput);
                break;
        }

        Console.WriteLine("\nPress any key twice to exit");
        Console.ReadKey();
        Console.ReadKey();
    }

    /*
        sbyte:  127
        byte:   255
        short:  32767
        ushort: 65535
        int:    2147483647
        uint:   4294967295
        long:   9223372036854775807
        ulong:  18446744073709551615
      */
}