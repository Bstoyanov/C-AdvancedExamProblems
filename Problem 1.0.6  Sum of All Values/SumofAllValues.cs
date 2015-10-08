using System;
using System.Text.RegularExpressions;

namespace Problem_1._0._6__Sum_of_All_Values
{
    class SumofAllValues
    {
        static void Main()
        {
            Regex startKey = new Regex(@"(^[a-zA-Z_]+)[0-9]+");
            Regex endKey = new Regex(@"[0-9]+([a-zA-Z_]+)$");
            string inpuKeys = Console.ReadLine();
            string text = Console.ReadLine();
            string startKeyMatch = startKey.Match(inpuKeys).Groups[1].ToString();
            string endkMatch = endKey.Match(inpuKeys).Groups[1].ToString();
            if (String.IsNullOrEmpty(startKeyMatch) || String.IsNullOrEmpty(endkMatch))
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }
            Regex newRegex = new Regex(startKeyMatch + "([0-9.]+)" + endkMatch);
            MatchCollection matches = newRegex.Matches(text);
            decimal result = 0;
            foreach (Match match in matches)
            {
                result += Decimal.Parse(match.Groups[1].ToString());

            }
            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", result == 0 ? "nothing" : result.ToString());
        }
    }
}