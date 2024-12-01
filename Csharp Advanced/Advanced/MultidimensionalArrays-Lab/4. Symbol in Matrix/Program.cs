namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeMatrix,sizeMatrix];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] colElements = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = colElements[cols];
                }
            }
            char findChar =char.Parse(Console.ReadLine());
            bool isValid=false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == findChar)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isValid = true;
                        return;
                    }
                    else
                    {
                        isValid=false;
                    }
                }
            }

            if (isValid==false)
            {
                Console.WriteLine($"{findChar} does not occur in the matrix");
            }
        }
    }
}
/*
3
ABC
DEF
X!@
!
 
4
asdd
xczc
qwee
qefw
4
*/
