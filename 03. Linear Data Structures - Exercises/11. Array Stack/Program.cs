using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayStack<T>
{
    private T[] elements;
    public int Count { get; private set; }
    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
        this.Count = 0;
    }
    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            Array.Resize(ref this.elements, this.elements.Length * 2);
        }

        this.elements[this.Count++] = element;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.elements[this.Count - 1];

        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        LinkedList<T> newArray = new LinkedList<T>();

        for (int i = 0; i < this.Count; i++)
        {
            newArray.AddFirst(this.elements[i]);
        }

        return newArray.ToArray();
    }
}




public class Program
{
    public static void Main()
    {
        ArrayStack<int> stack = new ArrayStack<int>();

        stack.Push(5);
        stack.Push(6);

        Console.WriteLine(stack.Pop());

        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }
}

