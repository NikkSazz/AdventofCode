private static int Five(string[] inputamadre, bool partOne)
{
    string[] input = new string[inputamadre.Length];
    for (int i = 0; i < inputamadre.Length; i++)
    {
        input[i] = inputamadre[i];
    }

    int[] ints = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = input[i].Replace('F', '0');
            input[i] = input[i].Replace('B', '1');
            ints[i] = Convert.ToInt32(input[i].Substring(0, 7), 2);
            ints[i] *= 8;
            input[i] = input[i].Substring(7);
            input[i] = input[i].Replace('L', '0');
            input[i] = input[i].Replace('R', '1');
            ints[i] += Convert.ToInt32(input[i], 2);
        }
    Array.Sort(ints);

    if (!partOne)
    {
        for (int i = 1; i < ints.Length; i ++)
        {
            Console.WriteLine((ints[i] - ints[i-1]) + "  " + ints[i] +" "+ ints[i-1]);
            if (ints[i] - ints[i - 1] == 2)
            {
                return ints[i] - 1; 
            }
        }
        return -69;
    }


    return ints[ints.Length - 1];
}
