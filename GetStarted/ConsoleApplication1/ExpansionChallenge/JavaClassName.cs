using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.ExpansionChallenge {
    public class JavaClassName {
        public static void Main(string[] args) {
            var input = new StringBuilder();
            var line = string.Empty;
            do {
                line = Console.ReadLine();
                if(line != null) {
                    line = line.Trim().Replace(Environment.NewLine, string.Empty);
                    input.Append(line);
                }
            } while(line != null);
            Console.WriteLine(JavaClassName.FindClassName(input.ToString()));
            Console.ReadLine();
        }
        public static string FindClassName(string input) {
            var stack = new Stack<string>();
            //input = input.Replace(@"\/\*[\w]*\*\/$", string.Empty);
            input = input.Replace(@"/\*((?!\*/).)*\*/", string.Empty);
            input = input.Replace(@"\/\/[\w]*$", string.Empty);
            input = input.Replace("\t", " ");
            input = input.Replace("{", " { ");
            input = input.Replace("}", " } ");
            input = input.Replace(Environment.NewLine, string.Empty);
            var popString = string.Empty;
            var inputString = input.Split(' ').Where(s => {
                return
                    !string.IsNullOrEmpty(s);
            });
            bool mainFound = false;
            foreach(var str in inputString) {
                if(str.ToUpper().Contains("MAIN")) mainFound = true;
                if(mainFound || str.Contains('}')) {
                    do {
                        popString = stack.Pop();
                    }
                    while(!popString.Contains('{'));
                } else {
                    stack.Push(str);
                }
                if(mainFound) break;
            }
            return stack.Count == 0? string.Empty :
                stack.Pop();
        }
    }
    
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void ClassWithMainWithSpace() {
            string input = @"
import System;
                public class MyClass {
                    public void Main(string args[]) {
                        int a = 1;
                    }
                }
            ";
            Assert.AreEqual("MyClass", JavaClassName.FindClassName(input));
        }

        [TestMethod]
        public void ClassWithMainWithoutSpace() {
            string input = @"
import System;
                public class MyClass{
                    public void Main(string args[]) {
                        int a = 1;
                    }
                }
            ";
            Assert.AreEqual("MyClass", JavaClassName.FindClassName(input));
        }

        [TestMethod]
        public void DummyClassBefore() {
            string input = @"
import System;
                public class Dummy {

                }
                public class MyClass {
                    public void Main(string args[]) {
                        int a = 1;
                    }
                }
            ";
            Assert.AreEqual("MyClass", JavaClassName.FindClassName(input));
        }
        [TestMethod]
        public void DummyClassAfter() {
            string input = @"
import System;
                public class MyClass {
                    public void Main(string args[]) {
                        int a = 1;
                    }
                }
                public class Dummy {

                }
            ";
            Assert.AreEqual("MyClass", JavaClassName.FindClassName(input));
        }

        [TestMethod]
        public void JustClass() {
            string input = @"
                import System;
                public class MyClass {
                }
            ";
            Assert.AreEqual("MyClass", JavaClassName.FindClassName(input));
        }

        [TestMethod]
        public void NoClass() {
            string input = @"
                import System;
                class MyClass {
                }
            ";
            Assert.AreEqual(string.Empty, JavaClassName.FindClassName(input));
        }

        [TestMethod]
        public void ClassOnNewLine() {
            string input = @"
                

  public 		class
  AB {
}
            ";
            Assert.AreEqual("AB", JavaClassName.FindClassName(input));
        }

        [TestMethod]
        public void NonPublicClass() {
            string input = @"
/*
 * main method lies in second class.
 */

import java.io.*;
import java.util.*;
import java.util.regex.*;
import java.text.*;
import java.math.*;//}}}

class AGWrong
{
}

class AG {
    public static void main(String [] args) throws Exception
    {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        String [] tmp = br.readLine().split("" "");
        int n = Integer.parseInt(tmp[0]);
        int k = Integer.parseInt(tmp[1]);

        tmp = br.readLine().split("" "");
        Integer [] arr = new Integer[n];
        for(int i = 0; i < n; i++) {
            arr[i] = Integer.parseInt(tmp[i]);
        }
        Arrays.sort(arr);

        int cnt = 0;

        int idx = 0, jdx = 0;

        while(idx < n && jdx < n) {
            if(arr[jdx] - arr[idx] == k) {
                cnt++;
                idx++;
                jdx++;
            }
            else if(arr[jdx] - arr[idx] < k) {
                jdx++;
            }
            else {
                idx++;
            }
        }
        System.out.println(cnt);
    }
} ";
            Assert.AreEqual("AG", JavaClassName.FindClassName(input));
        }
    }
}
