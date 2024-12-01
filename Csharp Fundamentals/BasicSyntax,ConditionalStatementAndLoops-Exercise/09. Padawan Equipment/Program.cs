using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney=double.Parse(Console.ReadLine());
            int countOfStudents=int.Parse(Console.ReadLine());
            double priceOfLightsaber=double.Parse(Console.ReadLine());
            double priceOfRobe=double.Parse(Console.ReadLine());
            double priceOfBelt=double.Parse(Console.ReadLine());

            double priceForAllLightsabers = Math.Ceiling(countOfStudents * 1.1) * priceOfLightsaber;
            double priceForAllRobes=priceOfRobe * countOfStudents;
            
            int freeBelts=countOfStudents/6;
            double priceForAllBelts=(countOfStudents-freeBelts)*priceOfBelt;
            double sum = priceForAllBelts + priceForAllLightsabers + priceForAllRobes;
            if(sum<=amountOfMoney )
            {
                Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {sum-amountOfMoney:f2}lv more.");
            }
        }
    }
}
