using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_01._14.MatrixShuffle
{
    class MatrixShuffle
    {
        static void Main(string[] args)
        {

            int dimensions = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimensions, dimensions];
            string str = Console.ReadLine();
            DrawSpiral(matrix, dimensions, str);
            StringBuilder whiteSquares = new StringBuilder();
            StringBuilder blackSquares = new StringBuilder();
            bool white = true;

            for (int row = 0; row < dimensions; row++)
            {
                if (row % 2 != 0)
                {
                    white = false;
                }
                else
                {
                    white = true;
                }
                for (int col = 0; col < dimensions; col++)
                {

                    if (white)
                    {
                        whiteSquares.Append(matrix[row, col]);
                        white = false;
                        continue;
                    }
                    blackSquares.Append(matrix[row, col]);
                    white = true;

                }
            }

            string result = (whiteSquares.ToString() + blackSquares);
            string reversed = ReverseString(result.ToLower());
            Regex regex = new Regex(@"\\W+");
            string resultToL = result.ToLower();
           resultToL =  RemoveNonWordChars(resultToL);

            if (resultToL == reversed)
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", result);
                
            }
            else
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", result);
            }
        }

        private static string RemoveNonWordChars(string resultToL)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultToL.Length; i++)
            {
                if (Char.IsLetter(resultToL[i]))
                {
                    sb.Append(resultToL[i]);
                }
            }
            return sb.ToString();
        }

        private static string ReverseString(string result)
        {
            string res = result.ToLower().Replace(" ","");
            StringBuilder sb = new StringBuilder();
            for (int i = res.Length - 1; i >= 0; i--)
            {
                if (Char.IsLetter(res[i]))
                {
                    sb.Append(res[i]);
                }
            }
            return sb.ToString();
        }

        private static void DrawSpiral(char[,] matrix, int dimensions, string str)
        {
            int size = dimensions;
            int x = 0;
            int y = 0;
            int currentCount = 0;

            while (size > 0)
            {
                for (int i = y; i <= y + size - 1; i++)
                {
                    matrix[x, i] = str[currentCount % str.Length];
                    currentCount++;
                }

                for (int j = x + 1; j <= x + size - 1; j++)
                {
                    matrix[j, y + size - 1] = str[currentCount % str.Length];
                    currentCount++;

                }

                for (int i = y + size - 2; i >= y; i--)
                {
                    matrix[x + size - 1, i] = str[currentCount % str.Length];
                    currentCount++;
                }

                for (int i = x + size - 2; i >= x + 1; i--)
                {
                    matrix[i, y] = str[currentCount % str.Length];
                    currentCount++;
                }

                x = x + 1;
                y = y + 1;
                size = size - 2;
            }

        }
    }
}