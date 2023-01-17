using System;
using System.Linq;

int[] sizes = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizes[0];
int cols = sizes[1];

if (rows < 3 || cols < 3)
{
    return;
}

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] colsToAdd = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = colsToAdd[col];
    }
}

int maxSum = int.MinValue;
int maxSumRowIndex = 0;
int maxSumColIndex = 0;

for (int row = 0; row < rows - 2; row++)
{
    for (int col = 0; col < cols - 2; col++)
    {
        int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                         matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                         matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            maxSumRowIndex = row;
            maxSumColIndex = col;
        }
    }
}

Console.WriteLine($"Sum = {maxSum}");
for (int row = maxSumRowIndex; row < maxSumRowIndex + 3; row++)
{
    for (int col = maxSumColIndex; col < maxSumColIndex + 3; col++)
    {
        Console.Write($"{matrix[row,col]} ");
    }

    Console.WriteLine();
}