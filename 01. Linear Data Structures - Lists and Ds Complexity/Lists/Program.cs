using System;

public class Program
{
    public static void Main()
    {
        ArrayList<int> arr = new ArrayList<int>();
        arr.Add(4);
        arr.Add(5);
        arr.Add(6);

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(arr.Capacity);
        Console.WriteLine(arr.Count);
    }
}
