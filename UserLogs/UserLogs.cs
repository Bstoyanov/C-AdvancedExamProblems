using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            var userLogs = new SortedDictionary<string,Dictionary<string, int>> ();
            string input = Console.ReadLine();
            while (input != "end")
            {  
                string[] data = input.Split();
                string ipAddress = data[0].Replace("IP=",string.Empty);
                string name = data[2].Replace("user=", String.Empty);
                if (!userLogs.ContainsKey(name))
                {
                    userLogs.Add(name,new Dictionary<string, int>());
                    userLogs[name].Add(ipAddress,1);
                }
                else if (!userLogs[name].ContainsKey(ipAddress))
                {
                    userLogs[name].Add(ipAddress,1);
                }
                else
                {
                    userLogs[name][ipAddress] ++;
                }
                input = Console.ReadLine();
            }

            foreach (string user in userLogs.Keys)
            {
                StringBuilder result = new StringBuilder();
                result.AppendFormat("{0}:{1}", user,Environment.NewLine);

                foreach (var ip in userLogs[user])
                {
                    result.Append(ip.Key + " => " + ip.Value+ ", ");
                }

                Console.WriteLine(result.ToString().Trim(new char[] {' ',','}) + ".");
            }
        }
    }
}