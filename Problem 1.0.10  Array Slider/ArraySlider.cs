using System;
using System.Linq;
using System.Numerics;
using System.Text;


class ArraySlider
{
    static void Main(string[] args)
    {
        BigInteger[] array =
            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();
        string commands = Console.ReadLine();
        int currentIndex = 0;
        while (commands != "stop")
        {
            string[] data = commands.Split();
            //"[offset] [operation] [operand]". 
            int offset = int.Parse(data[0]) % array.Length;
            string operation = data[1];
            int operand = int.Parse(data[2]);

            if (offset < 0)
            {
                offset += array.Length;
            }

            currentIndex = (currentIndex + offset) % array.Length;
            
            switch (operation)
            {
                case "&":
                    array[currentIndex] &= operand;
                    break;

                case "|":
                    array[currentIndex] |= operand;
                    break;
                case "^": array[currentIndex] ^= operand;
                    CheckNumForNull(array, currentIndex); break;
                case "+": array[currentIndex] += operand; CheckNumForNull(array, currentIndex); break;
                case "-": array[currentIndex] -= operand; CheckNumForNull(array, currentIndex); break;
                case "*": array[currentIndex] *= operand; CheckNumForNull(array, currentIndex); break;
                case "/": array[currentIndex] /= operand; CheckNumForNull(array, currentIndex); break;

            }
             commands = Console.ReadLine();

        }
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] <= 0)
            {
                sb.AppendFormat("0, ");
            }
            else
            {
                sb.AppendFormat("{0}, ", array[i]);

            }
        }
        string result = sb.ToString().Trim(' ', ',');
        result += ("]");
        Console.WriteLine(result);
    }

    private static void CheckNumForNull(BigInteger[] array, int targetIndex)
    {
        if (array[targetIndex] < 0)
        {
            array[targetIndex] = 0;
        }
    }
}


