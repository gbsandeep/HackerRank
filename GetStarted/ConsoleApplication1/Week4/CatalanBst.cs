using System;
using System.Linq;

namespace ConsoleApplication1.Week4 {
    class CatalanBst {
        static long[] catalanCache = new long[12000];
        static long[] factorialCache = new long[40000];
        static long modValue = (long)(Math.Pow(10, 9) + 9);
        static void MainCatalanBst(String[] args) {
            var inputSize = int.Parse(Console.ReadLine());
            var output = new long[inputSize];

            for (int i = 0; i < inputSize; i++) {
                var input = int.Parse(Console.ReadLine());
                output[i] = GetSum(input);
                //output[i] = factorial(input);
            }
            for(int i=0;i<inputSize;i++){
                Console.WriteLine(output[i]);
            }
            Console.ReadLine();
        }

        private static long GetSum(int input) {
            long sum = CatalanProduct(input);
            for(int i = input - 1; i > 0; i--) {
                sum += ModValue(Combination(input, i) * CatalanProduct(i));
            }
            return sum;
        }

        private static long Combination(int n, int r) {
            if(r <= 1 || n == 1) return n;
            return ModValue(factorial(n) / ModValue((factorial(n-r) * factorial(r))));
        }

        private static long CatalanProduct(int input) {
            if(catalanCache[input] > 0) return catalanCache[input];
            catalanCache[input] = ModValue(factorial(2 * input) / ModValue((factorial(input + 1) * factorial(input))));
            return catalanCache[input];
        }

        private static long factorial(int input) {
            if(factorialCache[input] > 0) return factorialCache[input];
            if(input == 1) return 1;
            factorialCache[input] = ModValue(input * factorial(input - 1));
            return factorialCache[input];
        }

        private static long ModValue(long value) {
            return value % modValue;
        }
    }
}
