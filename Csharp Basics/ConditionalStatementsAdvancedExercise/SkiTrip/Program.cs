using System;

namespace SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string rate = Console.ReadLine();
            int night = days - 1;
            double price = 0;
            switch (typeRoom)
            {
                case "room for one person":
                    price = night * 18;
                    break;
                case "apartment":
                    price = night * 25;
                    if (days < 10)
                    {
                        price = price - price * 0.3;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        price = price - price * 0.35;
                    }
                    else if (days > 15)
                    {
                        price = price - price * 0.5;
                    }
                    break;
                case "president apartment":
                    price = night * 35;
                    if (days < 10)
                    {
                        price = price - price * 0.1;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        price = price - price * 0.15;
                    }
                    else if (days > 15)
                    {
                        price = price - price * 0.2;
                    }
                    break;
            }
            if (rate == "positive")
            {
                price = price + price * 0.25;
            }
            else if (rate == "negative")
            {
                price = price - price * 0.1;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
