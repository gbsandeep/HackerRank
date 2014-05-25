using System;
using System.Linq;

namespace ConsoleApplication1 {
    class AngryChildren {
        public static void Main() {
            var n = long.Parse(Console.ReadLine());
            var k = long.Parse(Console.ReadLine());
            var bst = new BinarySearchTree();
            for(long index = 0; index < n; index++) {
                bst.Add(long.Parse(Console.ReadLine()));
            }
            var array = bst.ToArray;
            var unfairness = long.MaxValue;
            for(long i = 0, j = k - 1; i < n - 1 && j < n - 1; i += 1, j += 1) { 
                var newUnfairness = array[j] - array[i];
                if(newUnfairness <= unfairness) unfairness = newUnfairness;
            }
            //Console.WriteLine(string.Join(", ", bst.ToArray.Select(x => x.ToString()).ToArray()));
            Console.WriteLine(unfairness);
            Console.ReadLine();
        }

    }

    class Node {
        public long Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node(long value) {
            this.Value = value; 
        }
    }
    class BinarySearchTree {
        public Node Root { get; set; }
        public BinarySearchTree() {
            NodeCount = 0;
        }
        public void Add(long value) {
            var node = new Node(value);
            var parentNode = FindParentNode(this.Root, node.Value);
            if(parentNode == null) {
                Root = node;
            } else {
                if(parentNode.Value < value) parentNode.RightChild = node;
                else parentNode.LeftChild = node;
            }
            NodeCount += 1;
        }

        private Node FindParentNode(Node node, long inputValue) {
            if(node == null) return null;
            if(node.Value < inputValue) {
                if(node.RightChild == null) return node;
                return FindParentNode(node.RightChild, inputValue);
            } else if(node.Value >= inputValue) {
                if(node.LeftChild == null) return node;
                return FindParentNode(node.LeftChild, inputValue);
            }
            return null;
        }

        public long[] ToArray { get { 
            var array = new long[NodeCount];
            this.count = 0;
            InOrder(this.Root, array);
            return array;
        } }
        private long NodeCount;
        private long count;
        public void InOrder(Node node, long[] array) {
            if(node == null) return;
            InOrder(node.LeftChild, array);
            array[count++] = node.Value;
            InOrder(node.RightChild, array);
        }
    }
}
