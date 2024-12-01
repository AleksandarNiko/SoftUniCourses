namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            int[][] matrix = new int[rows][];

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol= 0;
            for (int row = 0; row < rows; row++)
            {
                matrix[row]= Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    int currentSum = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            currentSum += matrix[row + i][col + j];
                        }
                    }

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRow=row;
                        maxCol=col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxRow; row < maxRow+3; row++)
            {
                for (int col = maxCol; col < maxCol+3; col++)
                {
                    Console.Write(matrix[row][col]+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
/*
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
 */
