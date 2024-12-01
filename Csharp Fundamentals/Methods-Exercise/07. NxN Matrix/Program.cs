namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            FillArray(n, arr);
            PrintMatrix(n, arr);

        }

        private static void PrintMatrix(int n, int[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }

        private static void FillArray(int n, int[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = n;
            }
        }
    }
}