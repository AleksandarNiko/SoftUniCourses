﻿using System;
using System.Collections.Generic;

namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word=Console.ReadLine();
            for (int i = word.Length - 1; i >= 0; i--)
            {
                Console.Write(word[i]);
            }
        }
    }
}

