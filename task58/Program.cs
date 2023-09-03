// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.WriteLine("Создадим две матрицы и умножим первую на вторую");

Console.Write("Введи количество строк первого массива(столбцов второго массива): ");
int m = Convert.ToInt32(Console.ReadLine());

Console.Write("Введи количество столбцов первого массива(строк второго массива): ");
int n = Convert.ToInt32(Console.ReadLine());

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new();

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
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {

            Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] ProductОfMatrix(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] productMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
    for (int i = 0; i < productMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < productMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < secondMatrix.GetLength(0); k++)
            {
                productMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
            }
        }
    }
    return productMatrix;
}

int[,] firstArray2d = CreateMatrixRndInt(m, n, 1, 5);
Console.WriteLine("Первая матрица:");
PrintMatrix(firstArray2d);

int[,] secondArray2d = CreateMatrixRndInt(n, m, 1, 5);
Console.WriteLine("Вторая матрица:");

PrintMatrix(secondArray2d);
int[,] productOfMatrix = ProductОfMatrix(firstArray2d, secondArray2d);
Console.WriteLine("Произведение матриц:");
PrintMatrix(productOfMatrix);