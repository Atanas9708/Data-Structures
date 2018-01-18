using System;

public class LinkedQueue<T>
{

    private class QueueNode<T>
    {
        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        }
    }

    private QueueNode<T> head;
    private QueueNode<T> tail;
    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            QueueNode<T> oldTail = this.tail;
            this.tail = new QueueNode<T>(element);
            this.tail.PrevNode = oldTail;
            oldTail.NextNode = this.tail;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        T element;

        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else if (this.Count == 1)
        {
            element = this.head.Value;
            this.head = this.tail = null;
        }
        else
        {
            element = this.head.Value;
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }

        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        int index = 0;
        QueueNode<T> current = this.head;

        while (current != null)
        {
            array[index++] = current.Value;
            current = current.NextNode;
        }

        return array;
    }
}


public class Program
{
    public static void Main()
    {
        LinkedQueue<int> queue = new LinkedQueue<int>();

        queue.Enqueue(4);
        queue.Enqueue(3);

        Console.WriteLine(string.Join(" ", queue.ToArray()));
        Console.WriteLine(queue.Dequeue());
    }
}

