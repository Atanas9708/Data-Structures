using System;

public class CircularQueue<T>
{
    private T[] arr;
    private int head;
    private int tail;
    private const int DefaultCapacity = 4;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.arr = new T[capacity];
        this.head = 0;
        this.tail = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count == this.arr.Length)
        {
            this.Resize();
        }

        this.arr[this.tail] = element;
        this.tail = (this.tail + 1) % this.arr.Length;
        this.Count++;
    }

    private void Resize()
    {
        T[] newArray = new T[this.arr.Length * 2];
        this.CopyAllElements(newArray);
        this.arr = newArray;
        this.head = 0;
        this.tail = this.Count;
    }

    private void CopyAllElements(T[] newArray)
    {
        for (int i = 0; i < this.Count; i++)
        {
            int index = (i + this.head) % this.arr.Length;
            newArray[i] = this.arr[index];
        }

        this.head = 0;
        this.tail = this.Count;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.arr[this.head];
        this.head = (this.head + 1) % this.arr.Length;
        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        var newArray = new T[this.Count];
        this.CopyAllElements(newArray);
        return newArray;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
