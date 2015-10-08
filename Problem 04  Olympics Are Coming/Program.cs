using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;



class Program
{
    static void Main(string[] args)
    {
        string lines = Console.ReadLine();
        var collection = new Dictionary<string,List<string>>();
        while (lines != "report")
        {
            string[] inp = lines.Split('|');
            string athlete = inp[0];
            string country = inp[1];
            athlete = Regex.Replace(athlete, @"\s{2,}", " ").Trim();
            country = Regex.Replace(country, @"\s{2,}", " ").Trim();
            if (!collection.ContainsKey(country))
            {
                collection.Add(country, new List<string>());
            }
            collection[country].Add(athlete);




            lines = Console.ReadLine();
            
        }
       var orderedCollection = collection.OrderByDescending(x => x.Value.Count);
        foreach (var item in orderedCollection)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins",
                item.Key,
                item.Value.Distinct().Count(),
                item.Value.Count());
        }


        Console.WriteLine();
    }
}

