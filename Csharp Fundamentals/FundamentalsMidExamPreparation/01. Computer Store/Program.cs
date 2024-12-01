using System.Diagnostics;
using System.Xml.Schema;

namespace _01._Computer_Store
{
 
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;
            decimal total = 0;
            decimal tax = 0;
            decimal totalWithTax = 0;

            while (true)
            {
                line = Console.ReadLine();
                if (line == "special" || line == "regular")
                {
                    break;
                }
                decimal priceWithoutTax = decimal.Parse(line);
                if (priceWithoutTax < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                total += priceWithoutTax;

            }
            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                tax = (total * (20m / 100m));
                Console.WriteLine("Congratulations you've just bought a new computer!");

                Console.WriteLine($"Price without taxes: {total:f2}$ ");

                Console.WriteLine($"Taxes: {tax:f2}$");

                Console.WriteLine("-----------");
                totalWithTax = total + tax;
                if (line == "special")
                {
                    totalWithTax -= (totalWithTax * 10m) / 100m;
                }
                Console.WriteLine($"Total price: {totalWithTax:f2}$ ");
            }
        }
    }
}

