namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]info=Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = info[0];
            int cols = info[1];
            int squaresCount = 0;
            string[] previousRow = null;
            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (row > 0)
                {
                    for (int col = 0; col < cols-1; col++)
                    {
                        if (currentRow[col] == previousRow[col]&& previousRow[col + 1] == currentRow[col]
                            && currentRow[col + 1] == previousRow[col])
                        {
                            squaresCount++;
                        }
                    }
                }

                previousRow = currentRow;
            }

            Console.WriteLine(squaresCount);
        }
    }
}
/*
3 4
A B B D
E B B B
I J B B
 */
