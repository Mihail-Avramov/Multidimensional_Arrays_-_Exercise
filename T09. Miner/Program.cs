using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());

string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

char[,] matrix = new char[size, size];

int rowIndex = 0;
int colIndex = 0;
int coalCounter = 0;
int totalCoal = 0;

for (int row = 0; row < matrix.GetLength(0); row++)
{
    char[] fieldPositions = Console.ReadLine()
        .Split(' ',StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (fieldPositions[col] == 's')
        {
            rowIndex = row;
            colIndex = col;
        }
        if (fieldPositions[col] == 'c')
        {
            totalCoal++;
        }
        matrix[row, col] = fieldPositions[col];
    }
}

foreach (var command in commands)
{
    switch (command)
    {
        case "left":
            if (IsValidCoordinates(rowIndex, colIndex - 1))
            {
                colIndex -= 1;
                if (matrix[rowIndex, colIndex] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }

                if (matrix[rowIndex, colIndex] == 'c')
                {
                    coalCounter++;
                    matrix[rowIndex, colIndex] = '*';
                }

                if (coalCounter == totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    return;
                }
            }
            break;
        case "right":
            if (IsValidCoordinates(rowIndex, colIndex + 1))
            {
                colIndex += 1;
                if (matrix[rowIndex, colIndex] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }

                if (matrix[rowIndex, colIndex] == 'c')
                {
                    coalCounter++;
                    matrix[rowIndex, colIndex] = '*';
                }

                if (coalCounter == totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    return;
                }
            }
            break;
        case "up":
 
            if (IsValidCoordinates(rowIndex -1, colIndex))
            {
                rowIndex -= 1;
                if (matrix[rowIndex, colIndex] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }

                if (matrix[rowIndex, colIndex] == 'c')
                {
                    coalCounter++;
                    matrix[rowIndex, colIndex] = '*';
                }

                if (coalCounter == totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    return;
                }
            }
            break;
        case "down":
            if (IsValidCoordinates(rowIndex + 1, colIndex))
            {
                rowIndex += 1;
                if (matrix[rowIndex, colIndex] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }

                if (matrix[rowIndex, colIndex] == 'c')
                {
                    coalCounter++;
                    matrix[rowIndex, colIndex] = '*';
                }

                if (coalCounter == totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    return;
                }
            }
            break;
    }
}

int remainingCoals = totalCoal - coalCounter;
Console.WriteLine($"{remainingCoals} coals left. ({rowIndex}, {colIndex})");



bool IsValidCoordinates(int row, int col)
{
    return
        row >= 0 &&
        col >= 0 &&

row < size &&
        col < size;
}