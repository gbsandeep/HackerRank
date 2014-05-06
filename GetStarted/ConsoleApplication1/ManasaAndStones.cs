using System;
using System.Collections.Generic;
namespace ConsoleApplication1 {
    class ManasaAndStones {
        public static void MainManasaAndStones(string[] args) {
            var testCount = long.Parse(Console.ReadLine());
            long[] numberOfSteps = new long[testCount];
            long[] a_s = new long[testCount];
            long[] b_s = new long[testCount];

            for (int count = 0; count < testCount; count++) {
                numberOfSteps[count] = long.Parse(Console.ReadLine());
                a_s[count] = long.Parse(Console.ReadLine());
                b_s[count] = long.Parse(Console.ReadLine());
            }
            for (int count = 0; count < testCount; count++) {
                var uniqueValues = new List<long>();
                for (var index = 0; index < numberOfSteps[count]; index++) {
                    var newVal = a_s[count] * index + b_s[count] * (numberOfSteps[count] - index - 1);
                    if (!uniqueValues.Exists(a => a == newVal)) uniqueValues.Add(newVal);
                }
                uniqueValues.Sort();
                foreach (var value in uniqueValues) {
                    Console.Write("{0} ", value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}

/*
static void Permutation(long[] arr, long level, long height, long a, long b) {
    if (level >= height) {
        // leaf node
        int index = 0;
        bool exists = false;
        foreach (var val in uniqueValues) {
            if (val == arr[height - 1]) { exists = true; break; }
        }
        if (!exists) uniqueValues.Add(arr[height - 1]);
        return;
    }
    arr[level] = arr[level - 1] + a;
    Permutation(arr, level + 1, height, a, b);
    arr[level] = arr[level - 1] + b;
    Permutation(arr, level + 1, height, a, b);
}
 * */