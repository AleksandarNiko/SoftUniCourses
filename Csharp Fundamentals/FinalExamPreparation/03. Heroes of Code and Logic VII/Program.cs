using System.Threading.Channels;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(string heroName,int horsePower,int manaPoints)
        {
            Name = heroName;
            HP = horsePower;
            MP= manaPoints;
        }
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Hero> map=new Dictionary<string,Hero>();
            int numOfHeroes=int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfHeroes; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                string heroName = lineToken[0];
                int horsePower = int.Parse(lineToken[1]);
                int manaPoints = int.Parse(lineToken[2]);
                Hero hero = new Hero(heroName, horsePower, manaPoints);

                if (!map.ContainsKey(heroName))
                {
                    map.Add(heroName, hero);
                }
                else
                {
                    continue;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] lineToken = input.Split(" - ");
                string command = lineToken[0];
                string name = lineToken[1];
                
                
                if (command == "CastSpell")
                {
                    int mpNeed = int.Parse(lineToken[2]);
                    string spellName = lineToken[3];
                    
                    if (mpNeed <= map[name].MP)
                    {
                        map[name].MP -= mpNeed;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {map[name].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(lineToken[2]);
                    string attacker = lineToken[3];

                    if (map[name].HP - damage > 0) 
                    {
                        map[name].HP -= damage;
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {map[name].HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        map.Remove(name);
                    }
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(lineToken[2]);
                    int totalMp = map[name].MP + amount;

                    if (totalMp > 200)
                    {

                        Console.WriteLine($"{name} recharged for {200 - map[name].MP} MP!");
                        map[name].MP = 200;
                    }
                    else
                    {
                        map[name].MP = totalMp;

                        Console.WriteLine($"{name} recharged for {amount} MP!");

                    }

                }
                else if (command == "Heal")
                {
                    int amount = int.Parse(lineToken[2]);
                    int totalHp = map[name].HP+ amount;

                    if (totalHp > 100)
                    {
                        Console.WriteLine($"{name} healed for {100 - map[name].HP} HP!");
                        map[name].HP = 100;
                    }
                    else
                    {
                        map[name].HP = totalHp;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                }

            }

            if (map.Count > 0)
            {
                foreach (var item in map)
                {
                    Console.WriteLine($"{item.Key}");
                    Console.WriteLine($" HP: {item.Value.HP }");
                    Console.WriteLine($" MP: { item.Value.MP }");
                }
            }
        }
    }
}
/*
2
Solmyr 85 120
Kyrre 99 50
Heal - Solmyr - 10
Recharge - Solmyr - 50
TakeDamage - Kyrre - 66 - Orc
CastSpell - Kyrre - 15 - ViewEarth
End
*/