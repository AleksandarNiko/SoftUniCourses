namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1=int.Parse(Console.ReadLine());
            int num2=int.Parse(Console.ReadLine());
            int num3=int.Parse(Console.ReadLine());
          
            int[] numbers = { num1, num2, num3 };
            int countOfNegative = 0;
            int countOfPositive = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    countOfNegative++;
                }
                else if (numbers[i] > 0)
                {
                    countOfPositive++;
                }
            }

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (countOfPositive == 3)
            {
                Console.WriteLine("positive");
            }
            else if (countOfPositive == 1 && countOfNegative == 2)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}
/*
2
3
-1

2
3
1
*/