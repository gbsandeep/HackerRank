using System;
using System.Linq;
namespace ConsoleApplication1 {
    class MarkAndToys {
        public static void MainMarkAndToys() {
            var input = Console.ReadLine().Split(' ');
            var numberOfToys = long.Parse(input[0]);
            var knapSackCapacity = long.Parse(input[1]);
            var toys = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList(); ;
            toys.Sort();
            long count = 0;
            for(int index = 0; index < toys.Count; index++) {
                if(toys[index] < knapSackCapacity) {
                    knapSackCapacity -= toys[index];
                    count += 1;
                } else break;
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

    }
}
