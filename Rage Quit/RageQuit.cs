using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


class Program
{
    static void Main(string[] args)
    {
        string pattern = @"[0-9]{1,}";
        StringBuilder sb = new StringBuilder();
        sb.Append(Console.ReadLine());
        Regex regex = new Regex(pattern);
        string text = sb.ToString();
        MatchCollection matches = regex.Matches(sb.ToString());
        int index = 0;
        sb.Clear();
        foreach (Match match in matches)
        {

            int timesToMultiply = int.Parse(match.Value);
            int length = match.Index - index + (int.Parse(match.Value) >= 10 ? 1 : 0);
            string textToBeMultiplied = text.Substring(index, length);


            string multiplted = MultiplyText(textToBeMultiplied, timesToMultiply);
            index = match.Index + 1;
            sb.Append(multiplted);
        }
        string s = sb.ToString();
        Regex regex2 = new Regex(@"[0-9][0-9]?");
        s = regex2.Replace(s, "");
        string reZIL = regex2.Replace(sb.ToString(), "");
        var newstr = String.Join("", s.Distinct());
        Console.WriteLine("Unique symbols used: {0}", newstr.Length);
        Console.WriteLine(reZIL);


    }

    private static string MultiplyText(string textToBeMultiplied, int timesToMultiply)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < timesToMultiply; i++)
        {
            sb.Append(textToBeMultiplied.ToUpper());
        }
        return sb.ToString();
    }
}

