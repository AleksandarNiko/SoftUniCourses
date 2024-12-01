using System;

namespace EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    array[i] = ReadNumber(start, end);
                    if (array[i] <= start || array[i] >= 100)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                    continue;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Your number is not in range {i+1} - 100!");
                    i--;
                    continue;
                }
                start = array[i];
            }
            Console.WriteLine(string.Join(", ", array));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            while (!int.TryParse(input, out num))
            {
                throw new FormatException("Invalid Number!");
            }
            return num;
        }
    }
}
/*
1
2
1
3
p
4
5
6
7
8
9
10
11
*/