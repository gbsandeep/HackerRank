using System;
namespace ConsoleApplication1 {
    class ConvertToPalindrome {
        public static void MainConvertToPalindrome() {
            var n = long.Parse(Console.ReadLine());
            var inputs = new string[n];
            for(long i = 0; i < n; i++) {
                inputs[i] = Console.ReadLine();
            }
            for(long i = 0; i < n; i++) {
                Console.WriteLine(CostToMakePalindrome(inputs[i]));
            }
            Console.ReadLine();
        }

        private static long CostToMakePalindrome(string p) {
            long result = 0;
            for(int i = 0; i < p.Length / 2; i++) {
                result += Math.Abs(p[i] - p[p.Length - i - 1]);
            }
            return result;
        }
    }
}
