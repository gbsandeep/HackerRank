using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace ConsoleApplication1 {
    class UserName {
        public static void MainUserName() {
            var n = long.Parse(Console.ReadLine());
            var inputs = new string[n];
            for(long i = 0; i < n; i++ ) {
                inputs[i] = Console.ReadLine();
            }
            for(long i = 0; i < n; i++) {
                Console.WriteLine(IsValidUserName(inputs[i]));
            } 
            Console.ReadLine();
        }

        private static string IsValidUserName(string p) {
            var regex = new Regex(@"^[_\.][0-9]+[a-z]*[_]?$", RegexOptions.IgnoreCase);
            return regex.IsMatch(p) ? "VALID" : "INVALID";
        }
    }
}
