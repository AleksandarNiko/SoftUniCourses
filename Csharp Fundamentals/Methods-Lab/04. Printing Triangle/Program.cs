namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintHalfTriangle(number);
            PrintOtherHalf(number);
        }

         private static void PrintHalfTriangle(int number)
        {
            for (int rows = 1; rows <= number; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    Console.Write(cols+ " ");
                }
                Console.WriteLine();
            }
        }
        private static void PrintOtherHalf(int number)
        {
            for (int rows = number-1;rows >= 1; rows--)
            {
                for (int cols = 1;cols <=rows; cols++)
                {
                    Console.Write(cols+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}