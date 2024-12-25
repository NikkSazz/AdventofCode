using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

internal class TwentyFour
{

    static Dictionary<string, byte> registers = new Dictionary<string, byte>();
    public static void Solution(string[] input)
    {
        Stopwatch sw = Stopwatch.StartNew();
        FillDictionaryWithInitialValues(input);

        int startIndex = GetGateConnectionsStartIndex(input);
        for (int i = input.Length - 1; input[i] != ""; i--)
        {
            // Find each z value starting at the final value
            string outGate = input[i].Substring(input[i].Length - 3);
            if (outGate.StartsWith("z"))
            {
                registers[outGate] = GetGateValue(outGate, input, i, startIndex);
            }
        }

        string pOneBinary = BinaryZWires(registers);
        Console.WriteLine(pOneBinary);
        var pOneDecimal = Convert.ToInt64(pOneBinary, 2);
        Console.WriteLine($"\nDay Twenty Four Part One: {pOneDecimal}\tElapsed: {sw.Elapsed}");
        sw.Stop();
    }

    static byte GetGateValue(string outGate, string[] input, int i, int startIndex)
    {
        string firstGate = input[i].Substring(0, 3);
        string secondGate = input[i].Substring(input[i].Substring(5).IndexOf(" ") + 6, 3);

        int findIndex;
        if (!registers.ContainsKey(firstGate))
        {
            findIndex = FindIndexFor(firstGate, startIndex, input);
            registers[firstGate] = GetGateValue(firstGate, input, findIndex, startIndex);
        }
        if (!registers.ContainsKey(secondGate))
        {
            findIndex = FindIndexFor(secondGate, startIndex, input);
            registers[secondGate] = GetGateValue(secondGate, input, findIndex, startIndex);
        }

        string operation = input[i].Substring(input[i].IndexOf(" ") + 1, 3);
        Console.WriteLine(firstGate + " " + operation + " " + secondGate + " " + outGate);
        if (operation == "AND")
        {
            return (byte)(registers[firstGate] & registers[secondGate]);
        }
        if (operation == "OR ")
        {
            return (byte)(registers[firstGate] | registers[secondGate]);
        }
        if (operation == "XOR")
        {
            return (byte)(registers[firstGate] ^ registers[secondGate]);
        }

        throw new Exception("Did not pass logic test");
    }

    static int FindIndexFor(string what, int startIndex, string[] input)
    {
        for (int i = startIndex; i < input.Length; i++)
        {
            string outGate = input[i].Substring(input[i].Length - 3);
            if (outGate == what)
            {
                return i;
            }
        }
        throw new Exception("did not find an index for " + what);
    }

    static string BinaryZWires(Dictionary<string, byte> dictionary)
    {
        var sortedDict = dictionary.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        string ansBinary = "";
        foreach (var v in sortedDict.Reverse())
        {
            if (!v.Key.StartsWith("z")) { break; }
            Console.WriteLine(v);
            ansBinary += v.Value.ToString();
        }
        return ansBinary;
    }

    static void FillDictionaryWithInitialValues(string[] input)
    {
        foreach (var s in input)
        {
            if (s == "") { break; }
            string key = s.Substring(0, 3);
            byte val = byte.Parse(s[s.Length - 1].ToString());
            registers[key] = val;
        }
    }

    static int GetGateConnectionsStartIndex(string[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == "")
            {
                return i + 1;
            }
        }
        throw new Exception("did not find start Index");
    }
}