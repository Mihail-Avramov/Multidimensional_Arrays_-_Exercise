using System;

int size = int.Parse(Console.ReadLine());

if (size < 3)
{
    Console.WriteLine(0);
    return;
}

char[,] matrix = new char[size,size];

for (int row = 0; row < size; row++)
{
    char[] chars = Console.ReadLine().ToCharArray();

    for (int col = 0; col < size; col++)
    {
        matrix[row,col] = chars[col];
    }
}

int removedKnightCounter = 0;

while (true)
{
    int knightsAttacksCount = 0;
    int knightRowIndex = 0;
    int knightColIndex = 0;

    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            int currentAttacksCount = 0;
            if (matrix[row, col] == 'K')
            {
                if (isValidCell(row - 1, col - 2))
                {
                    currentAttacksCount++;
                }

                if (isValidCell(row + 1, col - 2))
                {
                    currentAttacksCount++;
                }

                if (isValidCell(row - 2, col - 1))
                {
                    currentAttacksCount++;
                }

                if (isValidCell(row + 2, col - 1))
                {
                    currentAttacksCount++;
                }

                if (isValidCell(row - 2, col + 1))
                {
                    currentAttacksCount++;
                }

                if (isValidCell(row + 2, col + 1))
                {
                    currentAttacksCount++;
                }

                if (isValidCell(row - 1, col + 2))
                {
                    currentAttacksCount++;
                }

                if (isValidCell(row + 1, col + 2))
                {
                    currentAttacksCount++;
                }

                if (currentAttacksCount > knightsAttacksCount)
                {
                    knightsAttacksCount = currentAttacksCount;
                    knightRowIndex = row;
                    knightColIndex = col;
                }
            }
        }
    }

    if (knightsAttacksCount>0)
    {
        matrix[knightRowIndex, knightColIndex] = '0';
        removedKnightCounter++;
    }
    else
    {
        break;
    }
    
}

Console.WriteLine(removedKnightCounter);


bool isValidCell(int row, int col)
{
    return
        row >= 0
        && row < size
        && col >= 0
        && col < size
        && matrix[row,col] == 'K';
}