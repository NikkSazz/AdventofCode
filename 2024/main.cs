using AdventSazonov.Solution;
using System;
using System.IO;

public class main
{
    static void Main()
    {
        Console.Write("Which day would you like to see: ");
        var request = Console.ReadLine();
        int dayRequest = int.Parse(request);
        //int workingOnDay = 22;

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
        }

        Console.WriteLine("\nPress any key twice to exit");
        Console.ReadKey();
        Console.ReadKey();
    }
}