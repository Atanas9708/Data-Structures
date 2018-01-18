using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
   public static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            stack.Push(numbers[i]);
        }

        Console.WriteLine(string.Join(" ", stack));
    }
}

