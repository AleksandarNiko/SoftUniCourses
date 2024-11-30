using System;
using System.Security.Cryptography.X509Certificates;

namespace Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int piecesLeft = width * height;
            string input = Console.ReadLine();
            while (input != "STOP" && piecesLeft > 0)
            {
                int piecesToTake = int.Parse(input);
                piecesLeft -= piecesToTake;
                if (piecesLeft <= 0) { break; }
                input = Console.ReadLine();
            }
                if (piecesLeft>0)
                {
                    Console.WriteLine($"{piecesLeft} pieces are left.");
                }
                else
            {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(piecesLeft)} pieces more.");
                }
     
            }
        } 
    
}
