﻿using System;

namespace Foreign_Languages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country=Console.ReadLine();
            switch(country)
            {
                case "England":Console.WriteLine("English");
                    break;
                case "USA": Console.WriteLine("English");
                    break;
                case "Spain":Console.WriteLine("Spanish");
                    break;
                case "Argentina":Console.WriteLine("Spanish"); break;
                case "Mexico":Console.WriteLine("Spanish");break;
                    default: Console.WriteLine("unknown");break;
            }
        }
    }
}
