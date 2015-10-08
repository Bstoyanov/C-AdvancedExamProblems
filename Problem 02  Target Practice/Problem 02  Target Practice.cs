using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] rowCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int row = rowCol[0];
        int col = rowCol[1];
        char[,] matrix = new char[row, col];
        string snake = Console.ReadLine();
        int indexer = 0;
        int[] shot = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int impactRow = shot[0];
        int impactCol = shot[1];
        int radius = shot[2];
        bool rightToLeft = true;
        for (int i = row - 1; i >= 0; i--)
        {
            if (rightToLeft)
            {
                for (int j = col - 1; j >= 0; j--)
                {
                    if (indexer >= snake.Length)
                    {
                        indexer = 0;
                    }
                    matrix[i, j] = snake[indexer];
                    indexer++;
                }
                rightToLeft = false;
            }
            else
            {
                for (int j = 0; j < col; j++)
                {
                    if (indexer >= snake.Length)
                    {
                        indexer = 0;
                    }
                    matrix[i, j] = snake[indexer];
                    indexer++;

                }
                rightToLeft = true;
            }
        }
        shootMatrix(matrix, radius, row, col,impactRow,impactCol);
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            RunGravity(matrix, i);
        }
        
        PrintMatrix(matrix, row, col);


    }

    private static void RunGravity(char[,] matrix, int col)
    {
            while (true)
            {
                bool hasFallen = false;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char topChar = matrix[row - 1, col];
                    char currentChar = matrix[row, col];
                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }

                if (!hasFallen)
                {
                    break;
                }
            }
            
        
    }


    private static void shootMatrix(char[,] matrix, int radius, int row, int col, int impactRow, int impactCol)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {

                int deltaX = j - impactCol;
                  int  deltaY = i - impactRow;
                if ((Math.Sqrt((deltaX * deltaX + deltaY * deltaY))) <= radius)
                {
                    matrix[i, j] = ' ';
                }
            }
        }
    }

    



    private static void PrintMatrix(char[,] matrix, int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}

