using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfGroup = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            decimal price = 0;
            decimal totalPrice = 0;
            decimal discount = 0;
            switch (typeOfGroup)
            {
                case "Students":
                    if (day == "Friday")
                    {
                        price = 8.45m;
                    }
                    else if (day == "Saturday")
                    {
                        price = 9.80m;
                    }
                    else if (day == "Sunday")
                    {
                        price = 10.46m;
                    }
                    break;
                case "Business":
                    if (day == "Friday")
                    {
                        price = 10.90m;
                    }
                    else if (day == "Saturday")
                    {
                        price = 15.60m;
                    }
                    else if (day == "Sunday")
                    {
                        price = 16m;
                    }
                    break;
                case "Regular":
                    if (day == "Friday")
                    {
                        price = 15m;
                    }
                    else if (day == "Saturday")
                    {
                        price = 20m;
                    }
                    else if (day == "Sunday")
                    {
                        price = 22.50m;
                    }
                    break;
            }
            totalPrice = price * countOfGroup;
            switch (typeOfGroup)
            {
                case "Students":
                    if (countOfGroup >= 30)
                    {
                        discount = totalPrice - ((totalPrice / 100) * 15m);
                        Console.WriteLine($"Total price: {discount:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {totalPrice:F2}");
                    }
                    break;
                case "Business":
                    if (countOfGroup >= 100)
                    {
                        discount = totalPrice - (10m * price);
                        Console.WriteLine($"Total price: {discount:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {totalPrice:F2}");
                    }
                    break;
                case "Regular":
                    if (countOfGroup >= 10 && countOfGroup <= 20)
                    {
                        discount = totalPrice - ((totalPrice / 100) * 5m);
                        Console.WriteLine($"Total price: {discount:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"Total price: {totalPrice:F2}");
                    }
                    break;
            }
        }
    }
}
