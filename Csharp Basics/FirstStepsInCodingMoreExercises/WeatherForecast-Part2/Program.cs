using System;

namespace WeatherForecast_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double degree=double.Parse(Console.ReadLine());
            if (degree <=11.9 && degree>=5) { Console.WriteLine("Cold"); }
            else if(degree <=14.9&& degree>=12.00)
            {
                Console.WriteLine("Cool");
            }
            else if( degree <=20.00&& degree>=15) { Console.WriteLine("Mild"); }
            else if (degree <= 25.9&& degree>=20.1) { Console.WriteLine("Warm"); }
            else if(degree<=35 && degree>=26)
            {
                 Console.WriteLine("Hot");
            }
            else { Console.WriteLine("unknown"); }
        }
    }
}
