// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.WriteLine("Создадим массив со спиральным заполенением");
Console.Write("Введи количество строк массива: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Введи количество столбцов массива: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] SpiralMatrix(int row, int column)
{
    int[,] spiral = new int[row, column];
    int elem = 1;
    for (int i = 0; i < spiral.GetLength(0) - i; i++)
    {
        for (int j = i; j < spiral.GetLength(1)-i; j++)
        {
            spiral[i, j] = elem;
            elem++;
            if (j == spiral.GetLength(1)-i-1)
            {
                for (int k = i + 1; k < spiral.GetLength(0) - i; k++)
                {
                    spiral[k, j] = elem;
                    elem++;
                    if (k == spiral.GetLength(0) - i-1)
                    {
                        for (int m = j-1; m >= i; m--)
                        {
                            spiral[k, m] = elem;
                            elem++;
                            if (m == i)
                            {
                                for (int n = spiral.GetLength(0)-2-i; n > i; n--)
                                {
                                    spiral[n, m] = elem;
                                    elem++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    return spiral;
}


void PrintMatrix(int[,] matrix)
{
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {

            Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine();
    }
}

int[,] spiralMatrix = SpiralMatrix(rows, columns);
PrintMatrix(spiralMatrix);