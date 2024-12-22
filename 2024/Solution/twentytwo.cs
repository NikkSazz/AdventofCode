using System;
using System.Collections.Generic;

namespace AdventSazonov._2024.Solution
{
    internal class TwentyTwo
    {
        internal static void Solution(string[] input)
        {
            /*
             *      While doing part one, we have the price info
             *  from each of 2000 Secrets of every buyer
             *  Then find top three highest prices, and thier code (four digit num)
             *  
             *  make get highest three value codes method
             *  and a get code method
             *  
             *  then for each buyer in input
             */
            int generate = 10;  //  Test to 2000
            long sum = 0;
            List<sbyte> priceList = new List<sbyte>();
            List<sbyte>[] priceArray = new List<sbyte>[input.Length];
            foreach (string buyerzzz in input)
            {
                priceList.Clear();
                string buyer = "123";   //  Test
                priceList.Add(Price(buyer));
                var test = Price(buyer);
                long buy = long.Parse(buyer);
                for (var i = 0; i < generate; i++)
                {
                    buy = Secret(buy);
                    priceList.Add(Price(buy.ToString()));
                }
                Console.WriteLine($"{buyer}: {buy}");
                sum += buy;
                priceList.RemoveAt(priceList.Count - 1); // Remove last value, as the first one the spot
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var b in priceList)
                {
                    Console.WriteLine("List: " + b.ToString());
                }
                break;  //Test
            }
            Console.WriteLine($"\nDay Twenty One Part One: {sum}");
        }

        static sbyte Price(string buy)
        {
            string buyStr = buy.ToString();
            sbyte price = sbyte.Parse(buyStr[buyStr.Length - 1].ToString());
            Console.WriteLine($"buyStr: {buyStr}, price: {price}");
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
        /*
         * go through each buyer and use thier 4 digit code to determine value
         * 
         */
    }
}
