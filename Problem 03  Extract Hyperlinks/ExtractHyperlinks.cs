using System;
using System.Text;
using System.Text.RegularExpressions;


class ExtractHyperlinks
{
    static void Main(string[] args)
    {
        string pattern = @"<a\w*|href|""([\W]+)";
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        while (input!="END")
        {
            sb.Append(input);
            input = Console.ReadLine();
        }
        Regex matcher = new Regex(pattern);
        MatchCollection matches = matcher.Matches(sb.ToString());
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups[0]);
            Console.WriteLine(match.Groups[1]);
            Console.WriteLine(match.Groups[2]);
        }

    }
}

