namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] colElements = Console.ReadLine().Split(" ")
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            for (int i = 0; i < cols; i++)
            {
                int sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
/*
3, 6
7 1 3 3 2 1
1 3 9 8 5 6
4 6 7 9 1 0
 */
