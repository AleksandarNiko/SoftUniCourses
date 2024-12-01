namespace _01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"{contest}:{password for contest}" until the "end of contests"
            Dictionary<string, string> contDic = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] lineToken = input.Split(":");
                string contest = lineToken[0];
                string password = lineToken[1];
                contDic.Add(contest, password);
            }

            //"{contest}=>{password}=>{username}=>{points}", until the "end of submissions" 
            SortedDictionary<string, Dictionary<string, int>> nameAndContestWithPoints =
                new SortedDictionary<string, Dictionary<string, int>>();
            string input2;
            while ((input2 = Console.ReadLine()) != "end of submissions")
            {
                string[] lineToken = input2.Split("=>");
                string contest = lineToken[0];
                string password = lineToken[1];
                string username = lineToken[2];
                int points = int.Parse(lineToken[3]);
                if (contDic.ContainsKey(contest)
                    && contDic.ContainsValue(password))
                {
                    if (nameAndContestWithPoints.ContainsKey(username) == false)
                    {
                        nameAndContestWithPoints.Add(username, new Dictionary<string, int>());
                        nameAndContestWithPoints[username].Add(contest, points);
                    }

                    if (nameAndContestWithPoints[username].ContainsKey(contest))
                    {
                        if (nameAndContestWithPoints[username][contest] < points)
                        {
                            nameAndContestWithPoints[username][contest] = points;
                        }
                    }
                    else
                    {
                        nameAndContestWithPoints[username].Add(contest, points);
                    }
                }
            }

            Dictionary<string, int> usernameTotalPoints = new Dictionary<string, int>();
            foreach (var kvp in nameAndContestWithPoints)
            {
                usernameTotalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            string bestName = usernameTotalPoints
                .Keys
                .Max();
            int bestPoints = usernameTotalPoints
                .Values
                .Max();

            foreach (var kvp in usernameTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }

            Console.WriteLine("Ranking:");
            foreach (var name in nameAndContestWithPoints)
            {
                Dictionary<string, int> dict = name.Value;
                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("{0}", name.Key);
                foreach (var kvp in dict)
                {
                    Console.WriteLine("#  {0} -> {1}", kvp.Key, kvp.Value);
                }
            }
        }
    }
}
/*
Part One Interview:success
Js Fundamentals:Jsfundmpass
C# Fundamentals:fundPass
Algorithms:fun
end of contests
C# Fundamentals=>fundPass=>Tanya=>350
Algorithms=>fun=>Tanya=>380
Part One Interview=>success=>Nikola=>120
Java Basics Exam=>jsfundmpass=>Mary=>400
Part One Interview=>success=>Tanya=>220
OOP Advanced=>password123=>Jim=>231
C# Fundamentals=>fundPass=>Tanya=>250
C# Fundamentals=>fundPass=>Nikola=>200
Js Fundamentals=>Jsfundmpass=>Tanya=>400
end of submissions
*/