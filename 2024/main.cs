using AdventSazonov._2024.Solution;
using AdventSazonov.Solution;
using System;
using System.Collections.Generic;
using System.IO;

public class main
{
    static void Main()
    {
        /*Console.Write("Which day would you like to see: ");
        var request = Console.ReadLine();
        int dayRequest = int.Parse(request);*/
        int workingOnDay = 22;

        switch (workingOnDay - 1)
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
                break;
            case 3:
                break;
            case 4:
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
                Console.WriteLine("Wrong Answer sad :(");
                break;
            case 9:
                break;
            case 10:
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
                string[] twentytwoInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\User\source\repos\AdventofCode2024\twentytwo.txt"));
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
                break;
            case 24:
                break;
            case 25:
                Console.WriteLine("sbyte:\t" + sbyte.MaxValue.ToString());
                Console.WriteLine("byte:\t" + byte.MaxValue.ToString());
                Console.WriteLine("short:\t" + short.MaxValue.ToString());
                Console.WriteLine("ushort:\t" + ushort.MaxValue.ToString());
                Console.WriteLine("int:\t" + int.MaxValue.ToString());
                Console.WriteLine("uint:\t" + uint.MaxValue.ToString());
                Console.WriteLine("long:\t" + long.MaxValue.ToString());
                Console.WriteLine("ulong:\t" + ulong.MaxValue.ToString());
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