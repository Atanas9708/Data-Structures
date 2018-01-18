using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{

    private class ListNode<T>
    {
        public T Value { get; private set; }
        public ListNode<T> Prev { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;
    public int Count { get; private set; }

    public void AddFirst(T element)
    {

        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            ListNode<T> newHead = new ListNode<T>(element);
            newHead.Next = this.head;
            this.head.Prev = newHead;
            this.head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            ListNode<T> newTail = new ListNode<T>(element);
            newTail.Prev = this.tail;
            this.tail.Next = newTail;
            this.tail = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        T element = this.head.Value;
        this.head = this.head.Next;

        if (this.head != null)
        {
            this.head.Prev = null;
        }
        else
        {
            this.tail = null;
        }

        this.Count--;

        return element;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        T element = this.tail.Value;
        this.tail = this.tail.Prev;

        if (this.tail != null)
        {
            this.tail.Next = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;

        return element;
    }

    public void ForEach(Action<T> action)
    {
        ListNode<T> currentNode = this.head;
        while(currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        int index = 0;
        ListNode<T> currentNode = this.head;

        while (currentNode != null)
        {
            array[index++] = currentNode.Value;
            currentNode = currentNode.Next;
        }

        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
