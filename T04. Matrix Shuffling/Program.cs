using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] colsToAdd = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = colsToAdd[col];
    }
}

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] commandArguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    if (IsValidCommand(commandArguments))
    {
        int row1 = int.Parse(commandArguments[1]);
        int col1 = int.Parse(commandArguments[2]);
        int row2 = int.Parse(commandArguments[3]);
        int col2 = int.Parse(commandArguments[4]);

        (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);

        PrintMatrix(matrix);
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

bool IsValidCommand(string[] commandArguments)
{
    if (commandArguments.Length != 5)
    {
        return false;
    }

    string command = commandArguments[0];
    if (command != "swap")
    {
        return false;
    }

    int row1 = int.Parse(commandArguments[1]);
    int col1 = int.Parse(commandArguments[2]);
    int row2 = int.Parse(commandArguments[3]);
    int col2 = int.Parse(commandArguments[4]);
    if (row1 < 0 || row1 >= rows ||
        col1 < 0 || col1 >= cols ||
        row2 < 0 || row2 >= rows ||
        col2 < 0 || col2 >= cols)
    {
        return false;
    }

    return true;
}

void PrintMatrix(string[,] anyMatrix)
{
    for (int row = 0; row < anyMatrix.GetLength(0); row++)
    {
        for (int col = 0; col < anyMatrix.GetLength(1); col++)
        {
            Console.Write($"{anyMatrix[row, col]} ");
        }

        Console.WriteLine();
    }
}