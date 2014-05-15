using System;
using System.IO;
using System.Text;

namespace ConsoleApplication1 {
    class FactorSherlockHolmes {
        public static void MainFactorSherlockHolmes() {
            var numberOfTests = long.Parse(Console.ReadLine());
            long[] testNumbers = new long[numberOfTests];
            for (int index = 0; index < numberOfTests; index++) {
                testNumbers[index] = long.Parse(Console.ReadLine());
            }

            for (int index = 0; index < numberOfTests; index++) {
                Console.WriteLine(factors(testNumbers[index]));
            }
            Console.ReadLine();
        }

        private static string factors(long p) {
            long fiveFactor = 3;
            long threeFactor = 5;
            for (long index = 0; threeFactor * index <= p; index++ ) {
                fiveFactor = p - threeFactor * index;
                if (fiveFactor % 3 == 0) {
                    return buildstring(threeFactor * index, fiveFactor);
                }
            }
            return "-1";
        }

        private static string buildstring(long threeFactor, long fiveFactor) {
            StringBuilder s = new StringBuilder();
            for (long index = 0; index < fiveFactor; index++) s.Append("5");
            for (long index = 0; index < threeFactor; index++) s.Append("3");
            return s.ToString();
        }
    }
}
