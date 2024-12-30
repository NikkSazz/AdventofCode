using MathNet.Numerics.LinearAlgebra;
using System;
internal class Thirteen
{
    public static void Solution(string[] input)
    {
        Console.WriteLine("13");
    }

    public static void TestMathNet_Numerics_LinearAlgebra(string[] args)
    {

        // Create a vector
        var vector = Vector<double>.Build.DenseOfArray(new double[] { 1.0, 2.0, 3.0 });
        Console.WriteLine("Vector: ");
        Console.WriteLine(vector);


        // Create a matrix
        var matrix = Matrix<double>.Build.DenseOfArray(new double[,] {
            { 1.0, 2.0 },
            { 3.0, 4.0 }
        });
        Console.WriteLine("\nMatrix:  ");
        Console.WriteLine(matrix);

        // Matrix multiplication example
        var result = matrix * vector.SubVector(0, 2);
        Console.WriteLine("\nMatrix * Subvector:");
        Console.WriteLine(result);


        //Solving a System of Linear Equations
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        // Coefficient matrix (A)
        var matrixA = Matrix<double>.Build.DenseOfArray(new double[,] {
            { 3, -2, 5 },
            { 2, 1, -1 },
            { 1, 2, 3 }
        });

        // Constant vector (b)
        var vectorB = Vector<double>.Build.Dense(new double[] { 1, 2, 3 });

        // Solve the system Ax = b
        var solution = matrixA.Solve(vectorB);
        Console.WriteLine("Solution to Ax = b:");
        Console.WriteLine(solution);

    }

    /*  OLD VERSION, DOES NOT WORK
    public static void Solution(string[] input)
    {
        string bA = "", bB = "", bP = "";
        int tokenSum = 0;

        for (int i = 0; i <= input.Length; i++)
        {
            int which = i % 4;
            switch (which)
            {
                case 0:
                    bA = input[i];
                    break;
                case 1:
                    bB = input[i];
                    break;
                case 2:
                    bP = input[i];
                    break;
                case 3:
                    Console.WriteLine($"A: {bA}\nB: {bB}\nP: {bP}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    var (tokens, aPresses, bPresses) = ClawMachine(bA, bB, bP);
                    if (tokens > 0)
                    {
                        Console.WriteLine($"For Claw #{i / 4 + 1}, Minimum price {tokens}\nA button '{aPresses}'\tB button '{bPresses}'\n\n");
                        tokenSum += tokens;
                    }
                    else
                    {
                        Console.WriteLine($"For claw #{i / 4 + 1}, No combination of A and B presses that will ever win a prize.\n\n");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }

        Console.WriteLine($"\nDay Thirteen Part One Solution: {tokenSum}");
    }

    static (int tokens, int aPresses, int bPresses) ClawMachine(string a, string b, string p)
    {
        string xT = p.Substring(9, p.IndexOf(",") - 9);
        int xTarget = int.Parse(xT);
        int yTarget = int.Parse(p.Substring(p.IndexOf("Y=") + 2));

        int xA = int.Parse(a.Substring(a.IndexOf("X+") + 2, 2));
        int yA = int.Parse(a.Substring(a.IndexOf("Y+") + 2, 2));

        int xB = int.Parse(b.Substring(b.IndexOf("X+") + 2, 2));
        int yB = int.Parse(b.Substring(b.IndexOf("Y+") + 2, 2));
        //Console.WriteLine($"{xA} {yA} {yTarget} {xTarget} {xB} {yB}");

        var (aPresses, bPresses) = CalculateMinimizedAPresses(xTarget, yTarget, xA, yA, xB, yB);
        int tokens = aPresses * 3 + bPresses;
        return (tokens, aPresses, bPresses);
    }

    public static (int, int) CalculateButtonPresses(int xTarget, int yTarget, int xA, int yA, int xB, int yB)
    {
        for (int b = 0; b <= yTarget / yB; b++) // Iterate over possible values for B presses
        {
            int numeratorA = xTarget - xB * b;
            int numeratorY = yTarget - yB * b;

            if (numeratorA % xA == 0 && numeratorY % yA == 0)
            {
                int a = numeratorA / xA;
                if (a >= 0) return (a, b); // Valid solution
            }
        }
        return (0, 0);
        //throw new InvalidOperationException("No solution found!");
    }

    public static (int, int) CalculateMinimizedAPresses(int xTarget, int yTarget, int xA, int yA, int xB, int yB)
    {
        int minA = int.MaxValue;
        int bestB = -1;

        for (int b = 0; b <= yTarget / yB; b++) // Iterate over possible values for B presses
        {
            int numeratorA = xTarget - xB * b;
            int numeratorY = yTarget - yB * b;

            if (numeratorA % xA == 0 && numeratorY % yA == 0)
            {
                int a = numeratorA / xA;
                if (a >= 0 && a < minA) // Ensure a is non-negative and smaller than current minA
                {
                    minA = a;
                    bestB = b;
                }
            }
        }

        //if (minA == int.MaxValue) throw new InvalidOperationException("No solution found!");
        if (minA == int.MaxValue)
        {
            return (0, 0);
        }
        return (minA, bestB);
    }
    */
}