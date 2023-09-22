using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_matrix
{

    class Program
    {
    static void Main()
    {
        while (true) 
        {
            Console.WriteLine("Создание первой матрицы:");
            int[,] matrix1 = CreateMatrix();

            Console.WriteLine("Создание второй матрицы:");
            int[,] matrix2 = CreateMatrix();

            Console.WriteLine("Введите коэффициент для умножения значений матрицы:");
            int coefficient = int.Parse(Console.ReadLine());

            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrix1);

            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrix2);

            int[,] additionResult = AddMatrices(matrix1, matrix2);
            Console.WriteLine("Результат сложения матриц:");
            PrintMatrix(additionResult);

            int[,] multiplicationByNumberResult = MultiplyMatrixByNumber(matrix1, coefficient);
            Console.WriteLine($"Результат умножения первой матрицы на число {coefficient}:");
            PrintMatrix(multiplicationByNumberResult);

            int[,] multiplicationResult = MultiplyMatrices(matrix1, matrix2);
            Console.WriteLine("Результат произведения матриц:");
            PrintMatrix(multiplicationResult);

            Console.Write("Желаете продолжить (да/нет)? ");
            string choice = Console.ReadLine();

            if (choice.ToLower() != "да")
            {
                break; 
            }
        }
    }

    static int[,] CreateMatrix()
        {
            Console.WriteLine("Введите количество строк матрицы:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов матрицы:");
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            Console.WriteLine("Выберите способ заполнения матрицы (1 - случайные числа, 2 - вручную):");
            int inputMethod = int.Parse(Console.ReadLine());

            if (inputMethod == 1)
            {
                Random random = new Random();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = random.Next(1, 11); 
                    }
                }
            }
            else if (inputMethod == 2)
            {
                Console.WriteLine("Введите элементы матрицы:");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }

            return matrix;
        }

        static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);

            if (matrix2.GetLength(0) != rows || matrix2.GetLength(1) != cols)
            {
                throw new InvalidOperationException("Нельзя сложить матрицы разных размеров.");
            }

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        static int[,] MultiplyMatrixByNumber(int[,] matrix, int number)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }

            return result;
        }
        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            if (cols1 != rows2)
            {
                throw new InvalidOperationException("Нельзя умножить матрицы разных размеров.");
            }

            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

}
