// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// Результат:
// 66(0,0,0) 25(0,1,0) 27(0,0,1) 90(0,1,1)
// 34(1,0,0) 41(1,1,0) 26(1,0,1) 55(1,1,1)

Console.WriteLine("Ну что,  случайно зададим трехмерный  массив двузначных неповторяющихся чисел?");

Console.Write("Введи количество строк трёхмерного массива: ");
int row = Convert.ToInt32(Console.ReadLine());

Console.Write("Введи количество столбцов трёхмерного массива: ");
int column = Convert.ToInt32(Console.ReadLine());

Console.Write("Введи глубину трёхмерного массива: ");
int dep = Convert.ToInt32(Console.ReadLine());

if (row * column * dep > 90)
{
    Console.WriteLine("В таком массиве элементов больше чем существует двузначных чисел, попробуй уменьшить количество строк, столбцов или глубину");
    return;
}

int[,,] CreateArray3dUniqNum(int rows, int columns, int depth, int min, int max)
{
    int[,,] matrix = new int[rows, columns, depth];

    Random rnd = new();
    HashSet<int> twoDigitNum = new();
    while (twoDigitNum.Count < rows * columns * depth)
    {
        twoDigitNum.Add(rnd.Next(min, max + 1));
    }
    Console.WriteLine(string.Join(",", twoDigitNum));

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                {
                    matrix[i, j, k] = twoDigitNum.ElementAt(0);
                    twoDigitNum.Remove(matrix[i, j, k]);
                }
            }
        }
    }
    return matrix;
}

void PrintMatrix(int[,,] matrix)
{
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int k = 0; k < matrix.GetLength(2); k++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j, k],3}({i},{j},{k})");
            }
        }
        Console.WriteLine();
    }
}

int[,,] array3d = CreateArray3dUniqNum(row, column, dep, 10, 99);
PrintMatrix(array3d);