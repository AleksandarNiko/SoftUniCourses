using System.Security.Cryptography;

namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray ();
            int sum = int.Parse(Console.ReadLine());
            for (int i = 0; i < arr.Length; i++)
            {
               for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == sum)
                    {
                        Console.WriteLine($"{arr[i]} {arr[j]}");
                    }
                }

            }
        }
    }
}