using System;
using System.Collections.Generic;
using System.Linq;

class Pyramid
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<int> resultInts = new List<int>();
        int[][] pyramid = new int[lines][];
        for (int i = 0; i < lines; i++)
        {
            pyramid[i] = Console.ReadLine().Split(new char[] { ' ' }
                   , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        }

        resultInts.Add(pyramid[0][0]);
        int previousNum = resultInts.Last();
        for (int row = 1; row < lines; row++)
        {
            int bestDiff = int.MaxValue;
            bool isFound = false;
            int bestnum = 0;

            for (int col = 0; col < pyramid[row].Length; col++)
            {


                if (pyramid[row][col] > previousNum && (Math.Abs(pyramid[row][col] - previousNum) < bestDiff))
                {
                    bestDiff = Math.Abs(pyramid[row][col] - previousNum);
                    isFound = true;
                    bestnum = pyramid[row][col];
                }
            }
            if (isFound)
            {
                resultInts.Add(bestnum);
                previousNum = bestnum;
            }
            else
            {
                previousNum++;
            }
        }
        Console.WriteLine(string.Join(", ", resultInts));
    }
}

