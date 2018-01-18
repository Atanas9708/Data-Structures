using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        Dictionary<int, int> output = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (!output.ContainsKey(numbers[i]))
            {
                output[numbers[i]] = 1;
            }
            else
            {
                output[numbers[i]]++;
            }
        }

        foreach (var kvp in output)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
        }
    }
}
