using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

class ClearingCommands
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        List<string> textLines = new List<string>();
        char[] commands = new char[] { '>', '<', '^', 'v' };
        while (text != "END")
        {

            textLines.Add(text);
            text = Console.ReadLine();
        }
        char[][] jagged = new char[textLines.Count][];
        for (int i = 0; i < textLines.Count; i++)
        {
            jagged[i] = textLines[i].ToCharArray();
        }
        int rowLength = textLines.Count;


        for (int row = 0; row < jagged.GetLength(0); row++)
        {
            for (int col = 0; col < jagged[row].Length; col++)
            {
                char testChar = jagged[row][col];
                if (commands.Contains(testChar))
                {
                    switch (testChar)
                    {
                        case '^':
                            ClearJaggedUpside(commands, jagged, row, col);
                            break;
                        case '<':
                            ClearJaggedLeft(commands, jagged, row, col); break;
                        case 'v':
                            ClearJaggedDown(commands, jagged, row, col, rowLength); break;
                        case '>': ClearJaggedRight(commands, jagged, row, col); break;
                    }
                }

            }
        }
        PrintJaggedArray(jagged, commands);


    }

    private static void PrintJaggedArray2(char[][] jagged)
    {
        for (int i = 0; i < jagged.GetLength(0); i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j]);
            }
            Console.WriteLine();
        }
    }

    private static void ClearJaggedRight(char[] commands, char[][] jagged, int row, int col)
    {
        for (int i = col + 1; i < jagged[row].Length; i++)
        {
            char testChar = jagged[row][i];
            if (commands.Contains(testChar))
            {
               break;
            }
            jagged[row][i] = ' ';
        }
    }

    private static void ClearJaggedDown(char[] commands, char[][] jagged, int row, int col, int rowLength)
    {
        for (int i = row + 1; i < rowLength; i++)
        {
            char testChar = jagged[i][col];
            if (commands.Contains(testChar))
            {
                break;
            }
            jagged[i][col] = ' ';
        }
    }

    private static void ClearJaggedLeft(char[] commands, char[][] jagged, int row, int col)
    {
        for (int i = col - 1; i >= 0; i--)
        {
            char testChar = jagged[row][i];
            if (commands.Contains(testChar))
            {
                break;
            }
            jagged[row][i] = ' ';
        }
    }

    private static void PrintJaggedArray(char[][] jagged, char[] commands)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < jagged.GetLength(0); i++)
        {
            sb.Append("<p>");
            for (int j = 0; j < jagged[i].Length; j++)
            {
                char testChar = jagged[i][j];
                if (commands.Contains(testChar))
                {
                    switch (testChar)
                    {
                        case '>':
                            sb.Append("&gt;");
                            break;
                        case '<':
                            sb.Append("&lt;"); break;
                        default:
                            sb.Append(jagged[i][j]); break;

                    }

                }
                else
                {
                    sb.Append(jagged[i][j]);

                }
            }
            sb.Append("</p>");
            Console.WriteLine(sb);
            sb.Clear();


        }
    }

    private static void ClearJaggedUpside(char[] commands, char[][] jagged, int row, int col)
    {
        for (int i = row-1; i >= 0; i--)
        {
            char testChar = jagged[i][col];
            if (commands.Contains(testChar))
            {
                break;
            }
            jagged[i][col] = ' ';
        }
    }


}

