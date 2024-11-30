using System;
using System.ComponentModel.Design;

namespace TimePlusMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours=int.Parse(Console.ReadLine());
            int minutes=int.Parse(Console.ReadLine());
            int minuteTime= minutes + 15;
            int hourTime = hours +(minuteTime/60);
            int finalMinute = minuteTime % 60;
            if (hourTime == 24) { hourTime = 0; }
            if (finalMinute < 10) { Console.WriteLine($"{hourTime}:0{finalMinute}"); }
            else { Console.WriteLine($"{hourTime}:{finalMinute}"); }
            
        }
    }
}
