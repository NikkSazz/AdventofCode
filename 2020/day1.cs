private static int One(int[] input, bool partOne)
{
    Array.Sort(input);
    int answer = 0;

    if (partOne)
    {
        foreach (int i in input)
        {
            for (int j = input.Length - 1; j >= 0; j--)
            {
                if (input[j] + i == 2020)
                {
                    answer = input[j] * i;
                    return answer;
                }
            }
        }
        
    }
    //part two
    foreach (int i in input)
    {
        for (int j = input.Length - 1; j >= 0; j--)
        {
            for(int k = j - 1; k >= 0; k--)
            {
                if (input[j] + i + input[k] == 2020)
                {
                    answer = input[j] * i * input[k];
                    return answer;
                }
            }
        }
    }
    return -1;
}
