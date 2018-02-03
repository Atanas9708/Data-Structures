using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);

        if (this.Count == 1)
        {
            return;
        }

        int childIndex = this.heap.Count - 1;
        int parentIndex = childIndex - 1;
        int compare = this.heap[childIndex].CompareTo(this.heap[parentIndex]);

        while (compare > 0)
        {
            this.Swap(parentIndex, childIndex);
            childIndex = parentIndex;
            parentIndex = (parentIndex - 1) / 2;

            if (childIndex == parentIndex)
            {
                break;
            }
        }

    }

    private void Swap(int parentIndex, int childIndex)
    {
        T temp = this.heap[parentIndex];
        this.heap[parentIndex] = this.heap[childIndex];
        this.heap[childIndex] = temp;
    }

    public T Peek()
    {
        if (this.heap.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return this.heap[0];
    }

    public T Pull()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.heap[0];
        this.Swap(0, this.Count - 1);
        this.heap.RemoveAt(this.Count - 1);
        this.HeapifyDown(0);

        return element;
    }

    private void HeapifyDown(int index)
    {
        int parentIndex = index;

        while (parentIndex < this.Count / 2)
        {
            int childIndex = (parentIndex * 2) + 1;

            if (childIndex + 1 < this.Count && IsGreater(childIndex, childIndex + 1))
            {
                childIndex += 1;
            }

            int compare = this.heap[parentIndex].CompareTo(this.heap[childIndex]);

            if (compare < 0)
            {
                this.Swap(childIndex, parentIndex);
            }

            parentIndex = childIndex;
        }
    }

    private bool IsGreater(int left, int right)
    {
        return this.heap[left].CompareTo(this.heap[right]) < 0;
    }
}
