﻿using System;

namespace Number100200
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            if (a < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if ( a <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if(a > 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
