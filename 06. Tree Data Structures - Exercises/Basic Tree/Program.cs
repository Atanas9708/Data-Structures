using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        int numberOfNodes = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfNodes - 1; i++)
        {
            int[] nodes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int parent = nodes[0];
            int child = nodes[1];

            if (!tree.ContainsKey(parent))
            {
                tree.Add(parent, new Tree<int>(parent));
            }

            if (!tree.ContainsKey(child))
            {
                tree.Add(child, new Tree<int>(child));
            }

            Tree<int> parentNode = tree[parent];
            Tree<int> childNode = tree[child];
            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;

        // 01. Console.WriteLine(root.Value);
        // 02. root.Print();
        // 03. LeafNodes(tree);
        // 04. MiddleNodes(tree);
        // 05. DeepestNode(root);
        // 06. LongestPath(tree, root);

        /* 07.
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Path of sum {sum}: ");
        DFS(root, sum);
        */

        /* 08. 
         int sum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {sum}:");
        Subtree(root, sum);
        */
    }

    public static void LeafNodes(Dictionary<int, Tree<int>> tree)
    {
        List<int> result = new List<int>();

        foreach (var node in tree.Values)
        {
            if (node.Children.Count == 0)
            {
                result.Add(node.Value);
            }
        }

        result.Sort();

        Console.WriteLine($"Leaf nodes: {string.Join(" ", result)}");
    }

    public static void MiddleNodes(Dictionary<int, Tree<int>> tree)
    {
        List<int> result = new List<int>();

        foreach (var node in tree.Values)
        {
            if (node.Parent != null && node.Children.Count != 0)
            {
                result.Add(node.Value);
            }
        }

        result.Sort();

        Console.WriteLine($"Middle nodes: {string.Join(" ", result)}");
    }

    public static void DeepestNode(Tree<int> root)
    {

        Tree<int> currentNode = root;

        if (currentNode.Children.Count == 0)
        {
            Console.WriteLine($"Deepest node: {currentNode.Value}");
            return;
        }

        while (currentNode.Children.Count > 0)
        {
            currentNode = currentNode.Children[0];
        }

        Console.WriteLine($"Deepest node: {currentNode.Value}");
    }

    public static void LongestPath(Dictionary<int, Tree<int>> tree, Tree<int> root)
    {
        List<Tree<int>> leafs = tree.Values.Where(x => x.Children.Count == 0).ToList();
        Dictionary<Tree<int>, int> storedLeafs = new Dictionary<Tree<int>, int>();

        foreach (var leaf in leafs)
        {
            Leaf currentLeaf = Traverse(leaf, root);
            storedLeafs.Add(currentLeaf.Node, currentLeaf.Count);
        }

        List<int> result = new List<int>();

        foreach (var kvp in storedLeafs.OrderByDescending(x => x.Value).Take(1))
        {
            Tree<int> resultLeaf = kvp.Key;

            while (resultLeaf.Parent != null)
            {
                result.Add(resultLeaf.Value);

                resultLeaf = resultLeaf.Parent;
            }
        }
        result.Add(root.Value);
        result.Reverse();
        Console.WriteLine($"Longest path: {string.Join(" ", result)}");
    }

    public static void DFS(Tree<int> node, int sum, int curSum = 0)
    {
        curSum += node.Value;

        if (curSum == sum)
        {
            PrintPath(node);
        }

        foreach (var child in node.Children)
        {
            DFS(child, sum, curSum);
        }
    }

    public static int Subtree(Tree<int> root, int sum)
    {
        int totalSum = root.Value;
        
        foreach (var child in root.Children)
        {
            totalSum += Subtree(child, sum);
        }

        if (totalSum == sum)
        {
            List<int> result = new List<int>();
            EachInPreOrder(root, result);
            Console.WriteLine(string.Join(" ", result));
        }

        return totalSum;
    }

    public static void EachInPreOrder(Tree<int> child, List<int> result)
    {
        result.Add(child.Value);

        foreach (var node in child.Children)
        {
            EachInPreOrder(node, result);
        }
    }

    private static void PrintPath(Tree<int> currentNode)
    {
        List<int> result = new List<int>();

        while (true)
        {
            result.Add(currentNode.Value);

            if (currentNode.Parent == null)
            {
                break;
            }
            currentNode = currentNode.Parent;
        }

        result.Reverse();
        Console.WriteLine(string.Join(" ", result));
    }

    private static Leaf Traverse(Tree<int> leaf, Tree<int> root)
    {
        Tree<int> currentLeaf = leaf;

        int count = 0;
        Tree<int> startingLeaf = currentLeaf;

        while (currentLeaf.Parent != null)
        {
            count++;
            currentLeaf = currentLeaf.Parent;
        }

        return new Leaf(startingLeaf, count);
    }

    private class Leaf
    {
        public Tree<int> Node { get; set; }
        public int Count { get; set; }

        public Leaf(Tree<int> node, int count)
        {
            this.Node = node;
            this.Count = count;
        }
    }

    public class Tree<T>
    {
        public T Value { get; set; }
        public List<Tree<T>> Children { get; set; }
        public Tree<T> Parent { get; set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>(children);
        }

        public void Print(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}{this.Value}");
            foreach (var child in this.Children)
            {
                child.Print(indent + 2);
            }
        }
    }
}
