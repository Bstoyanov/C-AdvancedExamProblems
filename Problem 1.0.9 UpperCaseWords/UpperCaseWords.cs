using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class UpperCaseWords
{
    static void Main(string[] args)
    {
        string pattern = @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
        string input = Console.ReadLine();
        while (input != "END")
        {
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            int offset = 0;
            foreach (Match match in matches)
            {
                string word = match.Value;
                string replacement = Reverse(match.Value);
                if (word == replacement)
                {
                    replacement = doubleTheString(match.Value);

                }
                int index = match.Index;
                input = input.Remove(index + offset, word.Length);
                input = input.Insert(index+offset, replacement);
                offset += replacement.Length - word.Length;
            }


            Console.WriteLine(SecurityElement.Escape(input));
            input = Console.ReadLine();
        }


    }

    private static string doubleTheString(string str)
    {
        StringBuilder doubleString = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            doubleString.Append(new string(str[i],2));
        }
        return doubleString.ToString();
    }

    private static string Reverse(string str)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reversed.Append(str[i]);
        }
        return reversed.ToString();
    }
}

