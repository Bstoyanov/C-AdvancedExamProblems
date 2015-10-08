using System;
using System.Collections.Generic;

namespace Problem_16.Parachute
{
    class Parachute
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> map = new List<string>();
            while (!input.Equals("END"))
            {
                map.Add(input);
                input = Console.ReadLine();
            }

            int[] coordinates = FindStartPosition(map);
            int currentRow = coordinates[0];
            int currentCol = coordinates[1];
            //bool hasFalen = false;
            string result = "";
            currentRow++;
            while (true)
            {
                currentCol = CheckWind(map, currentRow, currentCol);
                if (map[currentRow][currentCol] != '-' &&
                    map[currentRow][currentCol] != '<' &&
                     map[currentRow][currentCol] != '>' &&
                    map[currentRow][currentCol] != 'o')
                {
                    result = Landing(map[currentRow][currentCol]);

                    break;
                }
                currentRow++;
            }
           
            Console.WriteLine(result);
            Console.WriteLine(currentRow + " " + currentCol);

        }

        private static string Landing(char terrain)
        {
            string result = "";
            switch (terrain)
            {
                case '_':
                    result = "Landed on the ground like a boss!"; break;
                case '~':
                    result = "Drowned in the water like a cat!"; break;
                default:
                    result = "Got smacked on the rock like a dog!";
                    break;
            }
            return result;
        }


        private static int CheckWind(List<string> map, int currentRow, int currentCol)
        {
            int windCorrection = currentCol;
            for (int j = 0; j < map[currentRow].Length; j++)
            {
                if (map[currentRow][j].Equals('<'))
                {
                    windCorrection--;
                }
                if (map[currentRow][j].Equals('>'))
                {
                    windCorrection++;
                }

            }
            return windCorrection;
        }

        private static int[] FindStartPosition(List<string> map)
        {
            int[] coordinates = new int[2];
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j].Equals('o'))
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        return coordinates;

                    }
                }
            }
            return coordinates;
        }
    }
}