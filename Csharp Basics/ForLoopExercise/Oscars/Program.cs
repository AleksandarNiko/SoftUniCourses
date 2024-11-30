using System;

namespace Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name=Console.ReadLine();
            double pointsAcademy=double.Parse(Console.ReadLine());
            int jurys=int.Parse(Console.ReadLine());
            for (int i = 0; i < jurys && pointsAcademy<=1250.5; i++)
            {
                string jury = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                int length = jury.Length;
                pointsAcademy +=(length * juryPoints) / 2;
            }
                if (pointsAcademy > 1250.5) 
                {
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {pointsAcademy:f1}!");
                }
                else 
                { 
                    Console.WriteLine($"Sorry, {name} you need {Math.Abs(1250.5-pointsAcademy):f1} more!"); 
                }
            }
        }
    }

