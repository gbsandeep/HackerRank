using System;

namespace ConsoleApplication1 {
    class FindReflectionPoint {
        public static void MainFindReflectionPoint() {
            var numberOfTests = long.Parse(Console.ReadLine());
            long[] outputX = new long[numberOfTests];
            long[] outputY = new long[numberOfTests];
            for (int index = 0; index < numberOfTests; index++) {
                var input = Console.ReadLine().Split(' ');
                long x1 = long.Parse(input[0]);
                long y1 = long.Parse(input[1]);
                long x2 = long.Parse(input[2]);
                long y2 = long.Parse(input[3]);
                outputX[index] = x2 + x2 - x1;
                outputY[index] = y2 + y2 - y1;
            }

            for (int index = 0; index < numberOfTests; index++) {
                Console.WriteLine(outputX[index] + " " + outputY[index]);
            }
            Console.ReadLine();
        }

    }
}
