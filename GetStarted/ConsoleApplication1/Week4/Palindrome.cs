using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Search {
    class Palindrome {
        static void MainPalindrome(String[] args) {
            var n = uint.Parse(Console.ReadLine());
            var inputs = new List<string>();
            for (int i = 0; i < n; i++) {
                inputs.Add(Console.ReadLine());
            }
            for (int i = 0; i < n; i++) {
                Console.WriteLine(GetPalindromeOffset(inputs[i]));
            }
            Console.ReadLine();
        }

        private static int GetPalindromeOffset(string input) {
            var offset = PalindromeOffset(input);
            if (offset != -1) {
                // wrong pick, correct it
                if (input[offset + 1] != input[input.Length - offset - 1])
                    offset = input.Length - offset - 1;
            }
            return offset;
        }

        private static int PalindromeOffset(string input) {
            if (input == null || input.Length == 1) return -1;
            var size = input.Length;
            for (int i = 0; i < size / 2; i++) {
                if (input[i] != input[size - i - 1])
                    return i;
            }
            return -1;
        }
    }
}
