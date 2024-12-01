namespace _05.Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                bool isMax = true;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isMax = false;
                        break;
                    }
                }
                if (isMax)
                {
                    Console.Write(arr[i]+ " ");
                }
            }          
        }
    }
}