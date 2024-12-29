﻿using AdventSazonov._2024;
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
        int dayRequest = 12;
        switch (dayRequest - 1)
        {
            case 0:
                string[] oneInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\1.txt"));
                One.Solution(oneInput);
                break;
            case 1:
                string[] twoInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\2.txt"));
                Two.Solution(twoInput);
                break;
            case 2:
                string[] threeInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\3.txt"));
                Three.Solution(threeInput);
                break;
            case 3:
                string[] fourInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\4.txt"));
                Four.Solution(fourInput);
                break;
            case 4:
                string[] fiveRules = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\5Rules.txt"));
                string[] fiveUpdates = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\5Updates.txt"));
                Five.Solution(fiveRules, fiveUpdates);
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:    // Incomplete
                string[] nineInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\9.txt"));
                string[] nineTest = { "2333133121414131402" };
                Nine.Solution(nineInput[0]);
                break;
            case 9:
                string[] tenInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\10.txt"));
                Ten.Solution(tenInput);
                break;
            case 10:    // Incomplete
                string elevenInput = "1750884 193 866395 7 1158 31 35216 0";
                Eleven.Solution(elevenInput);
                break;
            case 11:
                string[] twelveInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\12.txt"));
                Twelve.Solution(twelveInput);
                break;
            case 12:
                string[] thirteenInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\Source\Repos\Advent24Saz\2024\Inputs\12.txt"));
                Thirteen.Solution();
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
                TwentyTwo.Solution(twentytwoInput);
                break;
            case 22:
                break;
            case 23:    // Incomplete
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