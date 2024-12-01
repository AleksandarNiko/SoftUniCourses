namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int removedKnights = 0;
            while (true) 
            {
                int maxNumberAttackKnights = int.MinValue;
                int rowMax = int.MinValue;
                int colMax = int.MinValue;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int numberAttackKnights = 0;
                        if (matrix[row, col] == 'K')
                        {
                            numberAttackKnights =
                                MethodToCheckInFrontOfTheKnight(cols, matrix, row, col, numberAttackKnights);
                            numberAttackKnights =
                                MethodToCheckBehindTheKnight(rows, cols, matrix, row, col, numberAttackKnights);
                            numberAttackKnights =
                                MethodToCheckOnLeftTheKnight(rows, matrix, row, col, numberAttackKnights);
                            numberAttackKnights =
                                MethodToCheckOnRightTheKnight(rows, cols, matrix, row, col, numberAttackKnights);
                        }

                        if (numberAttackKnights > maxNumberAttackKnights)
                        {
                            maxNumberAttackKnights = numberAttackKnights;
                            rowMax = row;
                            colMax = col;
                        }
                    }
                }

                if (maxNumberAttackKnights > 0)
                {
                    matrix[rowMax, colMax] = '0';
                    removedKnights++;
                }

                else if (maxNumberAttackKnights == 0)
                {
                    break;
                }
            }

            Console.WriteLine(removedKnights);
        }
    


     static int MethodToCheckOnRightTheKnight(int rows, int cols, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 1 < rows && col + 2 < cols)
            {
                if (board[row + 1, col + 2] == 'K') 
                {
                    numberAttackKnights++;
                }
            }

            if (row - 1 >= 0 && col + 2 < cols)
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

         static int MethodToCheckOnLeftTheKnight(int rows, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 1 < rows && col - 2 >= 0)
            {
                if (board[row + 1, col - 2] == 'K') // on left 
                {
                    numberAttackKnights++;
                }
            }

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

         static int MethodToCheckBehindTheKnight(int rows, int cols, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 2 < rows && col + 1 < cols)
            {
                if (board[row + 2, col + 1] == 'K') // behind
                {
                    numberAttackKnights++;
                }
            }

            if (row + 2 < rows && col - 1 >= 0)
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

         static int MethodToCheckInFrontOfTheKnight(int cols, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row - 2 >= 0 && col + 1 < cols)
            {
                if (board[row - 2, col + 1] == 'K') 
                {
                    numberAttackKnights++;
                }
            }

            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }
    }
    }

