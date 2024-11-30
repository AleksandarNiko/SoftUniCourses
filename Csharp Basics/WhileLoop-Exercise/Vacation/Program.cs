using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double requireMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());
            int daysCount = 0;
            int consecutiveSpendDay = 0;
            while (currentMoney < requireMoney && consecutiveSpendDay < 5)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (command == "save")
                {
                    currentMoney += money;
                    consecutiveSpendDay = 0;
                }
                else if (command == "spend")
                {
                    if (money >currentMoney) { currentMoney = 0; }
                    else { currentMoney -= money; 
                    }
                
                    consecutiveSpendDay++;
                }

                daysCount++;
            }
               if(currentMoney >=requireMoney)
                {
                    Console.WriteLine($"You saved the money for {daysCount} days.");
                }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCount);
            }

            }

        }
    }

