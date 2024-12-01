using System;

namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nCountOfOrders = int.Parse(Console.ReadLine());
            double totalSum = 0;
            for (int i = 0; i < nCountOfOrders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                double sum = ((days * capsulesCount) * pricePerCapsule);
                Console.WriteLine($"The price for the coffee is: ${sum:f2}");
                totalSum += sum;
            }
                Console.WriteLine($"Total: ${totalSum:f2}");
        }
    }
}
