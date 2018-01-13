using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; }


    public void AddFirst(T item)
    {
        Node prev = this.Head;
        this.Head = new Node(item);
        this.Head.Next = prev;

        if (this.isEmpty())
        {
            this.Tail = this.Head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node prev = this.Tail;
        this.Tail = new Node(item);

        if (this.isEmpty())
        {
            this.Head = this.Tail;
        }
        else
        {
            prev.Next = this.Tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.isEmpty())
        {
            throw new InvalidOperationException();
        }

        T item = this.Head.Value;
        this.Head = this.Head.Next;
        this.Count--;

        return item;
    }

    public T RemoveLast()
    {
        if (this.isEmpty())
        {
            throw new InvalidOperationException();
        }

        T item = this.Tail.Value;
        Node current = this.Head;

        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            while (current.Next != this.Tail)
            {
                current = current.Next;
            }

            current.Next = null;
            this.Tail = current;
        }
            
        this.Count--;

        return item;
    }

    private bool isEmpty()
    {
        return this.Count == 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
