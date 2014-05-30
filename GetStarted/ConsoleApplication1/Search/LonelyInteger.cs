using System;
using System.Linq;

namespace ConsoleApplication1.Search {
    class LonelyInteger {
        static void Main(String[] args) {
            Console.ReadLine();
            Console.WriteLine(Console.ReadLine()
                .Split(new Char[] { ' ', '\t', '\n' })
                .ToList()
                .Select(s => Convert.ToInt32(s))
                .GroupBy(v => v)
                .Select(value => new { Value = value.Key, Count = value.Count() })
                .Where(v => v.Count == 1)
                .FirstOrDefault()
                .Value);
            Console.ReadLine();
        }
    }
}
