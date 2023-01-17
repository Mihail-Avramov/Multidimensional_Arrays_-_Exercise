using System;
using System.Linq;

int rows = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[rows][];

for (int row = 0; row < rows; row++)
{
    jaggedArray[row] = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

for (int row = 0; row < rows-1; row++)
{
    if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
    {
        for (int col = 0; col < jaggedArray[row].Length; col++)
        {
            jaggedArray[row][col] *= 2;
            jaggedArray[row + 1][col] *= 2;
        }
    }
    else
    {
        for (int col = 0; col < jaggedArray[row].Length; col++)
        {
            jaggedArray[row][col] /= 2;
        }

        for (int col = 0; col < jaggedArray[row + 1].Length; col++)
        {
            jaggedArray[row + 1][col] /= 2;
        }
    }
}

string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] commandArguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string command = commandArguments[0];
    int rowIndex = int.Parse(commandArguments[1]);
    int colIndex = int.Parse(commandArguments[2]);
    int value = int.Parse(commandArguments[3]);

    if (rowIndex < 0 || rowIndex >= jaggedArray.Length || colIndex < 0 || colIndex >= jaggedArray[rowIndex].Length)
    {
        continue;
    }

    if (command == "Add")
    {
        jaggedArray[rowIndex][colIndex] += value;
    }
    else if (command == "Subtract")
    {
        jaggedArray[rowIndex][colIndex] -= value;
    }
}


for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < jaggedArray[row].Length; col++)
    {
        Console.Write($"{jaggedArray[row][col]} ");
    }

    Console.WriteLine();
}