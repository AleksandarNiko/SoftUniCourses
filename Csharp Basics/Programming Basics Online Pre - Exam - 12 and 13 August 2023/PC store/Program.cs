using System;

namespace PC_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double processorPrice=double.Parse(Console.ReadLine());
            double videoCardPrice=double.Parse(Console.ReadLine());
            double ramPrice=double.Parse(Console.ReadLine());
            int ramQuantity=int.Parse(Console.ReadLine());
            double procent=double.Parse(Console.ReadLine());
            double videoCardPriceWithDiscount = videoCardPrice - procent * videoCardPrice;
            double processorPriceWithDicount=processorPrice - procent*processorPrice;
            double totalPrice = processorPriceWithDicount + videoCardPriceWithDiscount + (ramPrice * ramQuantity);
            double totalPriceInLv = totalPrice * 1.57;
            Console.WriteLine($"Money needed - {totalPriceInLv:f2} leva.");
        }
    }
}

