using System;

namespace SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time1= int.Parse(Console.ReadLine());
            int time2= int.Parse(Console.ReadLine());
            int time3= int.Parse(Console.ReadLine());
            int total=time1+time2+time3;
            int minutes=total/60;
            int seconds = total %60 ;
            if (seconds<10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
