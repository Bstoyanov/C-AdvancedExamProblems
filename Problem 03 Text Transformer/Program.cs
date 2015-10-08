using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        while (input != "burp")
        {
            sb.Append(input);
            input = Console.ReadLine();
        }
        string text = Regex.Replace(sb.ToString().Trim(), @"\s+", " ");
        
        Regex pattern = new Regex(@"([$%&'])([^$%&']+)\1");
        

        MatchCollection match = pattern.Matches(text);
        sb.Clear();
        foreach (Match item in match)
        {
            int score = 0;
            switch (item.Groups[1].Value)
            {
                case "$":
                    score = 1; break;
                case "%":
                    score = 2; break;
                case "&":
                    score = 3;
                    break;
               default:
                    score = 4;
                    break;
            }
            text = item.Groups[2].Value;
            int length = text.Length;
            for (int i = 0; i < length; i++)
            {
                char testchar = text[i];
                if (i % 2 == 0)
                {

                    testchar = (char)(testchar + score);
                }
                else
                {
                    testchar = (char)(testchar - score);
                }
                sb.Append(testchar);
            }
            sb.Append(' ');
        }
        Console.WriteLine(sb);
       

    }
}

