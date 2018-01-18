using System;

public class LinkedStack<T>
{
    private class Node<T>
    {
        public T Value;
        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
    }

    
    private Node<T> firstNode;
    public int Count { get; private set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }


        T element = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;

        return element;
        
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        Node<T> current = this.firstNode;

        int index = 0;

        while (current != null)
        {
            array[index] = current.Value;
            current = current.NextNode;
            index++;
        }

        return array;
    }
}


public class Program
{
    public static void Main()
    {
        LinkedStack<int> stack = new LinkedStack<int>();

        stack.Push(4);
        stack.Push(5);
        stack.Push(6);

        Console.WriteLine(string.Join(" ", stack.ToArray()));
        Console.WriteLine(stack.Pop());
    }
}

