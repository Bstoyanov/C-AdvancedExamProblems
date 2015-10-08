using System;
using System.Runtime.CompilerServices;
using System.Text;


class SequenceInMatrix
{
    static void Main()
    {
        int rowLength = int.Parse(Console.ReadLine());
        int colLength = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rowLength, colLength];
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                matrix[i, j] = Console.ReadLine();

            }
        }
        string result = "";
        for (int currentRow = 0; currentRow < rowLength; currentRow++)
        {
            for (int currentCol = 0; currentCol < colLength; currentCol++)
            {
                string columnEquals = checkColumns(matrix, currentRow, currentCol,rowLength);
                string diagonal = CheckDiagonals(matrix, rowLength, colLength,currentRow,currentCol);
                if (diagonal.Length > result.Length)
                {
                    result = diagonal;
                }
                if (columnEquals.Length > result.Length)
                {
                    result = columnEquals;
                }
            }
        }
        Console.WriteLine(result.Trim(',',' '));



    }

    private static string checkColumns(string[,] matrix, int currentRow, int currentCol,int rowLength)
    {
        string testString = matrix[currentRow, currentCol];
        StringBuilder sb = new StringBuilder();
        sb.Append(testString + ", ");
        for (int i = 1; i+currentRow < rowLength; i++)
        {
            if (matrix[currentRow+i,currentCol]!=testString)
            {
                break;
            }
            sb.Append(matrix[currentRow + i, currentCol]);
        }
        return sb.ToString();
    }

    private static string CheckDiagonals(string[,] matrix, int rowLength, int colLength, int currentRow, int currentCol)
    {
        string word = matrix[currentRow, currentCol];
        StringBuilder sb = new StringBuilder();
        sb.Append(matrix[currentRow, currentCol] +", ");
        int minLength = Math.Min(rowLength, colLength);
       
            for (int i = 1; (i+currentCol < minLength) && (i+currentRow < minLength); i++)
            {
                
                    string testString = matrix[currentRow + i, currentCol + i];
                    if (testString != word)
                    {
                        break;
                    }
                    sb.Append(testString + ", ");
                
                
            }
        
        
        return sb.ToString();
    }

    



}