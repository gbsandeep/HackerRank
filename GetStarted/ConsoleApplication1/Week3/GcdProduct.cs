using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication1.Week3 {
    class GcdProduct {
        public static void Main() {
            var inputs = Console.ReadLine().Split(' ');
            var input1 = ulong.Parse(inputs[0]);
            var input2 = ulong.Parse(inputs[1]);
            if(input1 > input2) { var temp = input2; input2 = input1; input1 = temp; }
            for(var i = input2; i >= 1; i--) {
                gcdCache[i.ToString() + "_1"] = 1;
                gcdCache[i.ToString() + "_" + i.ToString()] = i;
            }
            Console.WriteLine(GetGcdProduct(input1, input2));
            Console.ReadLine();
        }

        static Dictionary<string, ulong> gcdProductCache = new Dictionary<string, ulong>();
        static Dictionary<string, ulong> gcdCache = new Dictionary<string, ulong>();
        private static ulong GetGcdProduct(ulong input1, ulong input2) {
            if(input1 <= 1 || input2 <= 1) return 1;
            if(input1 > input2) { var temp = input2; input2 = input1; input1 = temp; }
            var gcdString = input1.ToString() + "_" + input2.ToString();
            if(gcdProductCache.ContainsKey(gcdString)) {
                return gcdProductCache[gcdString];
            }
            ulong subGcdProduct = 1;
            for(var i = input1; i > 0; i--) {
                subGcdProduct *= GetGcd(i, input2);
            }
            var product = (GetGcdProduct(input1, input2 - 1) * subGcdProduct)  % ((ulong)Math.Pow(10, 9) + 7);
            gcdProductCache.Add(gcdString, product);
            return gcdProductCache[gcdString];
        }

        private static ulong GetGcd(ulong input1, ulong input2) {
            if(input1 <= 1 || input2 <= 1) return 1;
            if(input1 < input2) { var temp = input1; input1 = input2; input2 = temp; }
            var gcdString = input1.ToString() + "_" + input2.ToString();
            if(gcdCache.ContainsKey(gcdString)) return gcdCache[gcdString];
            if(input1 % input2 == 0) {
                gcdCache.Add(gcdString, input2);
                return input2;
            }
            return GetGcd(input1 % input2, input2);
        }
    }
}
