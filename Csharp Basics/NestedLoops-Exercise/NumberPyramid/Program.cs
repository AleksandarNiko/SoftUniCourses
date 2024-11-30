using System;

namespace NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int rows = 1;
            int cols = 1;
            for  (int i = 1; i <= num; i++)
            {
                Console.Write(i);
                if (rows==cols)
                {
                    Console.WriteLine();
                    rows++;
                    cols = 1;
                }
                else
                {
                    Console.Write(" ");
                    cols++;
                }
            }
          
        }
      }
  }

