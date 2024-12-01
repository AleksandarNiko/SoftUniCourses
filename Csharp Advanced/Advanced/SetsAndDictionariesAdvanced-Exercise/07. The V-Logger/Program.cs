namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] lineToken = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string vlogger = lineToken[0];
                string command = lineToken[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        vloggers[vlogger].Add("followers", new HashSet<string>());
                        vloggers[vlogger].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string member = lineToken[2];

                    if (vlogger != member && vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(member))
                    {
                        vloggers[vlogger]["following"].Add(member);
                        vloggers[member]["followers"].Add(vlogger);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int number = 1;

            foreach (var vlogger in vloggers.OrderByDescending(v => v.Value["followers"].Count)
                         .ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine(
                    $"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                number++;
            }
}
    }
}
/*
JennaMarbles joined The V-Logger
JennaMarbles followed Zoella
AmazingPhil joined The V-Logger
JennaMarbles followed AmazingPhil
Zoella joined The V-Logger
JennaMarbles followed Zoella
Zoella followed AmazingPhil
Christy followed Zoella
Zoella followed Christy
JacksGap joined The V-Logger
JacksGap followed JennaMarbles
PewDiePie joined The V-Logger
Zoella joined The V-Logger
Statistics
 */
