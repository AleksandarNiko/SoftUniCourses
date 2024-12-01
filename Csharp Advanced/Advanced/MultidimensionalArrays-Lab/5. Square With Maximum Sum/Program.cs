namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biggestSquareRows = 2;
            int biggestSquareCols = 2;

            int[] matrixInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + biggestSquareRows - 1 < rows && col + biggestSquareCols - 1 < cols)
                    {
                        int sum = 0;
                        for (int currentRow = row; currentRow < row + biggestSquareRows; currentRow++)
                        {
                            for (int currentCol = col; currentCol < col + biggestSquareCols; currentCol++)
                            {
                                sum += matrix[currentRow, currentCol];
                            }
                        }


                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxColIndex = col;
                            maxRowIndex = row;
                        }
                    }


                }
            }


            for (int row = maxRowIndex; row < maxRowIndex + biggestSquareRows; row++)
            {
                for (int col = maxColIndex; col < maxColIndex + biggestSquareCols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
     

    }
    }
}
/*
3, 6
7, 1, 3, 3, 2, 1
1, 3, 9, 8, 5, 6
4, 6, 7, 9, 1, 0
*/