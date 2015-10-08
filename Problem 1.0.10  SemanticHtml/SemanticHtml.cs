using System;
using System.ComponentModel;
using System.Text.RegularExpressions;


class SemanticHtml
{
    static void Main(string[] args)
    {
      //  string pattern = "<div\\s(id=\"(\\w+)\")>";
        string pattern = @"<div\s(id=""(\w+)"")>";

        string text = Console.ReadLine();
        while (text !="END")
        {
            MatchCollection matches = Regex.Matches(pattern, text);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2]);
            }

            text = Console.ReadLine();
        }
    }
}

