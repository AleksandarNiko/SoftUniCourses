﻿using System;

namespace CharacterSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            for  (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
