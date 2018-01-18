using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int count = 1;
        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            int currentNum = numbers[i];
            int currentCount = 1;

            for (int j = i + 1; j < numbers.Count; j++)
            {
                int nextNum = numbers[j];

                if (currentNum == nextNum)
                {
                    currentCount++;
                    if (currentCount > count)
                    {
                        count = currentCount;
                        result.Clear();
                        result.Add(currentNum);
                    }
                }
                else
                {
                    break;
                }
            }
        }
        if (result.Count == 0)
        {
            Console.WriteLine(numbers[0]);
        }
        else
        {
            string resultStr = string.Empty;
            for (int i = 0; i < count; i++)
            {
                resultStr += $"{result[0]} ";
            }

            Console.WriteLine(resultStr.Trim());
            
        }
    }
}


