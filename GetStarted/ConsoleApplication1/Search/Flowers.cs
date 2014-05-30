using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Search {
    class Flowers {
        static void MainFlowers(String[] args) {
            int K;
            string NK = Console.ReadLine();
            string[] NandK = NK.Split(new Char[] { ' ', '\t', '\n' });
            K = Convert.ToInt32(NandK[1]);

            var C = new List<long>();

            string numbers = Console.ReadLine();
            string[] split = numbers.Split(new Char[] { ' ', '\t', '\n' });

            foreach(string s in split) {
                if(s.Trim() != "") {
                    C.Add(Convert.ToInt32(s));
                }
            }
            C.Sort();
            var result = CalculateMinimumCost(C, K);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static long CalculateMinimumCost(List<long> C, int K) {
            long result = 0, loop = 0;
            for(int index = C.Count - 1; index >= 0; index -= K ) {
                loop += 1;
                for(int i = index; i > (index - K) && (i >= 0); i--) {
                    result += (loop * C[i]);
                }
            }
            return result;
        }
    }
}
