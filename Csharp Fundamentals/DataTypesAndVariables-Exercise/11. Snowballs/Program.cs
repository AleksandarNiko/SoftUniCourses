using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int numberOfSnowballs=int.Parse(Console.ReadLine());
            BigInteger maxSnowballValue = 0;
            int maxSnowballSnow = 0;
            int maxSnowballTime = 0;
            int maxSnowballQuality = 0;
            for (int i = 1; i <= numberOfSnowballs; i++)
            {
                int snowBallSnow = int.Parse(Console.ReadLine());
                int snowBallTime = int.Parse(Console.ReadLine());
                int snowBallQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow((snowBallSnow / snowBallTime), snowBallQuality);
                if (snowballValue > maxSnowballValue)
                {
                    maxSnowballValue = snowballValue;
                    maxSnowballSnow = snowBallSnow;
                    maxSnowballTime = snowBallTime;
                    maxSnowballQuality = snowBallQuality;
                }
            }
            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {maxSnowballValue} ({maxSnowballQuality})");
        }
            }
        }