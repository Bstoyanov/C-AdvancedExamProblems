using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_15.TheNumbers
{
    class TheNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex  = new Regex("\\D");
            input = regex.Replace(input, " ");
            int[] numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var number in numbers)
            {
                string result = number.ToString("X");
                sb.Append("0x");
                if (result.Length < 4)
                {
                    sb.Append(new string('0', 4 - result.Length));
                }
                sb.Append(result);
                sb.Append("-");
            }
            string finalResult = sb.ToString();
            Console.WriteLine(finalResult.Trim('-'));
        }
    }
    
}
