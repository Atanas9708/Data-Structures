using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int start = numbers[0];
        int end = numbers[1];

        if (end < start)
        {
            return;
        }

        Queue<Item> queue = new Queue<Item>();
        queue.Enqueue(new Item(start));

        while (queue.Count > 0)
        {
            Item current = queue.Dequeue();

            if (current.Value == end)
            {
                PrintSequence(current);
                return;
            }
            else if (current.Value > end)
            {
                continue;
            }

            queue.Enqueue(new Item(current.Value + 1, current));
            queue.Enqueue(new Item(current.Value + 2, current));
            queue.Enqueue(new Item(current.Value * 2, current));

        }


    }

    static void PrintSequence(Item start)
    {
        LinkedList<int> result = new LinkedList<int>();
        Item current = start;

        while (current != null)
        {
            result.AddFirst(current.Value);
            current = current.Prev;
        }

        Console.WriteLine(string.Join(" -> ", result));
    }

    private class Item
    {
        public int Value { get; set; }
        public Item Prev { get; set; }

        public Item(int value, Item prev = null)
        {
            this.Value = value;
            this.Prev = prev;
        }
    }
}

