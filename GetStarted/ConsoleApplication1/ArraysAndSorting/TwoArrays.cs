using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication1 {
    class TwoArrays {
        public static void MainTwoArrays() {
            var numberOfTestCases = int.Parse(Console.ReadLine());
            var numberOfElements = new int[numberOfTestCases];
            var threshold = new int[numberOfTestCases];
            var firstArray = new List<int>[numberOfTestCases];
            var secondArray = new List<int>[numberOfTestCases];
            for(int index = 0; index < numberOfTestCases; index++) {
                var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                numberOfElements[index] = input[0];
                threshold[index] = input[1];
                firstArray[index] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                secondArray[index] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            }
            for(int index = 0; index < numberOfTestCases; index++) {
                firstArray[index].Sort();
                secondArray[index].Sort();
                secondArray[index].Reverse();
                bool success = true;
                for(int i = 0; i < numberOfElements[index]; i++) {
                    if(firstArray[index][i] + secondArray[index][i] < threshold[index]) {
                        success = false;
                        break;
                    }
                }
                Console.WriteLine(success ? "YES" : "NO");
            }
            Console.ReadLine();
        }

    }
}
