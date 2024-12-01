namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][]jaggedArray= new int[rows][];

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                jaggedArray[row]= Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < jaggedArray.GetLength(0)-1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length )
                {
                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] *= 2;
                    }
                    for (int i = 0; i < jaggedArray[row+1].Length; i++)
                    {
                        jaggedArray[row+1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] /= 2;
                    }
                    for (int i = 0; i < jaggedArray[row + 1].Length; i++)
                    {
                        jaggedArray[row + 1][i] /= 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] lineToken = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = lineToken[0].ToLower();
                if (command == "add")
                {
                    int row = int.Parse(lineToken[1]);
                    int col = int.Parse(lineToken[2]);
                    int value = int.Parse(lineToken[3]);

                    if (row >= 0 && row < jaggedArray.GetLength(0) 
                                 && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] += value;
                    }
                   
                } 
                if (command == "subtract")
                {
                    int row = int.Parse(lineToken[1]);
                    int col = int.Parse(lineToken[2]);
                    int value = int.Parse(lineToken[3]);
                    if (row >= 0 && row < jaggedArray.GetLength(0) 
                                 && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }
    }
}
/*
5
10 20 30
1 2 3
2
2
10 10
Add 0 10 10
Add 0 0 10
Subtract -3 0 10
Subtract 3 0 10
End

5
10 20 30
1 2 3
2
2
10 10
End
 */
