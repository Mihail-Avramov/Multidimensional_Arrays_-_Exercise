using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size,size];

for (int row = 0; row < size; row++)
{
    int[] inputArguments = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < size; col++)
    {
        matrix[row,col] = inputArguments[col];
    }
}

string[] bombsCoordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var bombCoordinates in bombsCoordinates)
{
    int[] currentBombCoordinates = bombCoordinates
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int currentBombRow = currentBombCoordinates[0];
    int currentBombCol = currentBombCoordinates[1];

    if (isValidCoordinats(currentBombRow, currentBombCol))
    {
        int currentBombPower = matrix[currentBombRow,currentBombCol];
        matrix[currentBombRow, currentBombCol] -= currentBombPower;

        if (isValidCoordinats(currentBombRow - 1, currentBombCol - 1))
        {
            matrix[currentBombRow - 1, currentBombCol - 1] -= currentBombPower;
        }

        if (isValidCoordinats(currentBombRow - 1, currentBombCol))
        {
            matrix[currentBombRow - 1, currentBombCol] -= currentBombPower;
        }

        if (isValidCoordinats(currentBombRow - 1, currentBombCol + 1))
        {
            matrix[currentBombRow - 1, currentBombCol + 1] -= currentBombPower;
        }

        if (isValidCoordinats(currentBombRow, currentBombCol - 1))
        {
            matrix[currentBombRow, currentBombCol - 1] -= currentBombPower;
        }

        if (isValidCoordinats(currentBombRow, currentBombCol + 1))
        {
            matrix[currentBombRow, currentBombCol + 1] -= currentBombPower;
        }

        if (isValidCoordinats(currentBombRow + 1, currentBombCol - 1))
        {
            matrix[currentBombRow + 1, currentBombCol - 1] -= currentBombPower;
        }

        if (isValidCoordinats(currentBombRow + 1, currentBombCol))
        {
            matrix[currentBombRow + 1, currentBombCol] -= currentBombPower;
        }

        if (isValidCoordinats(currentBombRow + 1, currentBombCol + 1))
        {
            matrix[currentBombRow + 1, currentBombCol + 1] -= currentBombPower;
        }
    }
    else
    {
        continue;
    }
}

int sumOfCells = 0;
int aliveCells = 0;
foreach (var item in matrix)
{
    if (item > 0)
    {
        aliveCells++;
        sumOfCells += item;
    }
}

Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {sumOfCells}");

PrintMatrix(matrix);


bool isValidCoordinats(int row, int col)
{
    return
        row >= 0 &&
        col >= 0 &&
        row < size &&
        col < size &&
        matrix[row, col] > 0;
}

void PrintMatrix(int[,] currentMatrix)
{
    for (int row = 0; row < currentMatrix.GetLength(0); row++)
    {
        for (int col = 0; col < currentMatrix.GetLength(1); col++)
        {
            Console.Write($"{currentMatrix[row, col]} ");
        }

        Console.WriteLine();
    }
}