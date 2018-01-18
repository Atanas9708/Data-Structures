using System;

class Program
{
    static void Main()
    {
        ReversedList<int> list = new ReversedList<int>();

        list.Add(5);
        list.Add(2);

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        Console.WriteLine(list.Count);
        Console.WriteLine(list.Capacity);
    }
}

