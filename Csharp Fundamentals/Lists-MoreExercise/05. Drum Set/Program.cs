using System.Diagnostics;
using System.Threading.Channels;

namespace _05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List< int>drumsSet=Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> price = new List<int>();
            price.AddRange(drumsSet);
            string input;
            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);
                for (int i = 0; i < price.Count; i++)
                {
                    drumsSet[i] -= hitPower;
                    if (drumsSet[i] <= 0)
                    {
                        if (savings - (drumsSet[i] * 3) >= 0)
                        {
                            savings = savings - (price[i] * 3);
                            drumsSet[i] = price[i];
                        }
                    }
                }

                for (int i = 0; i < drumsSet.Count; i++)
                {
                    if (drumsSet[i] <= 0)
                    {
                        drumsSet.Remove(drumsSet[i]);
                        price.Remove(drumsSet[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ",drumsSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
/*
1000,00
58 65 33
11
12
18
10
Hit it again, Gabsy!
*/