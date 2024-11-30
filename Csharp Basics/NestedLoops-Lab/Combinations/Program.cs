using System;
using System.Net.Sockets;
using System.Runtime.Versioning;

namespace Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number=int.Parse(Console.ReadLine());
            int counter = 0;
            for  (int x = 0; x <= number; x++)
            {
                for (int y = 0; y <= number; y++)
                {
                    for (int z = 0; z <= number; z++)
                    {
                        if(x+y+z == number)
                        {
                            counter++;
                           
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
