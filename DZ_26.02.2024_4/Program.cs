//  Создайте приложение, которое производит операции над матрицами:
//	  ■	Умножение матрицы на число;
//	  ■	Сложение матриц;
//	  ■	Произведение матриц.

class MatrixOperations
{
    static void Main()
    {
        int[,] matrixA = {{1, 2, 3},
                          {4, 5, 6},
                          {7, 8, 9}};

        int[,] matrixB = {{10, 11, 12},
                          {13, 14, 15},
                          {16, 17, 18}};

        int number = 5;

        Console.WriteLine("Матрица А:");
        ShowMatrix(matrixA);

        Console.WriteLine("\nМатрица B:");
        ShowMatrix(matrixB);

        int[,] resultMatrixA = MultiplyMatrixByScalar(matrixA, number);
        int[,] resultMatrixB = MultiplyMatrixByScalar(matrixB, number);

        Console.WriteLine($"\nРезультат умножения матрицы А на число {number}:");
        ShowMatrix(resultMatrixA);

        Console.WriteLine($"\nРезультат умножения матрицы B на число {number}:");
        ShowMatrix(resultMatrixB);

        int[,] resultMatrixAddition = AddMatrices(matrixA, matrixB);

        Console.WriteLine("\nРезультат сложения матриц А и B:");
        ShowMatrix(resultMatrixAddition);

        int[,] resultMatrixMultiplication = MultiplyMatrices(matrixA, matrixB);

        Console.WriteLine("\nРезультат произведения матриц А и B:");
        ShowMatrix(resultMatrixMultiplication);
    }

    static void ShowMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static int[,] MultiplyMatrixByScalar(int[,] matrix, int number)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        int[,] resultMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                resultMatrix[i, j] = matrix[i, j] * number;
            }
        }

        return resultMatrix;
    }

    static int[,] AddMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int columns = matrixA.GetLength(1);

        int[,] resultMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return resultMatrix;
    }

    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int columnsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int columnsB = matrixB.GetLength(1);

        if (columnsA != rowsB)
        {
            throw new Exception("Умножение матриц невозможно: количество столбцов матрицы А не соответствует количеству строк матрицы B.");
        }

        int[,] resultMatrix = new int[rowsA, columnsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                for (int k = 0; k < columnsA; k++)
                {
                    resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return resultMatrix;
    }
}