using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(number);

        List<int> resultNums = new List<int>();

        while (resultNums.Count < 50)
        {
            int current = queue.Dequeue();
            resultNums.Add(current);
            queue.Enqueue(current + 1);
            queue.Enqueue(2 * current + 1);
            queue.Enqueue(current + 2);
        }

        Console.WriteLine(string.Join(", ", resultNums));
    }
}

