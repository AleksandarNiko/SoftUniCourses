﻿using System;

namespace ProverkiUrok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade >=5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
