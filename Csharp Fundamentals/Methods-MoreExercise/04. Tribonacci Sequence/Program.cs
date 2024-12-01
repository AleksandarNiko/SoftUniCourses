using System.Numerics;

namespace _04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num=int.Parse(Console.ReadLine());
            if (num <= 0)
            {
                Console.WriteLine(0);
            }
            else if (num == 1)
            {
                Console.Write(1);
            }
            else if (num == 2)
            {
                Console.Write("1 1");
            }
            else if (num == 3)
            {
                Console.Write("1 1 2");
            }
            else
            {
                Console.Write("1 1 2 ");
                GetTribonacci(num);
            }
        }

        private static void GetTribonacci(int num)
        {
            int minus3 = 1;
            int minus2 = 1;
            int minus1 = 2;
            int max = num;
            for (int i = 0; i < max - 3; i++)
            {
                num = minus3 + minus2 + minus1;
                minus3 = minus2;
                minus2 = minus1;
                minus1 = num;
                Console.Write("{0} ", num);
            }
        }
    }
}