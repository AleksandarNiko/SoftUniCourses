using System.Numerics;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BigInteger number=BigInteger.Parse(Console.ReadLine());
            BigInteger number2 = BigInteger.Parse(Console.ReadLine());
            BigInteger result = number * number2;
            Console.WriteLine(result);
        }
    }
}
/*
923847238931983192462832102
4
*/