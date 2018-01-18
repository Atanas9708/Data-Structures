using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private T[] arr;
    public int Count { get; set; }
    public int Capacity { get; set; }

    public ReversedList()
    {
        this.Count = 0;
        this.Capacity = 2;
        this.arr = new T[this.Capacity];
    }

    public void Add(T item)
    {
        if (this.Count == this.Capacity)
        {
            this.Resize();
        }

        this.arr[this.Count] = item;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        if (!this.CheckRange(index))
        {
            throw new IndexOutOfRangeException();
        }

        T element = this.arr[index];

        for (int i = this.Count - index - 1; i < this.Count - 1; i++)
        {
            this.arr[i] = this.arr[i + 1];
        }

        this.Count--;

        return element;

    }

    public T this[int index]
    {
        get
        {
            if (!this.CheckRange(index))
            {
                throw new IndexOutOfRangeException();
            }

            return this.arr[this.Count - index - 1];
        }

        set
        {
            if (!this.CheckRange(index))
            {
                throw new IndexOutOfRangeException();
            }

            this.arr[this.Count - index - 1] = value;
        }
    }

    public void Resize()
    {
        T[] newArray = new T[this.Capacity * 2];
        Array.Copy(this.arr, newArray, this.Count);
        this.Capacity *= 2;
        this.arr = newArray;
    }

    private bool CheckRange(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            return false;
        }

        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count-1; i >= 0; i--)
        {
            yield return this.arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
