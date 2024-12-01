using System.Numerics;

namespace _03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < nums; i++)
            {
                decimal currentNum=decimal.Parse(Console.ReadLine());
                sum += currentNum;
            }

            Console.WriteLine(sum);
        }
    }
}
/*
3
1000000000000000000
5
10

2
0.00000000003
333333333333.3
*/