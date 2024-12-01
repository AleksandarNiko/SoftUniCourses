namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix= new int[rows][];
            for (int row = 0;row < jaggedMatrix.Length; row++)
            {
                jaggedMatrix[row]=Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] lineToken = input.Split(' ');
                int row = int.Parse(lineToken[1]);
                int col = int.Parse(lineToken[2]);
                int value = int.Parse(lineToken[3]);
                if (row < 0 || col < 0 || row >= jaggedMatrix.Length || col >= jaggedMatrix.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (lineToken[0] == "Add")
                    {
                        jaggedMatrix[row][col] += value;
                    }
                    else 
                    {
                        jaggedMatrix[row][col] -= value;
                    }
                }
            }


            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    Console.Write(jaggedMatrix[row][col]+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
/*
4
1 2 3 4
5
8 7 6 5
4 3 2 1
Add 4 4 100
Add 3 3 100
Subtract -1 -1 42
Subtract 0 0 42
END
 */
