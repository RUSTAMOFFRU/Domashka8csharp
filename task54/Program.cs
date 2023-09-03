// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки 
// двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.WriteLine("Ну что,  случайно зададим двумерный массив?");

Console.Write("Введи количество строк массива: ");
int m = Convert.ToInt32(Console.ReadLine());

Console.Write("Введи количество столбцов массива: ");
int n = Convert.ToInt32(Console.ReadLine());

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
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

int[] RowToArray(int[,] matrix, int row)   //метод делает из строки двумерного массива одномерный массив
{
    int[] rowToArray = new int[matrix.GetLength(1)];

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        rowToArray[j] = matrix[row, j];
        {

        }
    }
    return rowToArray;
}

void ReverseSortArray(int[] rowToArray) //Метод сортирует массив в порядке убывания
{
    int n = rowToArray.Length;  
    while (n > 0)
    {
        for (int i = 0; i < n-1; i++)
        {
            if (rowToArray[i] < rowToArray[i + 1])
            {
                (rowToArray[i + 1], rowToArray[i]) = (rowToArray[i], rowToArray[i + 1]);
            }
        }
        n--;
    }
}

void ReverseSortInRows(int[,] matrix)       //метод наполняющий строки матрицы из отсортированного массива         
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int[] sortRowToArr = RowToArray(matrix, i);
        ReverseSortArray(sortRowToArr);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = sortRowToArr[j];
        }
    }
}

int[,] array2d = CreateMatrixRndInt(m, n, 1, 9);
PrintMatrix(array2d);
ReverseSortInRows(array2d);
PrintMatrix(array2d);

