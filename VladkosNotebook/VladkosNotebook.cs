using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class VladkosNotebook
{
    static void Main(string[] args)
    {
        SortedDictionary<string, Player> pagesByColor = new SortedDictionary<string, Player>();
        string input = Console.ReadLine();
        bool isFound = false;
        while (input != "END")
        {
            string[] data = input.Split('|');
            string color = data[0];
            if (!pagesByColor.ContainsKey(data[0]))
            {

                pagesByColor[color] = new Player();
                pagesByColor[color].OpponentsList = new List<string>();

            }
            //can be used as alias
            // Player currentPlayer = pagesByColor[color];
            if (data[1] == "name")
            {
                pagesByColor[color].Name = data[2];
            }
            else if (data[1] == "age")
            {
                pagesByColor[color].Age = int.Parse(data[2]);

            }
            else if (data[1] == "win")
            {
                pagesByColor[color].WinCount++;
                pagesByColor[color].OpponentsList.Add(data[2]);

            }
            else if (data[1] == "loss")
            {
                pagesByColor[color].LossCount++;
                pagesByColor[color].OpponentsList.Add(data[2]);

            }


            input = Console.ReadLine();
        }
        StringComparer ordCmp = StringComparer.Ordinal;
        var validPages = pagesByColor.Where(p => p.Value.Age != 0 && p.Value.Name != null)
            .OrderBy(x => x.Key);

        foreach (var item1 in pagesByColor)
        {
            item1.Value.OpponentsList.Sort(ordCmp);
        }
        foreach (var item in pagesByColor)
        {
            if (item.Value.Name == null || item.Value.Age == 0)
            {
                continue;
            }
            isFound = true;
            double rank = (item.Value.WinCount + 1.0) / (item.Value.LossCount + 1);
            Console.WriteLine("Color: {0}", item.Key);
            Console.WriteLine("-age: {0}", item.Value.Age);
            Console.WriteLine("-name: {0}", item.Value.Name);
            Console.WriteLine("-opponents: {0}", item.Value);
            Console.WriteLine("-rank: {0:F2}", rank);
        }
        if (!isFound)
        {
            Console.WriteLine("No data recovered.");

        }
    }
}

public class Player
{
    private int age = 0;
    private string name = null;
    //collections must be initialized in the constructor
    public Player()
    {
         this.OpponentsList = new List<string>();   
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }


    public string Name { get; set; }
    public List<string> OpponentsList
    {
        get;
        set;
    }
    public int WinCount { get; set; }
    public int LossCount { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (this.OpponentsList.Count == 0)
        {
            return "(empty)";
        }
        foreach (var item in this.OpponentsList)
        {
            sb.Append(item + ", ");
        }
        return sb.ToString().Trim(' ', ',');
    }
}
