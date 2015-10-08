using System;


class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int cols = text.Length % rows + text.Length % rows == 0 ? 0 : 1;
        char[,] matrix = new char[rows, cols];
        int indexer = 0;
        for (int i = 0; i < cols; i++)
        {
            matrix[0, i] = text[indexer];
            indexer++;
        }
        for (int i = 1; i < rows; i++)
        {
            matrix[i, cols - 1] = text[indexer];
            indexer++;
        }
       // PrintMatrix(matrix, rows, cols);

    }

    private static void PrintMatrix(char[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}

