using System;
using System.Text;
using System.Text.RegularExpressions;

class PhoneNumbers
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"(\+?[0-9 ?|(]{2,})|([A-Z]+[a-z]*)";
        StringBuilder sb = new StringBuilder();
        while (input != "END")
        {
            sb.Append(input);
            input = Console.ReadLine();
        }
        Regex replacement = new Regex(@"[^a-zA-z0-9+]");

        string replaced = sb.ToString();
        replaced = replacement.Replace(replaced, "").Trim();
        Regex allTogether = new Regex(pattern);
        MatchCollection matches = allTogether.Matches(replaced);
        sb.Clear();
        sb.Append("<ol>");
        int indexer = 0;
        string removeChars = @"[\s\WA-Za-z]";
        Regex test = new Regex(removeChars);
        string testString = replaced;
        testString = test.Replace(testString, "");
        if (testString.Length <= 2)
        {
            Console.WriteLine("<p>No matches!</p>");
            return;
        }
        bool isName = true;
        foreach (Match match in matches)
        {

            if (isName)
            {
                bool nextIsNumber = CheckIfNextMatchIsPhone(match.NextMatch().ToString());
                if (nextIsNumber)
                {
                    sb.Append("<li><b>" + match.Value + ":</b> ");
                    isName = false;
                }

            }
            else
            {
                sb.Append(match.Value + "</li>");
                isName = true;
            }
        }
        sb.Append("</ol>");
        Console.WriteLine(sb.ToString());
    }

    private static bool CheckIfNextMatchIsPhone(string match)
    {
        for (int i = 1; i < match.Length; i++)
        {
            if (!char.IsDigit(match[i]))
            {
                return false;
            }
        }
        return true;
    }
}

