using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = Console.ReadLine();
        while (true)
        {
            if (text.IndexOf("|") == -1)
            {
                break;
            }
            int firstone = (text.IndexOf("|"));
            int nextOne = text.IndexOf("|", firstone + 1);
            string anotherText = text.Substring(firstone, (Math.Abs(nextOne - firstone) + 1));

            int bombPower = 0;
            for (int i = 1; i < anotherText.Length - 1; i++)
            {
                bombPower += anotherText[i];
            }

            firstone -= bombPower % 10;
            if (firstone<0)
            {
                firstone = 0;
            }
            nextOne += bombPower % 10;
            if (nextOne >=text.Length)
            {
                nextOne = text.Length - 1;
            }
            anotherText = text.Substring(firstone, Math.Abs(firstone - nextOne) + 1);
            text = text.Replace(anotherText, new string('.', anotherText.Length));
        }
        Console.WriteLine(text);

    }
}

