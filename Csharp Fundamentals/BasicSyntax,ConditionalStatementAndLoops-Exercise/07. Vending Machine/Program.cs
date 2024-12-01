using System;
using System.Threading.Channels;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputCoins = Console.ReadLine();
            double sumCoins = 0;
            while (inputCoins != "Start")
            {
                switch (inputCoins)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        sumCoins += double.Parse(inputCoins);
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {inputCoins}");
                        break;
                }
                inputCoins = Console.ReadLine();
            }
            string product = Console.ReadLine();
            double productPrice = 0;
            while (product != "End")
            {
                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.0;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                if (sumCoins >= productPrice && sumCoins > 0 && productPrice > 0)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumCoins -= productPrice;
                    productPrice = 0;
                }
                else if (productPrice > 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    productPrice = 0;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sumCoins:F2}");

        }
    }  }

