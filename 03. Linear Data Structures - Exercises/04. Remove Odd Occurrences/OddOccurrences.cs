using System;
using System.Collections.Generic;
using System.Linq;

public class OddOccurrences
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        Dictionary<int, int> result = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (!result.ContainsKey(numbers[i]))
            {
                result[numbers[i]] = 1;
            }
            else
            {
                result[numbers[i]]++;
            }
        }

        List<int> filteredNumbers = result
            .Where(x => x.Value % 2 == 0)
            .ToDictionary(k => k.Key, v => v.Value)
            .Keys
            .ToList();

        List<int> outputNumbers = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (filteredNumbers.Contains(numbers[i]))
            {
                outputNumbers.Add(numbers[i]);
            }
        }

        Console.WriteLine(string.Join(" ", outputNumbers));
    }
}

