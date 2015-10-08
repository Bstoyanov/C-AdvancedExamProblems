using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

class Program
{


    static void Main(string[] args)
    {
        List<string> collection = Console.ReadLine()
            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        string commands = Console.ReadLine();
        while (commands != "end")
        {
            string[] commandArgs = commands.Split();

            int rollTimes;
            int startIndex;
            int numberOfElements;
            try
            {
                switch (commandArgs[0])
                {

                    case "reverse":
                        {
                            startIndex = int.Parse(commandArgs[2]);
                            numberOfElements = int.Parse(commandArgs[4]);
                            if (startIndex + numberOfElements > collection.Count || startIndex < 0 ||
                                numberOfElements <= 0)
                            {
                                Console.WriteLine("Invalid input parameters.");
                                break;
                            }
                            else
                            {
                                RevereseArr(collection, startIndex, numberOfElements);
                                break;

                            }
                        }
                    case "sort":
                        {
                            startIndex = int.Parse(commandArgs[2]);
                            numberOfElements = int.Parse(commandArgs[4]);
                            if (startIndex + numberOfElements > collection.Count || startIndex < 0 ||
                                numberOfElements <= 0)
                            {
                                Console.WriteLine("Invalid input parameters.");
                                break;
                            }
                            SortPartOFList(collection, startIndex, numberOfElements);
                            break;
                        }
                    case "rollLeft":
                        {

                            rollTimes = int.Parse(commandArgs[1]);
                            if (rollTimes < 0)
                            {
                                Console.WriteLine("Invalid input parameters.");
                                break;
                            }
                            {
                                collection = RollListLeft(collection, rollTimes);
                            }
                        }
                        break;
                    case "rollRight":
                        {
                            rollTimes = int.Parse(commandArgs[1]);
                            if (rollTimes < 0)
                            {
                                Console.WriteLine("Invalid input parameters.");
                                break;
                            }
                            collection = RollListRight(collection, rollTimes);
                        }

                        break;

                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input parameters.");

            }
            commands = Console.ReadLine();
        }
        PrintList(collection);

    }

    private static List<string> RollListRight(List<string> collection, int rollTimes)
    {
        List<string> tempList = new List<string>();


        for (int i = 0; i < rollTimes % collection.Count; i++)
        {
            string firstString = collection.Last();
            collection.RemoveAt(collection.Count - 1);
            tempList.Add(firstString);
            tempList.AddRange(collection);
            collection.Clear();
            collection = new List<string>(tempList);
            tempList.Clear();

        }
        return collection;


    }

    private static List<string> RollListLeft(List<string> collection, int rollTimes)
    {
        List<string> tempList = new List<string>();
        for (int i = 0; i < rollTimes % collection.Count; i++)
        {

            string firstString = collection.First();

            collection.RemoveAt(0);
            tempList.AddRange(collection);
            tempList.Add(firstString);
            collection.Clear();
            collection = new List<string>(tempList);
            tempList.Clear();

        }
        return collection;


    }

    private static void SortPartOFList(List<string> collection, int startIndex, int numberOfElements)
    {
        List<string> tempList = new List<string>();
        for (int i = startIndex; i < startIndex + numberOfElements; i++)
        {
            tempList.Add(collection[i]);
        }
        tempList.Sort();
        collection.RemoveRange(startIndex, numberOfElements);
        collection.InsertRange(startIndex, tempList);

    }

    private static void PrintList(List<string> collection)
    {
        StringBuilder sb = new StringBuilder();
        Console.Write("[");
        collection.ForEach(x => sb.Append(x + ", "));
        string str = sb.ToString();
        str = str.Trim(new char[] { ' ', ',' });
        Console.Write(str + "]");
        Console.WriteLine();

    }

    private static void RevereseArr(List<string> collection, int startIndex, int numberOfElements)
    {
        string[] tempList = new string[numberOfElements];
        int indexer = 0;
        for (int i = startIndex; i < startIndex + numberOfElements; i++)
        {
            tempList[indexer] = collection[i];
            indexer++;
        }
        Array.Reverse(tempList);
        collection.RemoveRange(startIndex, numberOfElements);
        collection.InsertRange(startIndex, tempList);
    }
}



