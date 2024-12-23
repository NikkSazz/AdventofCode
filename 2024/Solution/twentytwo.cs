using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventSazonov._2024.Solution
{
    internal class TwentyTwo
    {
        /* README
         * So the problem with this code
         * is that the PopulateCodeArray method
         * is wrong, due to, I belive
         * LINES 43-45. From my debugging,
         * the List is proper and correct, 
         * however when adding it into the 
         * list[] array, it loses its value and it 
         * not properly stored.
         * Good luck :)
         * Nikolai Dec 2024
         */
        public static void Solution(string[] input)
        {
            Stopwatch sw = Stopwatch.StartNew();
            string[] inputtest =
            {
                "1",
                "2",
                "3",
                "2024"
            };
            //string[] input = { "123" };
            //int generate = 10;
            int generate = 2000;
            long sum = 0;
            List<sbyte> priceList = new List<sbyte>();
            List<sbyte>[] priceArray = new List<sbyte>[input.Length];
            int arrIndex = 0;
            foreach (string buyer in input)
            {
                priceList.Clear();
                priceList.Add(Price(buyer)); // Initial price

                long buy = long.Parse(buyer);
                for (var i = 0; i < generate; i++)
                {
                    buy = Secret(buy);
                    priceList.Add(Price(buy.ToString()));
                }
                sum += buy;

                priceList.RemoveAt(priceList.Count - 1); // not used in the example soo..
                priceArray[arrIndex] = new List<sbyte>();
                priceArray[arrIndex].AddRange(priceList);
                arrIndex++;
            }

            Console.WriteLine($"\nDay Twenty One Part One: {sum}\tElsapsed: {sw.Elapsed}");
            int bananaMax = PartTwo(priceArray);
            Console.WriteLine($"\nDay Twenty One Part Two: {bananaMax}\tElsapsed: {sw.Elapsed}");
            sw.Stop();
        }

        static int PartTwo(List<sbyte>[] priceArray)
        {
            int maxBananna = -1;
            sbyte[][] codesArray = new sbyte[priceArray.Length][];
            codesArray = PopulateCodeArray(priceArray);

            // Every pattern of the first salesman
            List<sbyte[]> codesList = new List<sbyte[]>();
            for (int salesmanIndex = 4; salesmanIndex < priceArray[0].Count; salesmanIndex++)
            {
                sbyte[] code = FillCodeAtNPrice(codesArray[0], salesmanIndex);
                if (codesList.Contains(code)) { continue; }
                //PrintCode(code, priceArray[0][salesmanIndex]);
                int newVal = GoThroughEverySalesman(code, codesArray, priceArray);
                if(newVal > maxBananna)
                {
                    maxBananna = newVal;
                }
            }
            // Note this code may not work if the first buyer does not have the correct combination of codes
            return maxBananna;
        }

        static void PrintCode(sbyte[] code, int val)
        {
            Console.WriteLine($"Code for {val} is {code[0]}, {code[1]}, {code[2]}, {code[3]}");
        }

        static int GetCodeIndex(sbyte[] code, sbyte[][] codesArray, int n)
        {
            // Ignore first value of codesarray[]
            for (int i = 1; i <= codesArray[0].Length - 4; i++)
            {
                if (codesArray[n][i] == code[0])
                {
                    if (codesArray[n][i + 1] == code[1])
                    {
                        if (codesArray[n][i + 2] == code[2])
                        {
                            if (codesArray[n][i + 3] == code[3])
                            {
                                return i;
                            }
                        }
                    }
                }
            }
            return -1; //DNE
        }

        static int GoThroughEverySalesman(sbyte[] code, sbyte[][] codesArray, List<sbyte>[] priceArray)
        {
            int sum = 0;
            for (int salesman = 0; salesman < priceArray.Length; salesman++)
            {
                int codeIndex = GetCodeIndex(code, codesArray, salesman);
                if (codeIndex >= 0)
                {
                    sum += priceArray[salesman][codeIndex + 3];
                }
            }
            //Console.WriteLine("Sum is " + sum);
            return sum;
        }

        static sbyte[][] PopulateCodeArray(List<sbyte>[] priceArray)
        {
            sbyte[][] codesArray = new sbyte[priceArray.Length][];
            for (int i = 0; i < priceArray.Length; i++)
            {
                codesArray[i] = GetSbytesCodes(priceArray[i]);
            }
            return codesArray;
        }

        static sbyte[] FillCodeAtNPrice(sbyte[] codes, int n)
        {
            var arr = new sbyte[4];
            for (int i = 0; i < 4; i++)
            {
                arr[i] = codes[n - i];
            }
            Array.Reverse(arr);
            return arr;
        }

        static sbyte[] GetSbytesCodes(List<sbyte> priceList)
        {
            var arr = new sbyte[priceList.Count];
            arr[0] = -1; // 
            for (int i = 1; i < priceList.Count; i++)
            {
                arr[i] = (sbyte)(priceList[i] - priceList[i - 1]);
            }
            return arr;
        }

        static sbyte Price(string buy)
        {
            string buyStr = buy.ToString();
            sbyte price = sbyte.Parse(buyStr[buyStr.Length - 1].ToString());
            return price;
        }

        static long Secret(long input)
        {
            long secret = input * 64;
            secret = Mix(input, secret);
            secret = Prune(secret);


            input = secret;
            secret /= 32;
            secret = Mix(input, secret);
            secret = Prune(secret);

            input = secret;
            secret *= 2048;
            secret = Mix(input, secret);
            secret = Prune(secret);
            return secret;
        }

        static long Mix(long input, long secret)
        {
            return input ^ secret;
        }

        static long Prune(long input)
        {
            return input % 16777216;
        }
    }
}