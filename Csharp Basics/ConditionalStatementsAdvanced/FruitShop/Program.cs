using System;
using System.ComponentModel.Design;

namespace FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
//плод(banana / apple / orange / grapefruit / kiwi / pineapple / grapes),
//ден от седмицата(Monday / Tuesday / Wednesday / Thursday / Friday / Saturday / Sunday)
            string fruit=Console.ReadLine();
            string day=Console.ReadLine();
            double quantity=double.Parse(Console.ReadLine());
            double price = 0;
            if(day=="Monday"|| day=="Tuesday"|| day=="Wednesday"|| day=="Thursday"|| day=="Friday")
            {
                switch (fruit)
                {
                    case "banana": price = 2.50; break;
                    case "apple": price = 1.20; break;
                    case "orange": price = 0.85; break;
                    case "grapefruit": price = 1.45; break;
                    case "kiwi": price = 2.70; break;
                    case "pineapple": price = 5.50; break;
                    case "grapes": price = 3.85; break;
                    default: Console.WriteLine("error");break;
                }
            }
            else if(day=="Saturday"|| day=="Sunday")
            {
                switch(fruit)
                {
                    case "banana": price = 2.70; break;
                    case "apple": price = 1.25; break;
                    case "orange": price = 0.90; break;
                    case "grapefruit": price = 1.60; break;
                    case "kiwi": price = 3.00; break;
                    case "pineapple": price = 5.60; break;
                    case "grapes":price = 4.20;break;
                        default: Console.WriteLine("error");break;
                }
            }
            else { Console.WriteLine("error"); }
            if (price > 0)
            {
                double finalPrice = price * quantity;
                Console.WriteLine($"{finalPrice:F2}");
            }
        }
    }
}
