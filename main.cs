using System;

public class main
{
    static void Main()
    {

        Console.Write("Welcome to the Advent of Code\nWhat year would you like to see: ");
        var request = Console.ReadLine();
        int yearRequest = int.Parse(request);

        // int yearRequest = 13;
        switch (yearRequest - 1)
        {
            case 2024:
                Main2024.Start();
                break;
            case 2025:
                Main2025.Start();
                break;

        }

        Console.WriteLine("\nPress any key  to exit");
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