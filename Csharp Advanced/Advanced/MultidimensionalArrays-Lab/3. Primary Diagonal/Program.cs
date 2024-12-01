using System.Threading.Channels;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize,matrixSize];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] colElements = Console.ReadLine().Split(" ")
                    .Select(int.Parse).ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = colElements[cols];
                }
            }

            int sum = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols<matrix.GetLength(1); cols++)
                {
                    if (rows == cols)
                    {
                        sum += matrix[cols, rows];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
/*
3
11 2 4
4 5 6
10 8 -12
 */
