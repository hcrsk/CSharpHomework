using System.Numerics;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task_01
            Random rand = new Random();
            int collumns, raws, sum = 0;

            Console.Write("Введите количество строк: ");
            raws = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            collumns = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[raws, collumns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(50);
                    sum += matrix[i, j];
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сумма всех элементов матрицы: {sum}");
            Console.ReadKey();
            #endregion

            Console.Clear();

            #region Task_02

            int[,] matrix2 = new int[raws, collumns];
            int[,] sumMatrix = new int[raws, collumns];

            for (int i = 0; i < raws; i++)
            {
                for (int j = 0; j < collumns; j++)
                {
                    matrix2[i, j] = rand.Next(50);
                    sumMatrix[i, j] = matrix[i, j] + matrix2[i, j];
                }
            }

            int[][,] matrixArray = { matrix, matrix2, sumMatrix };

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Первая матрица");
                        break;
                    case 1:
                        Console.WriteLine("Вторая матрица");
                        break;
                    case 2:
                        Console.WriteLine("Сумма матриц");
                        break;
                }
                for (int j = 0; j < matrixArray[i].GetLength(0); j++)
                {
                    for (int k = 0; k < matrixArray[i].GetLength(1); k++)
                    {
                        Console.Write($"{matrixArray[i][j, k],2} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            #endregion
        }
    }
}