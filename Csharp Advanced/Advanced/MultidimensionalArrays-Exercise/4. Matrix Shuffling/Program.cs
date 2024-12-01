namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] newRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col]= newRow[col];
                }                 
            }
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] lineToken = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = lineToken[0];

                if(command=="swap"&& lineToken.Length==5)
                {
                    int row1 = int.Parse(lineToken[1]);
                    int col1 = int.Parse(lineToken[2]);
                    int row2 = int.Parse(lineToken[3]);
                    int col2 = int.Parse(lineToken[4]);

                    if(IsValid(matrix,row1,col1,row2,col2)==true)
                    {
                        string temp = matrix[row1,col1];
                        matrix[row1,col1]=matrix[row2,col2];
                        matrix[row2,col2] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
         static bool IsValid(string[,]matrix, int row1,int col1,int row2,int col2)
        {
            bool isValid = false;
            if(row1>=0&&row1<matrix.GetLength(0)
                && col1>=0&& col1<matrix.GetLength(1)
                && row2>=0&& row2<matrix.GetLength(0)
                && col2>=0&& col2<matrix.GetLength(1))
            {
                isValid=true;
            }
            return isValid;
        }
    }
}
/*
2 3   
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END
*/
