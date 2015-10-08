using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_17.BiggestTableRow
{
    class BiggestTableRow
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> text = new List<string>();
            while (input != "</table>")
            {
                text.Add(input);
                input = Console.ReadLine();
            }
            List<decimal> result = new List<decimal>();
            result.Add(Decimal.MinValue);
            Regex regex = new Regex(@"<td>(-?[0-9.?]+)</td>");
            for (int i = 2; i < text.Count; i++)
            {
                List<decimal> tempList = new List<decimal>();
                string tempstr = text[i];
                MatchCollection matches = regex.Matches(tempstr);
                foreach (Match match in matches)
                {

                    tempList.Add(decimal.Parse(match.Groups[1].Value));



                }
                if (tempList.Sum() > result.Sum())
                {
                    result.Clear();
                    result.AddRange(tempList);
                }

            }
            if (result.Count == 0)
            {
                Console.WriteLine("no data");
            }
            else if (result.Count() == 1 )
            {
                Console.WriteLine("{0:f0} = {0}", result.First());
            }
            else
            {
                StringBuilder resultBuilder = new StringBuilder();
                if (result.Sum() == 0)
                {
                    resultBuilder.AppendFormat("{0:f0} = ", result.Sum());
                    
                }
                else
                {
                    resultBuilder.AppendFormat("{0} = ", result.Sum());
                }
                
                foreach (var num in result)
                {
                    resultBuilder.Append(num + " + ");
                }
                Console.WriteLine(resultBuilder.ToString().Trim(new char[] { '+', ' ' }));
            }
        }
    }
}
