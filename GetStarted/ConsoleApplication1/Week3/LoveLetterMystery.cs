using System;
using System.IO;
using System.Text;

namespace ConsoleApplication1.Week3 {
    class LoveLetterMystery {
        public static void Main() {
            var numberOfTests = long.Parse(Console.ReadLine());
            string[] testStrings = new string[numberOfTests];
            for (int index = 0; index < numberOfTests; index++) {
                testStrings[index] = Console.ReadLine();
            }

            for (int index = 0; index < numberOfTests; index++) {
                Console.WriteLine(ReduceToPaliandrome(testStrings[index]));
            }
            Console.ReadLine();
        }

        private static int ReduceToPaliandrome(string input) {
            var charArr = input.ToCharArray();
            var operations = 0;
            if (input.Length > 0) {
                for (int index = 0; index <= (input.Length - 1) / 2; index++) {
                    operations += ReduceToPaliandrome(charArr[index], charArr[input.Length - 1 - index]);
                }
            }
            return operations;
        }

        private static int ReduceToPaliandrome(char input1, char input2) {
            return input1 > input2 ? input1 - input2 : input2 - input1;
        }
    }
}
