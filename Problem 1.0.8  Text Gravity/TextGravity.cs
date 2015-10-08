

using System;
using System.Security;
using System.Text;


class TextGravity
{
    private const char SpaceChar = ' ';
    static void Main(string[] args)
    {
        int cols = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int rows = (text.Length / cols) + (text.Length % cols == 0 ? 0 : 1);
        char[,] matrix = new char[rows, cols];
        int indexer = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (indexer <= text.Length - 1)
                {
                    matrix[i, j] = text[indexer];
                }
                else
                {
                    matrix[i, j] = SpaceChar;
                }
                indexer++;
            }
        }
        for (int i = 0; i < cols; i++)
        {
            runGravity(matrix, i, rows);
        }
        StringBuilder sb = new StringBuilder();
        Console.Write("<table>");
        for (int i = 0; i < rows; i++)
        {
            sb.Append("<tr>");
            for (int j = 0; j < cols; j++)
            {
                char testChar = matrix[i, j];
                if (testChar == '>' || testChar == '<' || testChar == '\"' || testChar == '&')
                {
                    sb.AppendFormat("<td>{0}</td>", SecurityElement.Escape(testChar.ToString()));
                    continue;

                }
                sb.AppendFormat("<td>{0}</td>", matrix[i, j]);

            }
            sb.Append("</tr>");

        }
        sb.AppendLine("</table>");

        Console.WriteLine(sb);



    }

    private static void runGravity(char[,] matrix, int col, int rows)
    {

        while (true)
        {
            bool hasSwapped = false;

            for (int row = 1; row < rows; row++)
            {
                char currentChar = matrix[row, col];
                char topChar = matrix[row - 1, col];
                if (currentChar == ' ' && topChar != ' ')
                {
                    matrix[row - 1, col] = ' ';
                    matrix[row, col] = topChar;
                    hasSwapped = true;
                }

            }
            if (!hasSwapped)
            {
                break;
            }
        }
    }


}

