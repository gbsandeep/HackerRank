using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Miscellaneous {
    public class RangeToMaximizeProfit {
        public static void MainRangeToMaximizeProfit(string[] args) {
            string input;
            while ((input = Console.ReadLine().Trim().ToUpper()) != "") {
                var arr = input.Split(' ').Select(a => int.Parse(a)).ToArray();
                Console.WriteLine(maxRange(arr));
            }
        }

        private static int maxRange(int[] arr) {
            var maxValue = 0;
            for (int i = 0; i < arr.Length; i++) {
                maxValue = Max(maxValue, arr[i]);
            }
            return maxValue;
        }

        private static int Max(int maxValue, int p) {
            return maxValue > p ? maxValue : p;
        }
    }
}
