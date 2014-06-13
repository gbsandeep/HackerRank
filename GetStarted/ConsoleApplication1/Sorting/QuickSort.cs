using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Sorting {
    public class QuickSort {
        public static void MainQuickSort(string[] args) {
            string input;
            while ((input = Console.ReadLine().Trim().ToUpper()) != "") {
                var arr = input.Split(' ').Select(a => int.Parse(a)).ToArray();
                quickSort(arr, (int)0, (int)arr.Length - 1);
                Console.WriteLine(string.Join(" ", arr));
            }
        }

        private static void quickSort(int[] arr, int left, int right) {
            if (left < right) {
                var partitionIndex = partition(arr, left, right);
                quickSort(arr, left, partitionIndex - 1);
                quickSort(arr, partitionIndex + 1, right);
            }
        }

        private static int partition(int[] arr, int left, int right) {
            var curIndex = left;
            var tempPivot = left;
            while (curIndex < right) {
                if (arr[curIndex] <= arr[right]) {
                    swap(arr, curIndex, tempPivot);
                    tempPivot += 1;
                }
                curIndex += 1;
            }
            swap(arr, tempPivot, right);
            return tempPivot;
        }

        private static void swap(int[] arr, int first, int second) {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
