using System;
namespace ConsoleApplication1 {
    class LexicalDisplay {
        public static void MainLexicalDisplay() {
            var n = long.Parse(Console.ReadLine());
            var inputs = new string[n];
            for(long i = 0; i < n; i++ ) {
                var length = long.Parse(Console.ReadLine());
                inputs[i] = Console.ReadLine();
            }
            for(long i = 0; i < n; i++) {
                GenerateLexicalOrder(inputs[i]);
            } 
            Console.ReadLine();
        }

        static void GenerateLexicalOrder(string p) {
            if(p.Length == 0) { 
                Console.WriteLine(); 
                return; 
            }
            var arrayLength = (long)Math.Pow(2, p.Length);
            array = new string[arrayLength];
            counter = 0;
            GenerateLexicalOrderRecursive(p, 0);
            for(long index = arrayLength - 1; index >= 0; index--) {
                if(!string.IsNullOrEmpty(array[index]))
                    Console.WriteLine(array[index]);
            }
        }
        static string[] array;
        static long counter;
        private static void GenerateLexicalOrderRecursive(string input, int index) {
            if(index == input.Length - 1) { 
                array[counter++] = input[index].ToString();
                return;
            }
            GenerateLexicalOrderRecursive(input, index + 1);
            var counterSoFar = counter;
            for(var i = 0; i < counterSoFar; i++) {
                array[counter++] = input[index].ToString() + array[i];
            }
            array[counter++] = input[index].ToString();
        }
    }
}
