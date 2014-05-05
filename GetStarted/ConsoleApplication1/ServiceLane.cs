using System;

namespace ConsoleApplication1 {
    class ServiceLane {
        public static void MainServiceLane(string[] args) {
            var serviceLaneTestCount = Console.ReadLine().Split(' ');
            var serviceLaneCount = long.Parse(serviceLaneTestCount[0]);
            var testCount = long.Parse(serviceLaneTestCount[1]);
            long[] serviceLane = new long[serviceLaneCount];
            long[] startingIndex = new long[testCount];
            long[] endingIndex = new long[testCount];
            var serviceLanes = Console.ReadLine().Split(' ');
            for (int count = 0; count < serviceLaneCount; count++) {
                serviceLane[count] = long.Parse(serviceLanes[count]);
            }

            for (int count = 0; count < testCount; count++) {
                var range = Console.ReadLine().Split(' ');
                if (range.Length == 2) {
                    startingIndex[count] = long.Parse(range[0]);
                    endingIndex[count] = long.Parse(range[1]);
                }
            }
            for (int count = 0; count < testCount; count++) {
                Console.WriteLine(GetServiceLane(serviceLane, startingIndex[count], endingIndex[count]));
            }
            Console.ReadLine();
        }

        static long GetServiceLane(long[] serviceLane, long startingIndex, long endingIndex) {
            long min = 99999;
            for (var index = startingIndex; index <= endingIndex; index++) {
                min = min > serviceLane[index] ? min = serviceLane[index] : min;
            }
            return min;
        }
    }
}
