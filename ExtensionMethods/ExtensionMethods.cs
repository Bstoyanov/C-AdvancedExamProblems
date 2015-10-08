using System;
using System.Collections.Generic;
using System.Text;


static class ExtensionMethods
{
    static void Main(string[] args)
    {
        //string str = "Hello Extension Methods";
        //int count = str.WordCount();
        //Console.WriteLine(count);

        List<int>ints = new List<int>{1,2,3,4,5};
        Console.WriteLine(ints.ToString());
        Console.WriteLine(  ints.ToString<int>());


    }

    private static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string ToString<T>(this IEnumerable<T> enumeration)
    {
        StringBuilder result = new StringBuilder();
        result.Append('[');
        foreach (var item in enumeration)
        {
            result.Append(item.ToString());
        }
        result.Append(']');
        return result.ToString();
    }

}



