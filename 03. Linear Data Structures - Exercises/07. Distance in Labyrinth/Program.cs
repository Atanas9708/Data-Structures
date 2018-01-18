using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        int size = int.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];
        int startRow = 0;
        int startCol = 0;

        int startValue = -2;
        int blockedValue = -1;

        for (int row = 0; row < size; row++)
        {
            char[] line = Console.ReadLine().ToCharArray();

            for (int col = 0; col < size; col++)
            {
                if (line[col] == '*')
                {
                    startRow = row;
                    startCol = col;
                    matrix[row, col] = startValue;
                }
                else
                {
                    matrix[row, col] = line[col] == 'x' ? blockedValue : 0;
                }
            }
        }

        Queue<Cell> queue = new Queue<Cell>();
        queue.Enqueue(new Cell(startRow, startCol));
        matrix[startRow, startCol] = 0;

        while (queue.Count > 0)
        {
            Cell current = queue.Dequeue();
            int row = current.Row;
            int col = current.Col;
            int newValue = matrix[row, col] + 1;

            if (row + 1 < size && matrix[row + 1, col] == 0)
            {
                queue.Enqueue(new Cell(row + 1, col));
                matrix[row + 1, col] += newValue;
            }

            if (row - 1 >= 0 && matrix[row - 1, col] == 0)
            {
                queue.Enqueue(new Cell(row - 1, col));
                matrix[row - 1, col] += newValue;
            }

            if (col + 1 < size && matrix[row, col + 1] == 0)
            {
                queue.Enqueue(new Cell(row, col + 1));
                matrix[row, col + 1] += newValue;
            }

            if (col - 1 >= 0 && matrix[row, col - 1] == 0)
            {
                queue.Enqueue(new Cell(row, col - 1));
                matrix[row, col - 1] += newValue;
            }
        }

        matrix[startRow, startCol] = startValue;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                int value = matrix[row, col];

                if (value == blockedValue)
                {
                    Console.Write('x');
                }
                else if (value == startValue)
                {
                    Console.Write('*');
                }
                else if (value == 0)
                {
                    Console.Write('u');
                }
                else
                {
                    Console.Write(value);
                }
            }

            Console.WriteLine();
        }
    }
}

public class Cell
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Cell(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }
}

