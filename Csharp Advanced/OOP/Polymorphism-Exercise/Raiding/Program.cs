using System.Runtime.Serialization.Formatters;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            ICollection<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                string heroName=Console.ReadLine();
                string heroType=Console.ReadLine();

                BaseHero hero = null;

                if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName);
                }
                else if (heroType == "Druid")
                {
                    hero = new Druid(heroName);
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName);
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }
                heroes.Add(hero);
            }
            int bossPower=int.Parse(Console.ReadLine());

            int heroesPower = heroes.Sum(h => h.Power);

            foreach (var h in heroes)
            {
                Console.WriteLine(h.CastAbility());
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
/*
3
Mike
Paladin
Josh
Druid
Scott
Warrior
250
 */