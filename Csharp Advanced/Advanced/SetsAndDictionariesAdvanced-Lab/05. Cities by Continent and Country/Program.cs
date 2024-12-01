using System.Diagnostics;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var info = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = lineToken[0];
                string country = lineToken[1];
                string city= lineToken[2];

                if (!info.ContainsKey(continent))
                {
                    info.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!info[continent].ContainsKey(country))
                {
                    info[continent].Add(country, new List<string>());
                }

                info[continent][country].Add(city);
            }

            foreach (var (continent, products) in info)
            {
                Console.WriteLine($"{continent}:");
                foreach (var (country, city) in products)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ",city)}");
                }
            }
        }
    }
}
/*
9
Europe Bulgaria Sofia
Asia China Beijing
Asia Japan Tokyo
Europe Poland Warsaw
Europe Germany Berlin
Europe Poland Poznan
Europe Bulgaria Plovdiv
Africa Nigeria Abuja
Asia China Shanghai
 */
