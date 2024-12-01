namespace _03._MOBA_Challenger
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playersStats = new Dictionary<string, Dictionary<string, int>>();
            string player = "";
            string position = "";
            int skill = 0;
            while (true)
            {
                List<string> input = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (input[0] == "Season")
                {
                    break;
                }
                if (!(input.Contains("vs")))
                {
                    player = input[0];
                    position = input[1];
                    skill = int.Parse(input[2]);

                    if (playersStats.ContainsKey(player))
                    {
                        if (playersStats[player].ContainsKey(position))
                        {
                            if (playersStats[player][position] < skill)
                            {
                                playersStats[player][position] = skill;
                            }
                        }
                        else
                        {
                            playersStats[player][position] = skill;
                        }

                    }
                    else
                    {
                        Dictionary<string, int> assistsDict = new Dictionary<string, int>();
                        assistsDict.Add(position, skill);
                        playersStats[player] = assistsDict;
                    }
                }
                else
                {
                    string playerOne = input[0];
                    string playerTwo = input[2];
                    if (playersStats.ContainsKey(playerOne) && playersStats.ContainsKey(playerTwo))
                    {
                        bool defeated = false;
                        foreach (var role in playersStats[playerOne])
                        {
                            foreach (var pos in playersStats[playerTwo])
                            {
                                if (role.Key == pos.Key)
                                {
                                    if (playersStats[playerOne].Values.Sum() > playersStats[playerTwo].Values.Sum())
                                    {
                                        playersStats.Remove(playerTwo);
                                        defeated = true;
                                        break;
                                    }
                                    else if (playersStats[playerOne].Values.Sum() < playersStats[playerTwo].Values.Sum())
                                    {
                                        playersStats.Remove(playerOne);
                                        defeated = true;
                                        break;
                                    }
                                }
                            }
                            if (defeated)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            foreach (var playa in playersStats.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{playa.Key}: {playa.Value.Values.Sum()} skill");
                foreach (var pair in playa.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {pair.Key} <::> {pair.Value}");
                }
            }
        }
        
    }
}
/*
Peter -> Adc -> 400
Bush -> Tank -> 150
Faker -> Mid -> 200
Faker -> Support -> 250
Faker -> Tank -> 250
Peter vs Faker
Faker vs Bush
Faker vs Hide
Season end
*/