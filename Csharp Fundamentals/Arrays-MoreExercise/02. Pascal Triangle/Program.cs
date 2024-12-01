namespace _02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var pascalTriangle = new long[number][];

            for (var i = 0; i < number; i++)
            {
                pascalTriangle[i] = new long[i + 1];
                pascalTriangle[i][0] = 1;  // first element is 1
                pascalTriangle[i][^1] = 1; // last element is 1

                for (var col = 1; col < i; col++)
                {
                    pascalTriangle[i][col] = pascalTriangle[i - 1][col - 1] + pascalTriangle[i - 1][col];
                }
            }

            for (var row = 0; row < number; row++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[row]));
            }
        }
    }
}