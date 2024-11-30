using System;
using System.Diagnostics;

namespace FootbalSouve
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string team=Console.ReadLine();
            string souvenirs=Console.ReadLine();
            int souvenirsCount=int.Parse(Console.ReadLine());
            double souvenirsPrice = 0;
            switch(team)
            { 
                case "Argentina":
                    if(souvenirs== "flags")
                    {
                        souvenirsPrice = 3.25;
                    }
                    else if (souvenirs == "caps")
                    {
                        souvenirsPrice = 7.20;
                    }
                    else if(souvenirs == "posters")
                    {
                        souvenirsPrice = 5.10;
                    }
                    else if(souvenirs == "stickers")
                    {
                        souvenirsPrice = 1.25;
                    }
                    break;
                case "Brazil":
                    if (souvenirs == "flags")
                    {
                        souvenirsPrice = 4.20;
                    }
                    else if (souvenirs == "caps")
                    {
                        souvenirsPrice = 8.50;
                    }
                    else if (souvenirs == "posters")
                    {
                        souvenirsPrice = 5.35;
                    }
                    else if (souvenirs == "stickers")
                    {
                        souvenirsPrice = 1.20;
                    }
                    break;
                    case "Croatia":
                    if (souvenirs == "flags")
                    {
                        souvenirsPrice = 2.75;
                    }
                    else if (souvenirs == "caps")
                    {
                        souvenirsPrice = 6.90;
                    }
                    else if (souvenirs == "posters")
                    {
                        souvenirsPrice = 4.95;
                    }
                    else if (souvenirs == "stickers")
                    {
                        souvenirsPrice = 1.10;
                    }
                    break;
                case "Denmark":
                    if (souvenirs == "flags")
                    {
                        souvenirsPrice = 3.10;
                    }
                    else if (souvenirs == "caps")
                    {
                        souvenirsPrice = 6.50;
                    }
                    else if (souvenirs == "posters")
                    {
                        souvenirsPrice = 4.80;
                    }
                    else if (souvenirs == "stickers")
                    {
                        souvenirsPrice = 0.90;
                    }
                    break;
            }
            double totalPrice = souvenirsCount * souvenirsPrice;
            if (team !="Argentina"&& team!="Brazil"&& team!="Croatia"&& team != "Denmark")
            {
                Console.WriteLine("Invalid country!");
            }
            else if(souvenirs != "flags"&&souvenirs!= "caps"&&souvenirs!="posters"&& souvenirs!= "stickers")
            {
                Console.WriteLine("Invalid stock!");
            }
            else 
            {
                Console.WriteLine($"Pepi bought {souvenirsCount} {souvenirs} of {team} for {totalPrice:f2} lv.");
                    }
        }
    }
}
