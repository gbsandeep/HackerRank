using System;
using System.Linq;

namespace ConsoleApplication1.Week4 {
    class AlgoCrushMax {
        static void MainAlgoCrushMax(String[] args) {
            var input = (Console.ReadLine()).Split(' ');
            var size = int.Parse(input[0]);
            var querySize = long.Parse(input[1]);
            var arr = new long[size];

            for (long i = 0; i < querySize; i++) {
                var query = Console.ReadLine().Split(' ');
                int rangeBegin = int.Parse(query[0]);
                int rangeEnd   = int.Parse(query[1]);
                long value      = long.Parse(query[2]);
                for (long index = rangeBegin - 1; index < rangeEnd; index++) {
                    arr[index] += value;
                }
            }
            Console.WriteLine(arr.Max());
            Console.ReadLine();
        }
    }
}
