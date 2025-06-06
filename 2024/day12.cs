﻿using System;

internal class Twelve
{
    static bool[,] checkedMap;
    static bool[,] secondMap;
    public static void Solution(string[] inputt)
    {
        string[] input =
        {
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE"

        };
        int inputLen0 = input.Length;
        int inputLen1 = input[0].Length;
        checkedMap = new bool[inputLen0, inputLen1];
        int price = 0;
        int discountedPrice = 0;
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                if (!checkedMap[y, x])
                {
                    char type = input[y][x];

                    var (area, perimeter) = GetAreaPerimiterOfRegion(type, input, y, x);
                    price += area * perimeter;

                    //Console.WriteLine($" - A region of {type} plants with price {area} * {sides} = {area * sides}");
                    //discountedPrice += sides * area;
                }
            }
        }
        Console.WriteLine($"\nDay Twelve Part One Solution: {price}");
        Console.WriteLine($"\nDay Twelve Part Two Solution: {discountedPrice}");
    }

    static (int area, int perimeter) GetAreaPerimiterOfRegion(char type, string[] input, int y, int x)
    {
        int area = 1;
        int perimeter = 0;
        if (input[y][x] == type)
        {
            checkedMap[y, x] = true;
        }
        (int area, int perimeter) t;
        if (y > 0 && input[y - 1][x] == type)
        {
            if (!checkedMap[y - 1, x])
            {
                t = GetAreaPerimiterOfRegion(type, input, y - 1, x);
                area += t.area;
                perimeter += t.perimeter;
            }
        }
        else
        {
            perimeter++;
        }


        if (y < input.Length - 1 && input[y + 1][x] == type)
        {
            if (!checkedMap[y + 1, x])
            {

                t = GetAreaPerimiterOfRegion(type, input, y + 1, x);
                area += t.area;
                perimeter += t.perimeter;
            }
        }
        else
        {
            perimeter++;
        }


        if (x > 0 && input[y][x - 1] == type)
        {
            if (!checkedMap[y, x - 1])
            {
                t = GetAreaPerimiterOfRegion(type, input, y, x - 1);
                area += t.area;
                perimeter += t.perimeter;
            }
        }
        else
        {
            perimeter++;
        }


        if (x < input[y].Length - 1 && input[y][x + 1] == type)
        {
            if (!checkedMap[y, x + 1])
            {
                t = GetAreaPerimiterOfRegion(type, input, y, x + 1);
                area += t.area;
                perimeter += t.perimeter;
            }
        }
        else
        {
            perimeter++;
        }

        return (area, perimeter);
    }
}
/*
RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE
*/