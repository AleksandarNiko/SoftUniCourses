﻿using System;

namespace _1.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //  · 0 - 2 – baby

//· 3 - 13 – child

//· 14 - 19 – teenager

//· 20 - 65 – adult

//· >= 66 – elder
            int age = int.Parse(Console.ReadLine());
            if (age <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (age <= 13)
            {
                Console.WriteLine("child");
            }
            else if(age <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (age <=65)
            {
                Console.WriteLine("adult");
            }
            else if (age >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
