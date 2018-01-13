using System;
using System.Collections;
using System.Collections.Generic;

public class ArrayList<T> : IEnumerable<T>
{
    private T[] arr;
    public int Count { get; set; }
    public int Capacity { get; set; }

    public ArrayList(int capacity = 2)
    {
        this.arr = new T[capacity];
        this.Capacity = capacity;
    }

    public T this[int index]
    {
        get
        {
            if (!this.CheckRange(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.arr[index];
        }

        set
        {
            if (!this.CheckRange(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            this.arr[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count + 1 > this.Capacity)
        {
            this.Grow();
        }

        this.arr[this.Count] = item;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        T item = this[index];
        this[index] = default(T);
        this.ShiftLeft(index);
        if (this.Count - 1 < this.Capacity / 4)
        {
            this.Shrink();
        }
        this.Count--;
        return item;
    }

    public void Grow()
    {
        T[] newArr = new T[this.Capacity * 2];
        this.Capacity *= 2;
        Array.Copy(this.arr, newArr, this.Count);
        this.arr = newArr;
    }

    public void ShiftLeft(int index)
    {
        for (int i = 0; i < this.Count - 1; i++)
        {
            this.arr[i] = this.arr[i + 1];
        }
    }

    public void Shrink()
    {
        T[] newArr = new T[this.Capacity / 2];
        this.Capacity /= 2;
        Array.Copy(this.arr, newArr, this.Count);
        this.arr = newArr;
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
        foreach (var item in this.arr)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
