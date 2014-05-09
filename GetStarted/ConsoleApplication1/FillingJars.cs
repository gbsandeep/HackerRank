using System;
using System.IO;

namespace ConsoleApplication1 {
    class FillingJars {
        public static void MainFillingJars(string[] args) {
            //Console.SetIn(new StreamReader(args[0]));
            var numberOfJarsAndOperations = Console.ReadLine().Split(' ');
            var numberOfJars = long.Parse(numberOfJarsAndOperations[0]);
            var operationCount = long.Parse(numberOfJarsAndOperations[1]);
            long[] index1 = new long[operationCount];
            long[] index2 = new long[operationCount];
            long[] candyCount = new long[operationCount];

            for (int count = 0; count < operationCount; count++) {
                var indexWithCandyCount = Console.ReadLine().Split(' ');
                if (indexWithCandyCount.Length == 3) {
                    index1[count] = long.Parse(indexWithCandyCount[0]);
                    index2[count] = long.Parse(indexWithCandyCount[1]);
                    candyCount[count] = long.Parse(indexWithCandyCount[2]);
                }
            }
            long sum = 0;
            for (int index = 0; index < operationCount; index++) {
                sum += (index2[index] - index1[index] + 1) * candyCount[index];
            }
            Console.WriteLine(Math.Floor((decimal)sum / (decimal)numberOfJars));
            Console.ReadLine();
        }
    }
}
