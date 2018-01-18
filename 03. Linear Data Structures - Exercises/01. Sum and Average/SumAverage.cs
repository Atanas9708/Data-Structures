using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        double average = numbers.Average();
        Console.WriteLine($"Sum={numbers.Sum()}; Average={average:f2}");
    }
}

