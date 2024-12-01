using System.Numerics;

namespace _02._Big_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            BigInteger factoriel = 1;
            for (int i = n; i >=2; i--)
            {
              factoriel *= i;
            }

            Console.WriteLine(factoriel);
        }
    }
}