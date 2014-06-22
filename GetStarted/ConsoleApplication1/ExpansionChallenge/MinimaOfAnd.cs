using System;
using System.Linq;

namespace ConsoleApplication1.ExpansionChallenge {
    public class MinimaOfAnd {
        public static void MainMinimaOfAnd(string[] args) {
            var numberOfTestCases = uint.Parse(Console.ReadLine());
            long [] result = new long[numberOfTestCases];
            for(long i = 0; i < numberOfTestCases; i++){
                var numberOfElements = Console.ReadLine();
                var input = Console.ReadLine().Split(' ').Select(ele => long.Parse(ele)).ToArray();
                if(input.Length > 0) {
                    result[i] = input[0];
                }
                if(input.Length > 1) {
                    for(long j = 1; j < input.Length; j++) {
                        result[i] &= input[j];
                        if(result[i] == 0) break;
                    }
                }
            }
            for(long i = 0; i < numberOfTestCases; i++) {
                Console.WriteLine(result[i]);
            }
            Console.ReadLine();
        }

    }
}
