using System;

using System.IO;

public class main
{
    static void Main(string[] args)
    {
        Console.Write("Which day would you like to see: ");
        var request = Console.ReadLine();
        int dayRequest = int.Parse(request);
        //int workingOnDay = 22;

        switch (dayRequest - 1)
        {
            case 0:
                string[] oneInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C: \Users\User\Source\Repos\NewRepo\Inputs\one.txt"));
                One.Solution(oneInput);
                break;
        }

        Console.WriteLine("\nPress any key twice to exit");
        Console.ReadKey();
        Console.ReadKey();
    }
}