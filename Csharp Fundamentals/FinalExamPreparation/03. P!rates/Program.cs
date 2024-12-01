namespace _03._P_rates
{
    internal class Program
    {
        class City
        {
            public City(string cityName, int population, int gold)
            {
                Name = cityName;
                Population = population;
                Gold = gold;
            }
            public string Name { get; set; }
            public int Population { get; set; }
            public int Gold { get; set; }

        }
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, City> map = new Dictionary<string, City>();
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] inputArgs = input.Split("||").ToArray();
                string cityName = inputArgs[0];
                int population = int.Parse(inputArgs[1]);
                int gold = int.Parse(inputArgs[2]);
                City city = new City(cityName, population, gold);
                if (!map.ContainsKey(cityName))
                {
                    map.Add(cityName, city);
                }
                else
                {
                    map[cityName].Population += population;
                    map[cityName].Gold += gold;
                }
               

            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] events = command.Split("=>").ToArray();
                string commandType = events[0];
                if (commandType == "Plunder")
                {
                    string townName = events[1];
                    int peopleKilled = int.Parse(events[2]);
                    int goldStolen = int.Parse(events[3]);
                    map[townName].Population -= peopleKilled;
                    map[townName].Gold -= goldStolen;
                    Console.WriteLine($"{townName} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

                    if (map[townName].Population == 0 || map[townName].Gold == 0)
                    {
                        Console.WriteLine($"{townName} has been wiped off the map!");
                        map.Remove(townName);
                    }


                }
                else if (commandType == "Prosper")
                {
                    string townName = events[1];
                    int gold = int.Parse(events[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");

                    }
                    else
                    {

                        map[townName].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {map[townName].Gold} gold.");
                    }
                }
                
            }

            if (map.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {map.Count} wealthy settlements to go to:");
                foreach (var item in map)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");

            }
            
        }
        }
    }
/*
Tortuga||345000||1250
Santo Domingo||240000||630
Havana||410000||1100
Sail
Plunder=>Tortuga=>75000=>380
Prosper=>Santo Domingo=>180
End
*/
