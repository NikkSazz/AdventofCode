using System;

public class Main2025
{
    public static void Start()
    {

        Console.Write("Welcome to Nikolai's Advent of Code 2025\nWhich day would you like to see: ");
        var request = Console.ReadLine();
        int dayRequest = int.Parse(request);

        // int dayRequest = 1;
        switch (dayRequest - 1)
        {
            case 0:
                Console.WriteLine("2025 Day 1");
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