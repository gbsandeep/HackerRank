using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Miscellaneous {
    public class StockProblem {
        public static void Main(string[] args) {
            string input;
            while ((input = Console.ReadLine().Trim().ToUpper()) != "") {
                var arr = input.Split(' ').Select(a => int.Parse(a)).ToArray();
                Console.WriteLine(maxProfit(arr, 0, arr.Length - 1));
            }
        }

        private static int maxProfit(int[] arr, int left, int right) {
            var leftProfit = maxProfit(arr, left, right / 2);
            //var leftMin = min(arr, left, right / 2);
            var rightProfit = maxProfit(arr, right / 2, right);
            //var rightMax = max(arr, right / 2, right);
            return 0;
        }

    }
}
