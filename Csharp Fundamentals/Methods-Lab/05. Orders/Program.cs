namespace _05._Orders
{
    internal class Program
    {//*
// coffee – 1.50
//• water – 1.00
//• coke – 1.40
//• snacks – 2.00*//
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;
            PrintPrice(product, quantity, price);
        }
        private static void PrintPrice(string product, int quantity, double price)
        {
            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    Console.WriteLine($"{price * quantity:f2}");
                    break;
                case "water":
                    price = 1.00;
                    Console.WriteLine($"{price * quantity:f2}");
                    break;
                case "coke":
                    price = 1.40;
                    Console.WriteLine($"{price * quantity:f2}");
                    break;
                case "snacks":
                    price = 2.00;
                    Console.WriteLine($"{price * quantity:f2}");
                    break;
            }
        }
    }
}