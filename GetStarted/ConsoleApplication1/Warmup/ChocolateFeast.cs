using System;
using System.Diagnostics;

namespace ConsoleApplication1 {
    public class Program {
        public static void ChocolateFeastMain(string[] args) {
            long testCount = long.Parse(Console.ReadLine());
            long[] amount = new long[testCount];
            long[] costPerChocolate = new long[testCount];
            long[] wrapperExchangeCount = new long[testCount];
            for (int count = 0; count < testCount; count++) {
                var input = Console.ReadLine();
                var inputs = input.Split(' ');
                if(inputs.Length > 2) {
                    amount[count] = long.Parse(inputs[0]);
                    costPerChocolate[count] = long.Parse(inputs[1]);
                    wrapperExchangeCount[count] = long.Parse(inputs[2]);
                }
            }
            for (int count = 0; count < testCount; count++) {
                Console.WriteLine(ChocolateFeast(amount[count], costPerChocolate[count], wrapperExchangeCount[count]));
            }
            Console.ReadLine();
        }

        private static long ChocolateFeast(long amount, long costPerChocolate, long wrapperExchangeCount) {
            var totalChocolates = (long) Math.Floor((double)amount / (double)costPerChocolate);
            var wrappers = totalChocolates;
            while (wrappers >= wrapperExchangeCount) {
                var newChocolates = (long) Math.Floor((double)wrappers / (double)wrapperExchangeCount);
                totalChocolates += newChocolates;
                wrappers = (wrappers % wrapperExchangeCount) + newChocolates;
            }
            return totalChocolates;
        }
    }
}


/*
        public static void Main(string[] args) {
            long testCount = long.Parse(Console.ReadLine());
            long[] inputs = new long[testCount];
            for (int count = 0; count < testCount; count++) {
                inputs[count] = long.Parse(Console.ReadLine());
            }
            for (int count = 0; count < testCount; count++) {
                Console.WriteLine(HalloweenChocolateBar(inputs[count]));
            }
            Console.ReadLine();
        }
 
         //Console.WriteLine(HalloweenChocolateBar(inputs[count]));
        private static long HalloweenChocolateBar(long n) {
            var i = (n & 1) == 1 ? (n - 1) / 2 : n / 2;
            var j = n - i;
            return i * j;
        }

        //                Console.WriteLine(UtopianTree(inputs[count]));
        static long UtopianTree(long n) {
            if (n == 0) return 1;
            return (n & 1) == 1 ? (2 * UtopianTree(n - 1)) : (UtopianTree(n - 1) + 1);
        }

 */