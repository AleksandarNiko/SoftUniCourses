using System;

namespace _03.GamingStore
{
    /*OutFall 4 $39.99
          CS: OG $15.99
    Zplinter Zell $19.99
         Honored 2 $59.99
        RoverWatch $29.99
RoverWatch Origins Edition $39.99
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double spent = 0;
            while (true)
            {
                string game = Console.ReadLine();
                if (game == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${spent:F2}. Remaining: ${balance:F2}");
                    break;
                }
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                double price = 0;
                switch (game)
                {
                    case "OutFall 4":
                        price = 39.99;
                        if (balance >= price)
                        {
                            Console.WriteLine($"Bought {game}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            price = 0;
                        }
                        break;
                    case "CS: OG":
                        price = 15.99;
                        if (balance >= price)
                        {
                            Console.WriteLine($"Bought {game}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            price = 0;
                        }
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        if (balance >= price)
                        {
                            Console.WriteLine($"Bought {game}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            price = 0;
                        }
                        break;
                    case "Honored 2":
                        price = 59.99;
                        if (balance >= price)
                        {
                            Console.WriteLine($"Bought {game}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            price = 0;
                        }
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        if (balance >= price)
                        {
                            Console.WriteLine($"Bought {game}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            price = 0;
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        if (balance >= price)
                        {
                            Console.WriteLine($"Bought {game}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            price = 0;
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                balance -= price;
                spent += price;
            }
        }
    }
}
