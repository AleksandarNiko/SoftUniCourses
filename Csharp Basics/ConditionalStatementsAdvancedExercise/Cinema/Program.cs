using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeMovie=Console.ReadLine();
            int rows=int.Parse(Console.ReadLine());
            int cols=int.Parse(Console.ReadLine());
            double price = 0;
            switch (typeMovie)
            {
                case "Premiere": price = 12; break;
                case "Normal": price = 7.50;break;
                case "Discount": price = 5;break;

            }
            double finalPrice = price * rows * cols;
            Console.WriteLine($"{finalPrice:F2} leva");
        }
    }
}
