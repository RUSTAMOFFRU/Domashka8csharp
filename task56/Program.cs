// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

int[] RowSumElem(int[,] matrix)
{
    int[] rowSumElem = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            rowSumElem[i] += matrix[i, j];
        }
    }
    return rowSumElem;
}

int NumberRowMinSumElem(int[] rowSumElem)
{
    int numberRowMinSumElem = 1;
    int min = rowSumElem[0];
    for (int i = 1; i < rowSumElem.Length; i++)
    {

        if (min > rowSumElem[i])
        {
            min = rowSumElem[i];
            numberRowMinSumElem = i + 1;
        }
    }
    return numberRowMinSumElem;
}

int[,] array2d = CreateMatrixRndInt(m, n, 1, 9);
PrintMatrix(array2d);

int[] rowSumElement = RowSumElem(array2d);
Console.WriteLine("Суммы элементов строк:");
Console.WriteLine(String.Join(",  ", rowSumElement));

int numberRowMinSumElement = NumberRowMinSumElem(rowSumElement);
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {numberRowMinSumElement} строка");
