using System;
using System.Linq;

namespace ConsoleApplication1 {
    class GemElements {
        public static void Main() {
            var numberOfRocks = long.Parse(Console.ReadLine());
            int[] gems = new int[26];
            for (int index = 0; index < numberOfRocks; index++) {
                string input = Console.ReadLine();
                var distinctElements = input.ToCharArray().Distinct();
                foreach (var element in distinctElements) {
                    gems[element - 97]++;
                }
            }
            int count = 0;
            foreach (var gem in gems) {
                if (gem == numberOfRocks) count++;
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
