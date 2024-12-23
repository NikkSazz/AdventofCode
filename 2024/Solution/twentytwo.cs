using System;
using System.Collections.Generic;

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
        public static void Solution(string[] inputtesting)
        {
            string[] input =
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
                priceArray[arrIndex] = priceList;
                arrIndex++;
            }

            Console.WriteLine($"\nDay Twenty One Part One: {sum}");
            int bananaMax = PartTwo(priceArray);
            Console.WriteLine($"\nDay Twenty One Part Two: {bananaMax}");
        }

        static int PartTwo(List<sbyte>[] priceArray)
        {
            //using the term div, as in derive for the changes in price over each secret. the four digit number
            int maxBananna = -1;
            sbyte[][] codesArray = new sbyte[priceArray.Length][];
            // Populate codesArray
            codesArray = PopulateCodeArray(priceArray);

            for (int salesman = 0; salesman < priceArray.Length; salesman++)
            {
                // To distinguish salesmen
                Console.ForegroundColor = salesman % 2 == 0 ? ConsoleColor.Red : ConsoleColor.Green;

                int salesmanMaxIndex = 4;
                int salesmanMax = priceArray[salesman][salesmanMaxIndex];
                Console.WriteLine($"Initmax: {salesmanMax} at {salesmanMaxIndex}");

                for (int i = 4; i < priceArray[salesman].Count; i++)
                {
                    sbyte cmpForHighestVal = priceArray[salesman][i];
                    if (salesmanMax < cmpForHighestVal)
                    {
                        Console.WriteLine($"Changed Highest Value of {salesmanMax} at {salesmanMaxIndex} to {cmpForHighestVal} at {i}");
                        salesmanMaxIndex = i;
                        salesmanMax = cmpForHighestVal;
                    }
                }

                var codeAtMax = FillCodeAtNPrice(codesArray[salesman], salesmanMaxIndex);
                PrintCode(codeAtMax, salesmanMax);
                maxBananna = Math.Max(maxBananna, GoThroughEverySalesman(codeAtMax, codesArray, priceArray));
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            return maxBananna;
        }

        static void PrintCode(sbyte[] code, int val)
        {
            Console.WriteLine($"Code for {val} is {code[0]}, {code[1]}, {code[2]}, {code[3]}");
        }

        static int GetCodeIndex(sbyte[] code, sbyte[][] codesArray)
        {
            return -1;
        }

        static int GoThroughEverySalesman(sbyte[] code, sbyte[][] codesArray, List<sbyte>[] priceArray)
        {
            int sum = 0;
            // Goes through each salesmans prices, and gets the price at the code Index
            // If one of the salesmen dont have such code Index. Return -1
            for (int salesman = 0; salesman < priceArray.Length; salesman++)
            {
                int codeIndex = GetCodeIndex(code, codesArray);
                if(codeIndex >= 0)
                {

                }
            }


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