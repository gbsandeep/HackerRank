using System;
using System.IO;

namespace ConsoleApplication1 {
    class FibonacciNumbers {
        public static void MainFibonacciNumbers() {
            var numberOfTests = long.Parse(Console.ReadLine());
            long[] testNumbers = new long[numberOfTests];
            long maxNumber = 0;
            for (int index = 0; index < numberOfTests; index++) {
                testNumbers[index] = long.Parse(Console.ReadLine());
                if (testNumbers[index] > maxNumber) maxNumber = testNumbers[index];
            }

            // Calculate Fibonacci numbers
            long[] fibonacci = new long[(int)Math.Ceiling(Math.Sqrt(maxNumber)) + 100];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            long i = 2;
            while (fibonacci[i - 1] < maxNumber) {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                i += 1;
            }

            for (int index = 0; index < numberOfTests; index++) {
                Console.WriteLine(binarySearch(fibonacci, 0, i - 1, testNumbers[index]) ? "IsFibo" : "IsNotFibo");
            }
            Console.ReadLine();
        }

        private static bool binarySearch(long[] fibonacci, long startIndex, long endIndex, long p) {
            if (startIndex > endIndex || startIndex < 0) return false;
            var middle = (startIndex + endIndex) / 2;
            if (fibonacci[middle] == p) return true;
            if (fibonacci[middle] > p) return binarySearch(fibonacci, startIndex, middle - 1, p);
            if (fibonacci[middle] < p) return binarySearch(fibonacci, middle + 1, endIndex, p);
            return false;
        }
    }
}
