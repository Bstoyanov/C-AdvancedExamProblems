using System;


class Program
{
    static void Main(string[] args)
    {
        int sizeOnChessBoard = int.Parse(Console.ReadLine());
        string inputString = Console.ReadLine();
        int indexer = 0;
        int whiteTeamScore = 0;
        int blackTeamScore = 0;
        char[,] matrix = new char[sizeOnChessBoard, sizeOnChessBoard];
        for (int row = 0; row < sizeOnChessBoard; row++)
        {
            for (int col = 0; col < sizeOnChessBoard; col++)
            {
                if (indexer >= inputString.Length)
                {
                    break;
                }

                matrix[row, col] = inputString[indexer];
                indexer++;
            }
        }
        

        for (int i = 0; i < sizeOnChessBoard; i++)
        {
            for (int j = 0; j < sizeOnChessBoard; j++)
            {
                char testChar = matrix[i, j];
                int score = CalculateChar(matrix[i, j]);

                if (i % 2 == 0)
                {
                    //black square
                    if (char.IsUpper(testChar))
                    {
                        whiteTeamScore += score;
                        
                    }
                    else
                    {
                        blackTeamScore += score;
                    }

                }
                else
                {
                    //white square
                    if (char.IsUpper(testChar))
                    {
                        blackTeamScore += score;
                    }
                    else
                    {
                        whiteTeamScore += score;
                    }
                }

            }
        }
        if (blackTeamScore == whiteTeamScore)
        {
            Console.WriteLine("Equal result: {0}", whiteTeamScore);
        }
        else if (blackTeamScore > whiteTeamScore)
        {
            Console.WriteLine("The winner is: {0} team", blackTeamScore > whiteTeamScore ? "black" : "white");
            Console.WriteLine(Math.Abs(blackTeamScore - whiteTeamScore));

        }

    }

    private static int CalculateChar(char p)
    {

        if (char.IsLetterOrDigit(p))
        {
            return p;
        }
        return 0;
    }


}

