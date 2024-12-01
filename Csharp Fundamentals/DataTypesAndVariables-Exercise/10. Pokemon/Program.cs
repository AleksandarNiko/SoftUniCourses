using System.Diagnostics.Metrics;
using System.Numerics;

namespace _10._Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower=int.Parse(Console.ReadLine());
            int distance=int.Parse(Console.ReadLine());
            int exhaustionFactor=int.Parse(Console.ReadLine());
            int targetsCount = 0;
            double percent = (double)pokePower * 0.50;
            while (pokePower>=distance)
            {
                if (pokePower - distance == percent && exhaustionFactor != 0)
                {
                    pokePower = (pokePower - distance) / exhaustionFactor;
                }
                else
                {
                    pokePower -= distance;
                }
                targetsCount++;
            }
        
            Console.WriteLine(pokePower);
            Console.WriteLine(targetsCount);
        }
    }
}