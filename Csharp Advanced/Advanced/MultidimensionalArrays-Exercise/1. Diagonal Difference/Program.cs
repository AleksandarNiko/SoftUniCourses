using System.Data;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int primDiagSum = 0;
            int secDiagSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            { 
                int[] newRow=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = newRow[col];
                    if (row == col)
                    {
                        primDiagSum += matrix[row, col];
                    }
                }
            }

            for (int row = 0; row <size; row++)
            {
                secDiagSum += matrix[row, size  - 1 - row];
            }

            Console.WriteLine(Math.Abs(primDiagSum-secDiagSum));
        }
    }
}
/*
3
11 2 4
4 5 6
10 8 -12
 */
